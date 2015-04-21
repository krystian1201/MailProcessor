
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MailProcessor;
using MailProcessor.Lib;

namespace Tests.MailProcessor.UnitTests
{
    [TestClass]
    public class CTestCommandFinder
    {
        [TestMethod]
        public void CommandFinder_ShouldReturnSkipAction()
        {
            CFakeMessage fakeMessage = new CFakeMessage("1", "Normal message", "Normal message body");
            CFakeMessageSource fakeMessageSource = new CFakeMessageSource(new IMessage[] { fakeMessage });

            ICommandFinder commandFinder = new CCommandFinder(fakeMessageSource);
            ICommand command = commandFinder.GetCommand(fakeMessage.EntryId);

            Assert.IsInstanceOfType(command, typeof(CCommandSkip), "Message should be skipped");
        }

        [TestMethod]
        public void CommandFinder_ShouldReturnDeleteAction()
        {
            CFakeMessage fakeMessage = new CFakeMessage("1", "[DELETEME] Message subject", "Normal message body");
            CFakeMessageSource fakeMessageSource = new CFakeMessageSource(new IMessage[] { fakeMessage });

            ICommandFinder commandFinder = new CCommandFinder(fakeMessageSource);
            ICommand command = commandFinder.GetCommand(fakeMessage.EntryId);

            Assert.IsInstanceOfType(command, typeof(CCommandDelete), "Message should be deleted");
        }

        [TestMethod]
        public void CommandFinder_ShouldReturnMarkMessageAsSpamAction()
        {
            CFakeMessage fakeMessage = new CFakeMessage("1", "Test message", "Body BUY OUR CHEAP PRODUCT");
            CFakeMessageSource fakeMessageSource = new CFakeMessageSource(new IMessage[] { fakeMessage });

            ICommandFinder commandFinder = new CCommandFinder(fakeMessageSource);
            ICommand command = commandFinder.GetCommand(fakeMessage.EntryId);

            Assert.IsInstanceOfType(command, typeof(CCommandMarkAsSpam), "Message should be marked as spam");
        }
        
    }
}
