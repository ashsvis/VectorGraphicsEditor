using System;
using System.Collections.Generic;
using EditorModel.Figures;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace SimpleEditor.Commands
{
    public class LayerChangingCommand : ICommand
    {
        private readonly Layer _layer;
        private readonly string _commandName;
        private List<Figure> _saved;

        public LayerChangingCommand(Layer layer, string commandName)
        {
            _layer = layer;
            _commandName = commandName;
        }

        public string Name
        {
            get { return _commandName; }
        }

        public void Execute()
        {
            _saved = CopyFigures(_layer.Figures);
            Console.WriteLine("Execute");
        }

        private static List<Figure> CopyFigures(List<Figure> list)
        {
            byte[] buff;
            using (var ms = new MemoryStream())
            {
                new BinaryFormatter().Serialize(ms, list);
                buff = ms.GetBuffer();
            }
            using (var fs = new MemoryStream(buff, false))
                return (List<Figure>)new BinaryFormatter().Deserialize(fs);
        }

        public void UnExecute()
        {
            _layer.Figures = CopyFigures(_saved);
            Console.WriteLine("UnExecute");
        }
    }
}
