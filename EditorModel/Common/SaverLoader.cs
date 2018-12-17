using EditorModel.Figures;
using EditorModel.Selections;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
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
                if (versionInfo.Version > VersionInfo.DEFAULT_VERSION)
                    throw new Exception(@"Формат загружаемого файла не поддерживается.");
                return (Layer)formatter.Deserialize(zip);
            }
        }

        /// <summary>
        /// Метод загрузки списка фигур из файла на диске
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static IEnumerable<Figure> LoadSelection(string fileName)
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

        /// <summary>
        /// Метод записи всех фигур в слое в файл
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="layer"></param>
        public static void SaveToFile(string fileName, Layer layer)
        {
            using (var fs = File.Create(fileName))
            using (var zip = new GZipStream(fs, CompressionMode.Compress))
            {
                var formatter = new BinaryFormatter();
                formatter.Serialize(zip, new VersionInfo());
                formatter.Serialize(zip, layer);
            }
        }
    }
}
