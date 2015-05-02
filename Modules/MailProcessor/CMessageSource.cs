
using System.Collections.Generic;
using System.Linq;

using Microsoft.Exchange.WebServices.Data;


namespace MailProcessor.Lib
{
    /// <summary>
    /// Źródło wiadomości.
    /// </summary>
    public class CMessageSource : IMessageSource
    {
        private readonly Folder _inbox;

        public CMessageSource(Folder inbox)
        {
            _inbox = inbox;
        }

        public IMessage Find(string strMessageId)
        {

            EmailMessage emailMessage = EmailMessage.Bind(_inbox.Service, new ItemId(strMessageId));

            return new CMessage(emailMessage);
        }

        public IEnumerable<IMessage> GetAll()
        {
            return _inbox.FindItems(new ItemView(100)).Cast<EmailMessage>().Select(message => new CMessage(message));
        }
    }
}
