using EditorModel.Figures;
using EditorModel.Selections;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace SimpleEditor.Commands
{
    public class LayerChangingCommand : ICommand
    {
        private Layer _layer;
        private readonly string _commandName;
        private byte[] _buff;

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
            using (var ms = new MemoryStream())
            {
                new BinaryFormatter().Serialize(ms, _layer);
                _buff = ms.GetBuffer();
            }
        }

        public void UnExecute()
        {
            using (var fs = new MemoryStream(_buff, false))
                _layer = (Layer)new BinaryFormatter().Deserialize(fs);
        }
    }
}
