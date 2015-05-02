
using System;

using MailProcessor.Lib;


namespace Tests.MailProcessor.UnitTests
{
    class CFakeMessage : IMessage
    {
        public CFakeMessage(string strEntryId, string strSubject, string strBody)
        {
            EntryId = strEntryId;
            Subject = strSubject;
            Body = strBody;
        }
        #region IMessage Members

        public string EntryId
        {
            get;
            private set;
        }

        public string Subject
        {
            get;
            set;
        }

        public string Body
        {
            get;
            set;
        }

        internal bool IsDeleted
        {
            get;
            private set;
        }

        internal bool IsUpdated
        {
            get;
            private set;
        }

        public void Update()
        {
            IsUpdated = true;
        }

        public void Delete()
        {
            IsDeleted = true;
        }

        public void MarkAsSpam()
        {
            Subject = String.Format("[SPAM] {0}", Subject);
            IsUpdated = true;
        }

        #endregion

    }
}
