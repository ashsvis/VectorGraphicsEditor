using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EditorModel.Figures;

namespace SimpleEditor.Controllers
{
    class UndoRedoController
    {
        private Layer snapshot;
        private Layer layer;
        private string operationName;

        public void OnStartOperation(Layer layer, string operationName)
        {
            this.layer = layer;
            snapshot = ObjectCloner.DeepClone(layer);
            this.operationName = operationName;
        }

        public void OnFinishOperation()
        {
            var afterOperationSnapshot = ObjectCloner.DeepClone(layer);
            var beforeOperationSnapshot = snapshot;//capture variable

            Action undo = () =>
            {
                layer.Figures = ObjectCloner.DeepClone(beforeOperationSnapshot).Figures;
            };

            Action redo = () =>
            {
                layer.Figures = ObjectCloner.DeepClone(afterOperationSnapshot).Figures;
            };

            UndoRedoManager.Instance.Add(new ActionCommand(undo, redo){Name = operationName});
        }
    }
}
