

using System.Collections.Generic;
using System.Linq;

using MailProcessor.Lib;

namespace Tests.MailProcessor.UnitTests
{
    class CFakeMessageSource : IMessageSource
    {
        private readonly List<IMessage> _messages;

        public CFakeMessageSource(IEnumerable<IMessage> messages)
        {
            _messages = new List<IMessage>(messages);
        }

        #region IMessageSource Members

        public IMessage Find(string strMessageId)
        {
            return _messages.FirstOrDefault(message => message.EntryId == strMessageId);
        }

        public IEnumerable<IMessage> GetAll()
        {
            return _messages;
        }

        #endregion
    }
}
