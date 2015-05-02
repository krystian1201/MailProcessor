
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using MailProcessor.Lib;
using MailProcessor;

namespace Tests.MailProcessor.UnitTests
{
    [TestClass]
    public class CTestCommandExecutor
    {
        
        [TestMethod]
        public void CommandExecutor_ShouldDeleteMessage()
        {
            CFakeMessage fakeMessage = new CFakeMessage("1", "Subject 1", "Body 1");
            CFakeMessageSource fakeMessageSource = new CFakeMessageSource(new IMessage[] { fakeMessage });

            ICommandExecutor commandExecutor = new CCommandExecutor(fakeMessageSource);
            commandExecutor.Execute(new CCommandDelete(), fakeMessage);

            Assert.IsTrue(fakeMessage.IsDeleted, "Message was not deleted");
        }

        [TestMethod]
        public void CommandExecutor_ShouldSkipMessage()
        {
            const string strExpectedSubject = "Subject 1";
            const string strExpectedBody = "Body 1";

            CFakeMessage fakeMessage = new CFakeMessage("1", strExpectedSubject, strExpectedBody);
            IMessageSource fakeMessageSource = new CFakeMessageSource(new IMessage[] { fakeMessage });

            ICommandExecutor commandExecutor = new CCommandExecutor(fakeMessageSource);
            commandExecutor.Execute(new CCommandSkip(), fakeMessage);

            Assert.AreEqual(strExpectedSubject, fakeMessage.Subject, "Subject was modified");
            Assert.AreEqual(strExpectedBody, fakeMessage.Body, "Body was modified");
        }

        [TestMethod]
        public void CommandExecutor_ShouldMarkMessageAsSpam()
        {
            const string strSubject = "Subject 1";
            string strExptectedSubject = String.Format("[SPAM] {0}", strSubject);

            CFakeMessage fakeMessage = new CFakeMessage("1", strSubject, "Body BUY OUR CHEAP PRODUCT");
            CFakeMessageSource fakeMessageSource = new CFakeMessageSource(new IMessage[] { fakeMessage });

            ICommandExecutor commandExecutor = new CCommandExecutor(fakeMessageSource);
            commandExecutor.Execute(new CCommandMarkAsSpam(), fakeMessage);

            Assert.AreEqual(strExptectedSubject, fakeMessage.Subject, "Message subject was not marked with [SPAM] prefix");
            Assert.IsTrue(fakeMessage.IsUpdated, "Message was not updated");
        }
    }
}
