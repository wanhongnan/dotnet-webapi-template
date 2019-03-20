using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Utils
{
    public static class UtilExtened
    {
        public static List<T> ToList<T>(this IEnumerable This)
        {
            var ret = new List<T>();
            foreach (var item in This)
            {
                ret.Add((T)item);
            }
            return ret;
        }

        public static IEnumerable<T> AsEnumerable<T>(this IEnumerable This)
        {
            foreach (var item in This)
            {
                yield return (T)item;
            }
        }

        public static string ToMyString(this object This) {
            if (This == DBNull.Value)
                return null;
            return This.ToString();
        }
    }
}
