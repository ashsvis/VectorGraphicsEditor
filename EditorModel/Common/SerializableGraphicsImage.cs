using System;
using System.Drawing;
using System.IO;
using System.Runtime.Serialization;

namespace EditorModel.Common
{
    [Serializable]
    public sealed class SerializableGraphicsImage : ISerializable, IDisposable
    {
        public Image Image;

        public SerializableGraphicsImage() { }

        private SerializableGraphicsImage(SerializationInfo info, StreamingContext context)
        {
            if (info.MemberCount == 1)
            {
                var bytes = (byte[])info.GetValue("m", typeof(byte[]));
                using (var m = new MemoryStream(bytes))
                {
                    Image = Image.FromStream(m);
                }
            }
            else
                Image = null;
        }

        ~SerializableGraphicsImage()
        {
            Dispose();
        }

        public void Dispose()
        {
            if (Image != null) Image.Dispose();
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            if (Image == null) return;
            using (var m = new MemoryStream())
            {
                Image.Save(m, Image.RawFormat);
                info.AddValue("m", m.ToArray());
            }
        }

        public static implicit operator Image(SerializableGraphicsImage image)
        {
            return image.Image;
        }

        public static implicit operator SerializableGraphicsImage(Image image)
        {
            return new SerializableGraphicsImage { Image = image };
        }
    }
}
