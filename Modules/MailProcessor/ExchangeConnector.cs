
using Microsoft.Exchange.WebServices.Data;
using System;
using System.Net;


namespace MailProcessor
{
    public class ExchangeConnector
    {
        /// <summary>
        /// Create an EWS object connected to specific mailbox
        /// </summary>
        /// <remarks>
        /// Usage:
        /// ExchangeService service = ExchangeConnection.Connect("mail@c2dev.onmicrosoft.com", "password18#");
        /// </remarks>
        /// <param name="strEmailAddress">Mailbox user email address</param>
        /// <param name="strPassword">Mailbox user password</param>
        /// <returns>An EWS object connected to specific mailbox</returns>
        public static ExchangeService Connect(String strEmailAddress, String strPassword)
        {
            ExchangeService service = new ExchangeService(ExchangeVersion.Exchange2010_SP2)
            {
                TraceEnabled = false,
                TraceFlags = TraceFlags.None,
                TraceListener = null,
                Credentials = new NetworkCredential(strEmailAddress, strPassword),
                Url = new Uri(@"https://outlook.office365.com/EWS/Exchange.asmx")
            };

            // Specify user credentials
            // Use Office 365 Autodiscover URL
            //service.AutodiscoverUrl(strEmailAddress, RedirectionUrlValidationCallback);
            return service;
        }


        /// <summary>
        /// Redirection callback used in Autodiscovery
        /// </summary>
        /// <param name="strRedirectionUrl"></param>
        /// <returns></returns>
        private static bool RedirectionUrlValidationCallback(String strRedirectionUrl)
        {
            Uri url = new Uri(strRedirectionUrl);
            return url.Scheme == "https";
        }
    }
}
