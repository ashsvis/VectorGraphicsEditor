using System;
using System.Drawing.Drawing2D;
using System.Runtime.Serialization;

namespace EditorModel
{
    [Serializable]
    public class SerializableGraphicsMatrix : ISerializable
    {
        public Matrix Matrix = new Matrix();

        public SerializableGraphicsMatrix() { }

        protected SerializableGraphicsMatrix(SerializationInfo info, StreamingContext context)
        {
            if (info.MemberCount == 1)
            {
                var el = (float[])info.GetValue("e", typeof(float[]));
                Matrix = new Matrix(el[0], el[1], el[2], el[3], el[4], el[5]);
            }
            else
                Matrix = new Matrix();
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            if (Matrix.Elements.Length <= 0) return;
            info.AddValue("e", Matrix.Elements);
        }

        public static implicit operator Matrix(SerializableGraphicsMatrix matrix)
        {
            return matrix.Matrix;
        }

        public static implicit operator SerializableGraphicsMatrix(Matrix matrix)
        {
            return new SerializableGraphicsMatrix { Matrix = matrix };
        }
    }

}
