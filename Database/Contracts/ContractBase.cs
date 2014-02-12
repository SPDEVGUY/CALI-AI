using System;
using System.Collections.Generic;
using System.Runtime.Serialization; //NOTE: Reference Required for DataContract and DataMember
using System.IO;

///////////////////////////////////////////////////////////
//Do not modify this file. Use a partial class to extend.//
///////////////////////////////////////////////////////////
// This class is inherited by all contract classes.

namespace CALI.Database.Contracts
{
    [DataContract]
    public abstract partial class ContractBase<T>
    {
		//Put your code in a separate file.  This is auto generated.

        public string Serialize()
        {
            var ser = new DataContractSerializer(typeof(T));
            using (var ms = new MemoryStream())
            {
                ser.WriteObject(ms, this);
                ms.Seek(0, SeekOrigin.Begin);
                using (var s = new StreamReader(ms))
                {
                    return s.ReadToEnd();
                }
            }
        }

        public static T Deserialize(string xml)
        {
            if (xml.Length != 0)
            {
                var ser = new DataContractSerializer(typeof(T));
                using (var ms = new MemoryStream())
                {
                    using (var sw = new StreamWriter(ms))
                    {
                        sw.Write(xml);
                        return (T)(ser.ReadObject(ms) ?? default(T));
                    }
                }
            }

            return default(T);
        }
    }
}
