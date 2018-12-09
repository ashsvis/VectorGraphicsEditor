using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.Serialization;

namespace EditorModel.Common
{
    [Serializable]
    public sealed class SerializableGraphicsImage : ISerializable, IDisposable
    {
        public Image Image; // = new Bitmap(1, 1);

        public SerializableGraphicsImage() { }

        private SerializableGraphicsImage(SerializationInfo info, StreamingContext context)
        {
            if (info.MemberCount == 1)
            {
                var base64String = (string)info.GetValue("raw", typeof(string));
                byte[] imageBytes = Convert.FromBase64String(base64String);
                using (MemoryStream m = new MemoryStream(imageBytes))
                {
                    Image = Image.FromStream(m);
                }
            }
            else
                Image = null; //  new Bitmap(1, 1);
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
            if (Image == null || Image.PixelFormat == PixelFormat.DontCare) return;
            var rawFormat = Image.RawFormat;
            using (MemoryStream m = new MemoryStream())
            {
                Image.Save(m, rawFormat);
                byte[] imageBytes = m.ToArray();
                // Convert byte[] to Base64 String
                string base64String = Convert.ToBase64String(imageBytes);
                info.AddValue("raw", base64String);
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
