using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace SimpleEditor
{
    public static class CursorsBuilder
    {
        static Dictionary<string, Cursor> cursors;

        /// <summary>
        /// Статический конструктор загружает все требуемые курсоры
        /// </summary>
        static CursorsBuilder()
        {
            cursors = new Dictionary<string, Cursor>();
            AddCursor("rotate", Properties.Resources.rotate);
            // добавлять курсоры здесь
        }

        /// <summary>
        /// Добавить курсор из ресурсов программы
        /// </summary>
        /// <param name="name"></param>
        /// <param name="source"></param>
        private static void AddCursor(string name, byte[] source)
        {
            using (var stream = new MemoryStream(source))
                cursors.Add(name, new Cursor(stream));
        }

        /// <summary>
        /// Взять подготовленный курсор из словаря
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static Cursor GetCursor(string name)
        {
            return cursors.ContainsKey(name) ? cursors[name] : Cursors.No;
        }
    }
}
