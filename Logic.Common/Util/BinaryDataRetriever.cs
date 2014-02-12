using System.IO;
using System.Security.Cryptography;
using CALI.Database.Contracts.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CALI.Database.Logic;
using CALI.Database.Logic.Data;

namespace CALI.Logic.Common.Util
{
    public class BinaryDataRetriever
    {
        public static BinaryDataContract StoreData(string dataType, byte[] data)
        {
            //TODO: Add lookup for hash on binary data to prevent duplication?
            var hash = ComputeHash(data);

            var binaryData = BinaryDataLogic.SelectBy_HashNow(hash).FirstOrDefault()
                ?? new BinaryDataContract
                                 {
                                     Data = data,
                                     DataType = dataType,
                                     DateCreated = DateTime.Now,
                                     Hash = hash
                                 };

            if(binaryData.BinaryDataId == null) BinaryDataLogic.SaveNow(binaryData);

            return binaryData;
        }

        public static List<BinaryDataContract> GetData(params MonikerContract[] monikers)
        {
            var results = new List<BinaryDataContract>();
            CALIDb.ConnectThen(
                c =>
                    {
                        //Select from associations with first moniker
                        var mainResults = BinaryDataMonikerLogic.SelectBy_MonikerIdNow(monikers[0].MonikerId ?? 0,c,null);

                        var monikerIds = new List<int>();
                        var binaryDataIds = new List<int>();
                        foreach (var moniker in monikers) monikerIds.Add(moniker.MonikerId ?? 0);

                        //Then filter results using remaining monikers
                        foreach (var result in mainResults)
                        {
                            var tangentAssociations =
                                BinaryDataMonikerLogic.SelectBy_BinaryDataIdNow(result.BinaryDataId, c, null);
                            var containsAll = true;
                            foreach (var monikerId in monikerIds)
                            {
                                var ix = tangentAssociations.FindIndex(x => (monikerId == x.MonikerId));
                                if (ix < 0)
                                {
                                    containsAll = false;
                                    break;
                                }
                            }
                            if (containsAll)
                            {
                                if (!binaryDataIds.Contains(result.BinaryDataId))
                                {
                                    binaryDataIds.Add(result.BinaryDataId);
                                    results.Add(result.BinaryData);
                                }
                            }
                        }
                    }
                );
            return results;
        }

        public static string ComputeHash(byte[] bytes)
        {
            if (bytes == null || bytes.Length == 0) return "";

            try
            {
                using (var stream = new MemoryStream(bytes))
                {
                    var sha = new SHA256Managed();
                    byte[] checksum = sha.ComputeHash(stream);
                    return BitConverter.ToString(checksum).Replace("-", String.Empty).ToLower();
                }
            }
            catch (IOException iox)
            {
                return "FAILED TO OBTAIN READ LOCK";
            }
        }
    }
}
