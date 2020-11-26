using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace TruckDriverApp.Services
{
    public class SendMail
    {
            static string smtpAddress = "smtp.gmail.com";
            static int portNumber = 587;
            static bool enableSSL = true;
            static string emailFromAddress = "whereamiparking@gmail.com"; //Sender Email Address  




            public static void SendEmail(string emailToAddress, string subject, string body)
            {
                using (SmtpClient client = new SmtpClient(smtpAddress, portNumber))
                {
                    client.Credentials = new NetworkCredential(emailFromAddress, PrivateInfo.emailPassword);
                    client.EnableSsl = enableSSL;
                    MailMessage eMail = new MailMessage(emailFromAddress, emailToAddress, subject, body);
                    client.Send(eMail);
                }
            }
        
    }
}
