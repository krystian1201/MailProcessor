
using MailProcessor.Lib;
using System.Collections.Generic;


namespace Tests.MailProcessor.UnitTests
{
    class CFakeCommandExecutor : ICommandExecutor
    {
        public Dictionary<IMessage, ICommand> ExecutedActions;

        public CFakeCommandExecutor()
        {
            ExecutedActions = new Dictionary<IMessage, ICommand>();
        }

        #region ICommandExecutor Members

        public void Execute(ICommand command, IMessage message)
        {
            ExecutedActions.Add(message, command);
        }

        #endregion
    }
}
