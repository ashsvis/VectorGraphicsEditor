using System;
using System.Collections.Generic;
using System.Linq;

namespace SimpleEditor.Controls
{
    public static class Helper
    {
        /// <summary>
        /// Returns property value for multiple objects.
        /// </summary>
        /// <returns>
        /// Returns value of property if all of objects contain same value.
        /// Returns default(T) if objects contains different values
        /// </returns>
        public static T GetProperty<P, T>(this IEnumerable<P> list, Func<P, T> selector, T defaultValue = default(T))
        {
            T result = defaultValue;
            var isAssigned = false;

            foreach (var obj in list)
            {
                var val = selector(obj);
                if (!isAssigned)
                {
                    result = val;
                    isAssigned = true;
                }
                else
                {
                    if (!Object.Equals(result, val))
                        return defaultValue;
                }
            }

            return result;
        }

        /// <summary>
        /// Apply action to all objects
        /// </summary>
        public static void SetProperty<T>(this IEnumerable<T> list, Action<T> setter)
        {
            foreach (var obj in list)
                setter(obj);
        }

        /// <summary>
        /// Sequence contains elements and condition is True fo all of elements 
        /// </summary>
        public static bool ForAll<T>(this IEnumerable<T> list, Func<T, bool> condition)
        {
            return list.Any() && list.All(condition);
        }
    }
}
