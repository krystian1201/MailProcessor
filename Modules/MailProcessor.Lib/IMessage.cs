

namespace MailProcessor.Lib
{
    /// <summary>
    /// Reprezentuje wiadomość
    /// </summary>
    public interface IMessage
    {
        /// <summary>
        /// Identyfikator
        /// </summary>
        /// id 
        string EntryId { get; }

        /// <summary>
        /// Temat
        /// </summary>
        string Subject { get; set; }

        /// <summary>
        /// Treść
        /// </summary>
        string Body { get; set; }

        /// <summary>
        /// Aktualizuje wiadomość
        /// </summary>
        void Update();

        /// <summary>
        /// Usuwa wiadomość
        /// </summary>
        void Delete();

        /// <summary>
        /// Oznacza wiadomość jako spam
        /// </summary>
        void MarkAsSpam();
    }
}
