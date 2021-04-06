using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;           //*async
using System.Net.Mail;                  //*smtp client
using System.Net;                       //*Network Credential
using System.Windows;
//using Windows.ApplicationModel.Email;   //*email
using Windows.Foundation;

namespace AbschlussprojektIHK
{
    public static class clsEmail

    {

        //============< clsEmail >============

        public static bool send_Email(string sTitle, string sText)

        {
            //------------< send_Email() >------------

            //send email with uwp and smtp-server

            //< email >

            MailMessage email = new MailMessage();

            email.To.Add("felwanew@outlook.de");

            email.From = new MailAddress("Searchagent");

            email.Subject = sTitle;

            email.Body = sText;

            //</ email >



            //< email-server >

            SmtpClient client = new SmtpClient();

            //client.Host = app_settings._Smtp_Server;

            client.UseDefaultCredentials = false;

            client.DeliveryMethod = SmtpDeliveryMethod.Network;

            //< no ssl >

            client.Port = 25;

            client.EnableSsl = false;

            //</ no ssl >



            //< ssl >

            //*securesmpt.t-online.de

            //client.Port = 587;

            //client.EnableSsl = true;

            //</ ssl >

            //client.Credentials = new NetworkCredential(app_settings._Smtp_User, app_settings._Smtp_Password);

            //</ email-server >



            //< send >

            //await client.SendMailAsync(email);      //*no error message

            client.Send(email);                       //*with error message

            //</ send >



            return true;

            //------------</ send_Email() >------------

        }

        //============</ clsEmail >============

    }
}