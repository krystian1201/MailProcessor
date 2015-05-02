
using System;

using Microsoft.Exchange.WebServices.Data;


namespace MailProcessor.Lib
{

    class CMessage : IMessage
    {
        //original e-mail message (from EWS managed API)
        private readonly Microsoft.Exchange.WebServices.Data.Item _originalEmailMessage;

        public CMessage(Microsoft.Exchange.WebServices.Data.Item originalEmailMessage)
        {
            _originalEmailMessage = originalEmailMessage;
            Subject = originalEmailMessage.Subject;


            //TODO: sth's wrong with this construction
            try
            {
                Body = originalEmailMessage.Body;
            }
            catch (Microsoft.Exchange.WebServices.Data.ServiceObjectPropertyException)
            {
                
            }
    
        }

        #region IMessage members

        public string EntryId
        {
            get { return _originalEmailMessage.Id.UniqueId; }
        }

        public string Subject
        {
            get { return _originalEmailMessage.Subject; }
            set { _originalEmailMessage.Subject = value; }
        }

        public string Body
        {
            get { return _originalEmailMessage.Body; }
            set { _originalEmailMessage.Body = value; }
        }

        public void Update()
        {
            _originalEmailMessage.Update(ConflictResolutionMode.AlwaysOverwrite);
        }

        public void Delete()
        {
            _originalEmailMessage.Delete(DeleteMode.MoveToDeletedItems);
        }

        public void MarkAsSpam()
        {
            _originalEmailMessage.Subject = String.Format("[SPAM] {0}", this.Subject);
            Update();
        }

        #endregion
    }
}
