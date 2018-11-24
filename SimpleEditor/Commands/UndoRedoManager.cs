using System;
using System.Collections.Generic;

namespace SimpleEditor.Commands
{
    public class UndoRedoEventArgs : EventArgs
    {
        public int UndoCount { get; set; }
        public int RedoCount { get; set; }
    }

    public delegate void UndoRedoEventHandler(UndoRedoManager sender, UndoRedoEventArgs e);

    /// <summary>
    /// Управляющий класс отменой и возвратом действий
    /// от Storm23
    /// </summary>
    public class UndoRedoManager
    {
        Stack<ICommand> UndoStack { get; set; }
        Stack<ICommand> RedoStack { get; set; }

        public UndoRedoManager()
        {
            UndoStack = new Stack<ICommand>();
            RedoStack = new Stack<ICommand>();
        }

        public event UndoRedoEventHandler StateChanged;

        private void OnStateChanged()
        {
            if (StateChanged != null)
                StateChanged(this, new UndoRedoEventArgs
                {
                    UndoCount = UndoStack.Count,
                    RedoCount = RedoStack.Count
                });
        }

        public void Undo()
        {
            if (UndoStack.Count > 0)
            {
                //изымаем команду из стека
                var command = UndoStack.Pop();
                //отменяем действие команды
                command.UnExecute();
                //заносим команду в стек Redo
                RedoStack.Push(command);
                //сигнализируем об изменениях
                OnStateChanged();
            }
        }

        public void Redo()
        {
            if (RedoStack.Count > 0)
            {
                //изымаем команду из стека
                var command = RedoStack.Pop();
                //выполняем действие команды
                command.Execute();
                //заносим команду в стек Undo
                UndoStack.Push(command);
                //сигнализируем об изменениях
                OnStateChanged();
            }
        }

        //выполняем команду
        public void Execute(ICommand command)
        {
            //выполняем команду
            command.Execute();
            //заносим в стек Undo
            UndoStack.Push(command);
            //очищаем стек Redo
            RedoStack.Clear();
            //сигнализируем об изменениях
            OnStateChanged();
        }
    }
}
