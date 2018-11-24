using System;
using EditorModel.Figures;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleEditor.Commands
{
    public class AddFigure : ICommand
    {
        private readonly Layer _layer;
        private readonly Figure _figure;

        public AddFigure(Layer layer, Figure figure)
        {
            _layer = layer;
            _figure = figure;
        }

        public string Name { get { return "Создать фигуру"; } }

        public void Execute()
        {
            _layer.Figures.Add(_figure);
        }

        public void UnExecute()
        {
            _layer.Figures.Remove(_figure);
        }
    }
}
