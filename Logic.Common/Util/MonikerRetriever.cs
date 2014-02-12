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
                if (addIfNotFound && moniker == null) moniker = AddMoniker(text);
            }

            if (moniker != null)
            {
                var redirectCounter = 5;
                while (redirectCounter > 0 && moniker.AliasForMoniker != 0)
                {
                    moniker = MonikerLogic.SelectBy_MonikerIdNow(moniker.AliasForMoniker).FirstOrDefault();
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
            return moniker;
        }

        public static List<MonikerContract> FindMonikers(string text)
        {
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
                    result.Add(moniker);
                    w = r;
                }

                w++;
            }
            return result;
        }

        public static void AssociateMonikers(string thisMoniker, string alsoMeans)
        {
            var parent = GetMoniker(alsoMeans, true);
            var child = GetMoniker(thisMoniker, true);
            child.AliasForMoniker = parent.MonikerId??0;
            MonikerLogic.SaveNow(child);
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
            
            BinaryDataMonikerLogic.SaveAllNow(associations);
        }
    }
}
