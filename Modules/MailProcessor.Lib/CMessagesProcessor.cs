
using System;
using System.Collections.Generic;


namespace MailProcessor.Lib
{
    /// <summary>
    /// Główny procesor wiadomości. Odpowiada za przetworzenie wiadomosci pobranych ze źródła wiadomości
    /// </summary>
    public class CMessagesProcessor
    {
        private readonly IMessageSource _messageSource;
        private readonly ICommandFinder _commandFinder;
        private readonly ICommandExecutor _commandExecutor;

        /// <summary>
        /// Tworzy nową instancję <see cref="CMessagesProcessor"/>
        /// </summary>
        /// <param name="messageSource">źródło wiadomości</param>
        /// <param name="commandFinder">wyszukiwacz akcji</param>
        /// <param name="commandExecutor">wykonywacz akcji</param>
        public CMessagesProcessor(IMessageSource messageSource, ICommandFinder commandFinder, ICommandExecutor commandExecutor)
        {
            _messageSource = messageSource;
            _commandFinder = commandFinder;
            _commandExecutor = commandExecutor;
        }

        /// <summary>
        /// Procesuje wiadomości znajdujące się w źródle. Sprawdza jakie akcje należy wykonać na wiadomościach
        /// i wykonuje je przy użyciu zadanego wykonywacza
        /// </summary>
        public void Proceed()
        {
            IEnumerable<IMessage> messages = _messageSource.GetAll();

            foreach (IMessage message in messages)
            {
                ICommand command = _commandFinder.GetCommand(message.EntryId);
                _commandExecutor.Execute(command, message);

                Console.WriteLine(String.Format("Action {0} on message \"{1}\"", command.GetType(), message.Subject));
            }
        }
    }
}
