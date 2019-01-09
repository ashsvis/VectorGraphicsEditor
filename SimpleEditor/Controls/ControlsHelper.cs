using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleEditor.Controls
{
    public static class ControlsHelper
    {
        /// <summary>
        /// Returns property value for multiple objects.
        /// </summary>
        /// <returns>
        /// Returns value of property if all of objects contain same value.
        /// Returns default(T) if objects contains different values
        /// </returns>
        public static T GetProperty<TP, T>(this IEnumerable<TP> list, Func<TP, T> selector,
            T defaultValue = default(T))
        {
            T result = defaultValue;
            var isAssigned = false;

            foreach (var val in list.Select(selector))
            {
                if (!isAssigned)
                {
                    result = val;
                    isAssigned = true;
                }
                else
                {
                    if (!Equals(result, val))
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
            var enumerable = list as T[] ?? list.ToArray();
            return enumerable.Any() && enumerable.All(condition);
        }

        /// <summary>
        /// Получение имён шрифтов, поддерживаемых требуемые начертания
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<string> GetInstalledFontCollection()
        {
            var sbFonts = new List<string>();
            using (var ifc = new InstalledFontCollection())
            {
                foreach (var family in ifc.Families)
                {
                    if (family.IsStyleAvailable(FontStyle.Regular) &&
                        family.IsStyleAvailable(FontStyle.Bold) &&
                        family.IsStyleAvailable(FontStyle.Italic) &&
                        family.IsStyleAvailable(FontStyle.Underline))
                    {
                        using (var f = new Font(family.Name, 12))
                            sbFonts.Add(f.Name);
                    }
                }
            }
            return sbFonts;
        }

        public static Task<IEnumerable<string>> GetInstalledFontCollectionAsync()
        {
            var task = new Task<IEnumerable<string>>(() => GetInstalledFontCollection());
            task.Start();
            return task;
        }
    }
}
