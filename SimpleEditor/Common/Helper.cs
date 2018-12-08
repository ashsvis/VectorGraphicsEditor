using EditorModel.Figures;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Runtime.Serialization.Formatters.Binary;

namespace SimpleEditor.Common
{
    static class Helper
    {
// ReSharper disable InconsistentNaming
        public const float EPSILON = 0.01f;
// ReSharper restore InconsistentNaming

        /// <summary>
        /// Расчёт коэффициента масштабирования
        /// </summary>
        /// <param name="marker">Точка маркера</param>
        /// <param name="anchor">Точка якоря</param>
        /// <param name="mouse">Положение мышки</param>
        /// <returns></returns>
        public static float GetScale(PointF marker, PointF anchor, PointF mouse)
        {
            var a = marker.Sub(anchor); // строим вектор Anchor-Marker
            var m = mouse.Sub(anchor);  // строим вектор Anchor-Mouse(position)
            // считаем коэффициент
            var scale = m.DotScalar(a) / a.LengthSqr();
            // защита результата от "крайних" случаев расчёта
            if (Math.Abs(scale) < EPSILON) scale = EPSILON;
            return scale;
        }

        /// <summary>
        /// Расчет угла вращения (в градусах)
        /// </summary>
        /// <param name="marker">Точка маркера</param>
        /// <param name="anchor">Точка якоря</param>
        /// <param name="mouse">Положение мышки</param>
        /// <returns></returns>
        public static float GetAngle(PointF marker, PointF anchor, PointF mouse)
        {
            var a = marker.Sub(anchor);
            var m = mouse.Sub(anchor);
            return m.Angle(a) * PointFExtension.TO_DEGREES;
        }

        public static void Compress(Stream sourceStream, string compressedFile)
        {
            // поток для записи сжатого файла
            using (FileStream targetStream = File.Create(compressedFile))
            {
                // поток архивации
                using (GZipStream compressionStream = new GZipStream(targetStream, CompressionMode.Compress))
                {
                    sourceStream.CopyTo(compressionStream); // копируем байты из одного потока в другой
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="compressedFile"></param>
        /// <param name="targetStream">поток для записи восстановленного файла</param>
        public static void Decompress(string compressedFile, Stream targetStream)
        {
            // поток для чтения из сжатого файла
            using (FileStream sourceStream = new FileStream(compressedFile, FileMode.OpenOrCreate))
            {
                // поток разархивации
                using (GZipStream decompressionStream = new GZipStream(sourceStream, CompressionMode.Decompress))
                {
                    decompressionStream.CopyTo(targetStream);
                }
            }
        }

        /// <summary>
        /// Сохранить все фигуры в поток
        /// </summary>
        /// <param name="stream">поток в памяти</param>
        /// <param name="listToSave">список для сохранения</param>
        public static void SaveToStream(Stream stream, object obj)
        {
            var formatter = new BinaryFormatter();
            formatter.Serialize(stream, obj);
            //stream.Position = 0;
        }

        /// <summary>
        /// Восстановить фигуры из потока в памяти
        /// </summary>
        /// <param name="stream"></param>
        /// <returns></returns>
        public static object LoadFromStream(Stream stream)
        {
            var formatter = new BinaryFormatter();
            //stream.Position = 0;
            return formatter.Deserialize(stream);
        }
    }
}