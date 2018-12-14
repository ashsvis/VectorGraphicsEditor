using EditorModel.Figures;
using EditorModel.Selections;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;

namespace EditorModel.Common
{
    public static class SaverLoader
    {
        public static Layer LoadFromFile(string fileName)
        {
            using (var fs = File.OpenRead(fileName))
            using (var zip = new GZipStream(fs, CompressionMode.Decompress))
            {
                var formatter = new BinaryFormatter();
                var versionInfo = (VersionInfo)formatter.Deserialize(zip);
                if (versionInfo.Version > Helper.GetVersionInfo().Version)
                    throw new Exception(@"Формат загружаемого файла не поддерживается.");
                return (Layer)formatter.Deserialize(zip);
            }
        }

        /// <summary>
        /// Метод загрузки списка фигур из файла на диске
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static List<Figure> LoadSelection(string fileName)
        {
            var layer = LoadFromFile(fileName);
            var selection = new Selection();
            foreach (var fig in layer.Figures)
                selection.Add(fig);
            var location = selection.GetTransformedPath().Path.GetBounds().Location;
            selection.Translate(-location.X, -location.Y);
            selection.PushTransformToSelectedFigures();
            return layer.Figures;
        }

        ///// <summary>
        ///// Метод записи фигур из списка выделенных в файл
        ///// </summary>
        ///// <param name="fileName"></param>
        //public static void SaveSelection(string fileName, Selection selection)
        //{
        //    if (selection.Count == 0) return;
        //    if (File.Exists(fileName)) File.Delete(fileName);
        //     var sel = selection.DeepClone();
        //    var location = sel.GetTransformedPath().Path.GetBounds().Location;
        //    sel.Translate(-location.X, -location.Y);
        //    sel.PushTransformToSelectedFigures();
        //    using (var fs = File.OpenWrite(fileName))
        //    using (var zip = new GZipStream(fs, CompressionMode.Compress))
        //    {
        //        var formatter = new BinaryFormatter();
        //        formatter.Serialize(zip, Helper.GetVersionInfo());
        //        formatter.Serialize(zip, sel.ToList());
        //    }
        //}

        /// <summary>
        /// Метод записи всех фигур в слое в файл
        /// </summary>
        /// <param name="fileName"></param>
        public static void SaveToFile(string fileName, Layer layer)
        {
            if (File.Exists(fileName)) File.Delete(fileName);
            using (var fs = File.OpenWrite(fileName))
            using (var zip = new GZipStream(fs, CompressionMode.Compress))
            {
                var formatter = new BinaryFormatter();
                formatter.Serialize(zip, Helper.GetVersionInfo());
                formatter.Serialize(zip, layer);
            }
        }
    }
}
