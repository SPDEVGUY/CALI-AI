using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace CALI.Logic.Common.Util
{
    public static class ExtensionsThatMakeUpForMissing45
    {
        /// <summary>
        /// Gets an attribute on an enum field value
        /// </summary>
        /// <typeparam name="T">The type of the attribute you want to retrieve</typeparam>
        /// <param name="enumVal">The enum value</param>
        /// <returns>The attribute of type T that exists on the enum value</returns>
        public static T GetAttributeOfType<T>(this Enum enumVal) where T : System.Attribute
        {
            var type = enumVal.GetType();
            var memInfo = type.GetMember(enumVal.ToString());
            var attributes = memInfo[0].GetCustomAttributes(typeof(T), false);
            return (T)attributes[0];
        }

        public static T GetCustomAttribute<T>(this MemberInfo memberInfo) where T : class
        {
            var attributes = memberInfo.GetCustomAttributes(false);
            foreach (var attr in attributes)
                if (attr is T) return (T)attr;
            return null;
        }
    }
    public class ReflectoMatic
    {
        public static List<TR> CreateObjects<TR, TA>(Assembly assembly) where TR : class
        {
            var result = new List<TR>();
            try
            {
                var types = assembly.GetTypes();
                foreach (var t in types)
                {
                    if (!t.IsAbstract && t.IsClass)
                    {
                        var attribute =
                            t.GetCustomAttributes(typeof(TA), true).FirstOrDefault();
                        if (attribute != null)
                        {
                            try
                            {
                                var ctr = t.GetConstructor(new Type[] { });
                                if (ctr != null)
                                {
                                    var obj = ctr.Invoke(new object[] { }) as TR;
                                    if (obj != null)
                                    {
                                        result.Add(obj);
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                Logger.Log.Exception(ex, "Failed to construct a {0}.", t);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Log.Exception(ex, "Failed to reflect types from assembly <{0}>.", assembly.FullName);
            }
            return result;
        }
        
        public static List<TR> CreateObjects<TR>(Assembly assembly) where TR : class
        {
            var result = new List<TR>();
            try
            {
                var types = assembly.GetTypes();
                foreach (var t in types)
                {
                    if (!t.IsAbstract && t.IsClass)
                    {
                        try
                        {
                            var ctr = t.GetConstructor(new Type[] { });
                            if (ctr != null)
                            {
                                var obj = ctr.Invoke(new object[] { }) as TR;
                                if (obj != null)
                                {
                                    result.Add(obj);
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            Logger.Log.Exception(ex, "Failed to construct a {0}.", t);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Log.Exception(ex, "Failed to reflect types from assembly <{0}>.", assembly.FullName);
            }
            return result;
        }
    }
}
