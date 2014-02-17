using CALI.Database.Contracts.Data;
using CALI.Database.Logic;
using CALI.Database.Logic.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CALI.Logic.Common.Util
{
    public class MonikerRetriever
    {
        private static Dictionary<string, MonikerContract> _cached = new Dictionary<string, MonikerContract>();

        public static MonikerContract GetMoniker(string text, bool addIfNotFound = false)
        {
            var lText = text.ToLower().Trim();
            MonikerContract moniker = null;
            lock(_cached) if (_cached.ContainsKey(lText)) moniker = _cached[lText];

            if (moniker == null)
            {
                moniker = MonikerLogic.SelectBy_TextNow(lText).FirstOrDefault();

                if (moniker == null && lText.EndsWith("s"))
                {
                    //May be pluralized.
                    Logger.Log.Info("Attempting to depluralize {0}", text);
                    if (lText.EndsWith("xes") || lText.EndsWith("ses")) lText = lText.Substring(0, lText.Length - 2);
                    else lText = lText.Substring(0, lText.Length - 1);
                    moniker = MonikerLogic.SelectBy_TextNow(lText).FirstOrDefault();
                }
                if (addIfNotFound && moniker == null) moniker = AddMoniker(text);
            }

            if (moniker != null)
            {
                Logger.Log.Info("Got moniker '{0}:{1}'", moniker.MonikerId, moniker.Text);

                var redirectCounter = 5;
                while (redirectCounter > 0 && moniker.AliasForMoniker != 0)
                {
                    moniker = MonikerLogic.SelectBy_MonikerIdNow(moniker.AliasForMoniker).FirstOrDefault();
                    if(moniker != null) Logger.Log.Info("Aliased by '{0}:{1}'", moniker.MonikerId, moniker.Text);
                    redirectCounter--;
                }
            }
            return moniker;
        }

        public static MonikerContract AddMoniker(string text)
        {
            var lText = text.ToLower().Trim();
            var moniker = MonikerLogic.SelectBy_TextNow(lText).FirstOrDefault()
                         ?? new MonikerContract
                         {
                             AliasForMoniker = 0,
                             DateCreated = DateTime.Now,
                             Text = lText
                         };
            if (moniker.MonikerId == null) MonikerLogic.SaveNow(moniker);
            lock (_cached) _cached[lText] = moniker;

            Logger.Log.Info("Added moniker '{0}:{1}'", moniker.MonikerId, moniker.Text);
            if (text.Contains(" "))
            {
                Logger.Log.Info("Splitting complex moniker.");
                var texts = text.Split(new char[] { ' ' });
                foreach (var t in texts) AddMoniker(t);
            }

            return moniker;
        }

        public static List<MonikerContract> FindMonikers(string text, bool addIfNotFound = false)
        {
            Logger.Log.Info("FindMonikers '{0}'", text);

            var result = new List<MonikerContract>();
            var words = text.Split(new [] {' '});
            var w = 0;
            var compiledText = new StringBuilder();
            while (w < words.Length)
            {
                var r = w;

                compiledText.Clear();
                while (r < words.Length)
                {
                    compiledText.Append(words[r]);
                    compiledText.Append(' ');
                    r++;
                }
                var moniker = GetMoniker(compiledText.ToString());
                if (moniker != null)
                {
                    Logger.Log.Info("Found '{0}:{1}'", moniker.MonikerId, moniker.Text);
                    result.Add(moniker);
                    w = r;
                }

                w++;
            }

            if (result.Count == 0)
            {
                Logger.Log.Info("Didn't find '{0}'", text);
                if (addIfNotFound)
                {
                    result.Add(GetMoniker(text, true));
                    if (text.Contains(" "))
                    {
                        Logger.Log.Info("Finding splitted monikers.");
                        var texts = text.Split(new char[] {' '});
                        foreach (var t in texts)
                        {
                            result.Add(GetMoniker(t,true));
                        }
                    }
                }
            }
            return result;
        }

        public static void AssociateMonikers(string thisMoniker, string alsoMeans)
        {
            var parent = GetMoniker(alsoMeans, true);
            var child = GetMoniker(thisMoniker, true);

            if (parent.MonikerId != child.MonikerId)
            {

                child.AliasForMoniker = parent.MonikerId ?? 0;

                Logger.Log.Info("Aliased moniker '{2}:{3}' to '{0}:{1}'", parent.MonikerId, parent.Text, child.MonikerId,
                                child.Text);
                MonikerLogic.SaveNow(child);
            }
            else
            {
                Logger.Log.Info("Avoided aliasing moniker to itself.");
            }
        }
        
        public static void AssociateMonikers(BinaryDataContract data, params MonikerContract[] monikers)
        {
            var associations = monikers.Select(
                moniker => new BinaryDataMonikerContract
                               {
                                   BinaryDataId = data.BinaryDataId ?? 0,
                                   MonikerId = moniker.MonikerId ?? 0
                               }
                ).ToList();

            Logger.Log.Info("Associated monikers to binary data {0}.", data.BinaryDataId);
            BinaryDataMonikerLogic.SaveAllNow(associations);
        }
    }
}
