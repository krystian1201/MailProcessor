
using System;

using MailProcessor.Lib;


namespace Tests.MailProcessor.UnitTests
{
    class CFakeCommandFinder : ICommandFinder
    {
        private readonly Func<string, ICommand> _funcGetCommand;

        public CFakeCommandFinder(Func<string, ICommand> funcGetCommand)
        {
            _funcGetCommand = funcGetCommand;
        }

        #region ICommandFinder Members

        public ICommand GetCommand(string strMessageId)
        {
            return _funcGetCommand(strMessageId);
        }

        #endregion
    }
}
