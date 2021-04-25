using System;
using System.Net;                       //Network Credential
using System.Net.Mail;                  //smtp client
using System.Threading.Tasks;           //async

namespace AbschlussprojektIHK
{
    public static class ClsEmail
    {
        //============< ClsEmail >============
        public static async Task<bool> Send_EmailAsync(string sTitle, string sText)
        {
            //init + declaration of User from JSON
            User user = JSON.ReadUser();

            //------------< send_Email() >------------

            //send email with uwp and smtp-server

            //< email >

            MailMessage email = new MailMessage();

            email.To.Add(user.MailOfInstructor);            //mail of instructor

            email.From = new MailAddress(user.EmailUser);     //mail of referee

            email.Subject = sTitle;

            email.Body = sText;

            //</ email >



            //< email-server >

            SmtpClient client = new SmtpClient();
            try
            {
                client.Host = "smtp-mail.outlook.com"; //Smtp Server
            }
            catch (ArgumentException e)
            {
                Console.Error.WriteLine(e);
            }


            client.UseDefaultCredentials = false;

            client.DeliveryMethod = SmtpDeliveryMethod.Network;

            //< ssl >

            client.Port = 587;

            client.EnableSsl = true;

            //</ ssl >

            client.Credentials = new NetworkCredential(user.EmailUser, user.Password);   //Usermail, Userpassword for Mailaccount --> definied in JSON

            //</ email-server >



            //< send >

            await client.SendMailAsync(email);      //*no error message

            //client.Send(email);                   //*with error message

            //</ send >



            return true;

            //------------</ send_Email() >------------

        }

        //============</ ClsEmail >============

    }
}