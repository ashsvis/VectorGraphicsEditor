using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace SimpleEditor.Common
{
    public enum UserCursor
    {
        Rotate,
// ReSharper disable InconsistentNaming
        SizeNWSE,
        SizeNESW,
        SizeWE,
        SizeNS,
        SizeAll,
// ReSharper restore InconsistentNaming
        MoveAll,
        SelectByRibbonRect,
        CreateRect,
        CreateEllipse,
        SkewHorizontal,
        SkewVertical,
        AddVertex,
        RemoveVertex,
        MoveVertex
    }

    public static class CursorFactory
    {
        static readonly Dictionary<UserCursor, Cursor> UserCursors;

        /// <summary>
        /// Статический конструктор загружает все требуемые курсоры
        /// </summary>
        static CursorFactory()
        {
            UserCursors = new Dictionary<UserCursor, Cursor>();
            AddCursor(UserCursor.Rotate, Properties.Resources.Rotate);
            AddCursor(UserCursor.SizeNWSE, Properties.Resources.SizeNWSE);
            AddCursor(UserCursor.SizeNESW, Properties.Resources.SizeNESW);
            AddCursor(UserCursor.SizeWE, Properties.Resources.SizeWE);
            AddCursor(UserCursor.SizeNS, Properties.Resources.SizeNS);
            AddCursor(UserCursor.SizeAll, Properties.Resources.SizeAll);
            AddCursor(UserCursor.MoveAll, Properties.Resources.MoveAll);
            AddCursor(UserCursor.SelectByRibbonRect, Properties.Resources.SelectByRibbonRect);
            AddCursor(UserCursor.CreateRect, Properties.Resources.CreateRect);
            AddCursor(UserCursor.CreateEllipse, Properties.Resources.CreateEllipse);
            AddCursor(UserCursor.SkewHorizontal, Properties.Resources.SkewHorizontal);
            AddCursor(UserCursor.SkewVertical, Properties.Resources.SkewVertical);
            AddCursor(UserCursor.AddVertex, Properties.Resources.AddVertex);
            AddCursor(UserCursor.RemoveVertex, Properties.Resources.RemoveVertex);
            AddCursor(UserCursor.MoveVertex, Properties.Resources.MoveVertex);
            // добавлять курсоры здесь
        }

        /// <summary>
        /// Добавить курсор из ресурсов программы
        /// </summary>
        /// <param name="name"></param>
        /// <param name="source"></param>
        private static void AddCursor(UserCursor name, byte[] source)
        {
            using (var stream = new MemoryStream(source))
                UserCursors.Add(name, new Cursor(stream));
        }

        /// <summary>
        /// Взять подготовленный курсор из словаря
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static Cursor GetCursor(UserCursor name)
        {
            return UserCursors.ContainsKey(name) ? UserCursors[name] : Cursors.No;
        }
    }
}
