namespace SimpleEditor.Commands
{
    /// <summary>
    /// Интерфейс для команд
    /// </summary>
    public interface ICommand
    {
        string Name { get; }
        void Execute();
        void UnExecute();
    }
}
