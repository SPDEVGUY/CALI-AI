using System;
using System.Collections.Generic;
using System.Runtime.Serialization; //NOTE: Reference Required for DataContract and DataMember
using System.Xml.Serialization;
using System.IO;

//////////////////////////////////////////////////////////////
//Do not modify this file. Use a partial class to extend.	//
//Override methods in the logic front class.				//
//////////////////////////////////////////////////////////////
// This class is inherited by all logic classes.

namespace CALI.Database.Logic
{
    [Serializable]
    public abstract partial class LogicBase<T>
    {
		//Put your code in a separate file.  This is auto generated.

        private int _defaultCommandTimeout = CALIDb.Singleton.DefaultCommandTimeout;
	    public virtual int DefaultCommandTimeout
	    {
	        get { return _defaultCommandTimeout; }
	        set { _defaultCommandTimeout = value; }
	    }

        public string Serialize()
        {
            var s = new XmlSerializer(typeof(T));
            var ms = new MemoryStream();
            s.Serialize(ms, this);
            var bytes = ms.ToArray();

            return System.Text.Encoding.ASCII.GetString(bytes);
        }
        
        public static T Deserialize(string xml)
        {
            var s = new XmlSerializer(typeof(T));
            var ms = new MemoryStream(System.Text.Encoding.ASCII.GetBytes(xml));
            var obj = s.Deserialize(ms);
            
            return (T)obj;
        }
                
        public long IncrementTimestamp(long stamp)
        {
            var b = BitConverter.GetBytes(stamp);
            
            for(var i = 7; i >= 0; i--)
            {
                if(b[i] != 255)
                {
                    b[i]++;
                    break;
                }
                b[i] = 0;
            }
            return BitConverter.ToInt64(b,0);
        }
    }
}