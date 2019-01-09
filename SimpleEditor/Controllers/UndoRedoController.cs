using System;
using EditorModel.Common;
using EditorModel.Figures;
using SimpleEditor.Common;

namespace SimpleEditor.Controllers
{
    /// <summary>
    /// Управление операциями отмены/возврата действий
    /// </summary>
    class UndoRedoController
    {
        private Layer _snapshot;
        private readonly Layer _layer;
        private string _operationName;

        /// <summary>
        /// Конструктор запоминает рабочий слой, с которым будет работать undo/redo
        /// </summary>
        /// <param name="layer"></param>
        public UndoRedoController(Layer layer)
        {
            _layer = layer;
        }

        /// <summary>
        /// Выполняем перед началом операций изменения контента
        /// </summary>
        /// <param name="operationName"></param>
        public void OnStartOperation(string operationName)
        {
            // сначала запоминаем копию по значению рабочего слоя в локальной переменной
            _snapshot = _layer.DeepClone();
            // запоминаем также наименование операции
            _operationName = operationName;
        }

        /// <summary>
        /// Выполняем после окончания операций изменения контента
        /// </summary>
        public void OnFinishOperation()
        {
            var afterOperationSnapshot = _layer.DeepClone();
            var beforeOperationSnapshot = _snapshot; // захват переменной при выполнении тела акций

            Action undo = () =>
                {
                    _layer.Figures = beforeOperationSnapshot.DeepClone().Figures;
                };

            Action redo = () =>
                {
                    _layer.Figures = afterOperationSnapshot.DeepClone().Figures;
                };

            UndoRedoManager.Instance.Add(new ActionCommand(undo, redo) {Name = _operationName});
        }
    }
}
