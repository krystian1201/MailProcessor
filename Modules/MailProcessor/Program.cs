

using MailProcessor.Lib;
using MailProcessor.Lib.Exchange;
using Microsoft.Exchange.WebServices.Data;


namespace MailProcessor
{
    class Program
    {
        static void Main(string[] args)
        {

            ExchangeService exchangeService = ExchangeConnector.Connect("user5@c2dev.onmicrosoft.com", "butelka100#");
            Folder inbox = Folder.Bind(exchangeService, WellKnownFolderName.Inbox);

            IMessageSource messageSource = new CMessageSource(inbox);
            ICommandExecutor commandExecutor = new CCommandExecutor(messageSource);
            ICommandFinder commandFinder = new CCommandFinder(messageSource);

            CMessagesProcessor messagesProcessor = new CMessagesProcessor(messageSource, commandFinder, commandExecutor);


            messagesProcessor.Proceed();

        }
    }
}
