
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

using MailProcessor.Lib;


namespace MailProcessor
{
    class CCommandFinder : ICommandFinder
    {
        private readonly IMessageSource _messageSource;
        private IMessage _message;

        public CCommandFinder(IMessageSource messageSource)
        {
            _messageSource = messageSource;
        }

        #region ICommandFinder Members

        public ICommand GetCommand(string strMessageId)
        {
            if (String.IsNullOrEmpty(strMessageId))
            {
                throw new ArgumentException("No message ID was passed to method");
            }

            _message = _messageSource.Find(strMessageId);

            if (_message.Subject.StartsWith("[DELETEME]"))
            {
                return new CCommandDelete();
            }

            if (IsMessageSpam())
            {
                return new CCommandMarkAsSpam();
            }

            return new CCommandSkip();
        }

        #endregion

        private bool IsMessageSpam()
        {
            CultureInfo cultureInfo = CultureInfo.CreateSpecificCulture("en-US");
            List<string> spamWords = new List<string>(){"buy", "cheap"};

            

            if (spamWords.Any(spamWord =>
                        cultureInfo.CompareInfo.IndexOf(_message.Subject, spamWord, CompareOptions.IgnoreCase) >= 0 ||
                        cultureInfo.CompareInfo.IndexOf(_message.Body, spamWord, CompareOptions.IgnoreCase) >= 0))
            {
                return true;
            }

            return false;
        }
    }
}
