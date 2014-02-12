using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.Runtime.Serialization;

///////////////////////////////////////////////////
//Do not modify this file. It is auto generated. //
///////////////////////////////////////////////////

namespace CALI.Database.Logic
{
    public static class ListExtensions
    {

        /// <summary>
        /// Convert a List{T} to a DataTable.
        /// </summary>
        public static DataTable AsDataTable<T>(this List<T> items)
        {
            var tb = new DataTable(typeof(T).Name);

            var allProps = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            var dataProps = new List<PropertyInfo>();

            foreach (var prop in allProps)
            {
                var isDataMember = prop.GetCustomAttributes(typeof(DataMemberAttribute), true).Length != 0;
                if (isDataMember) dataProps.Add(prop);
            }

            foreach (var prop in dataProps)
            {
                var t = GetCoreType(prop.PropertyType);
                tb.Columns.Add(prop.Name, t);
            }

            foreach (T item in items)
            {
                var values = new object[dataProps.Count];

                for (int i = 0; i < dataProps.Count; i++)
                {
                    values[i] = dataProps[i].GetValue(item, null);
                }

                tb.Rows.Add(values);
            }

            return tb;
        }

        /// <summary>
        /// Determine of specified type is nullable
        /// </summary>
        private static bool IsNullable(Type t)
        {
            return !t.IsValueType || (t.IsGenericType && t.GetGenericTypeDefinition() == typeof(Nullable<>));
        }

        /// <summary>
        /// Return underlying type if type is Nullable otherwise return the type
        /// </summary>
        private static Type GetCoreType(Type t)
        {
            if (t != null && IsNullable(t))
            {
                return !t.IsValueType ? t : Nullable.GetUnderlyingType(t);
            }
            return t;
        }
    }
}
