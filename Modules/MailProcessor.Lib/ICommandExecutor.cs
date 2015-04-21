

namespace MailProcessor.Lib
{
    /// <summary>
    /// Wykonywacz komend na wiadomościach
    /// </summary>
    public interface ICommandExecutor
    {
        /// <summary>
        /// Wykonuje akcję na zadanej wiadomości
        /// </summary>
        /// <param name="command">akcja do wykonania</param>
        /// <param name="message">wiadomość, na której akcja ma zostać wykonana</param>
        // <param name="source">źródło wiadomości</param>
        void Execute(ICommand command, IMessage message);
    }
}
