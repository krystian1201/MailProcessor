
using System;

using MailProcessor.Lib;

namespace MailProcessor
{
    internal class CCommandExecutor : ICommandExecutor
    {
        private readonly IMessageSource _messageSource;

        public CCommandExecutor(IMessageSource messageSource)
        {
            _messageSource = messageSource;
        }

        #region ICommandExecutor Members

        public void Execute(ICommand command, IMessage message)
        {
            if (command is CCommandDelete)
            {
                _messageSource.Find(message.EntryId).Delete();
            }
            else if(command is CCommandMarkAsSpam)
            {
                _messageSource.Find(message.EntryId).MarkAsSpam();
            }
            else if (command is CCommandSkip)
            {
            }
            else
            {
                throw new ArgumentException(String.Format("Invalid command ({0}) was passed to execute", command.GetType()));
            }

        }

        #endregion
    }
}
