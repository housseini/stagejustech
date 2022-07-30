using justch.Models.ENTITIES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

using System.Threading.Tasks;
using EASendMail;

namespace justch.Models.Service
{
    public class EmailConfiguration
    {


        public static string From = "JustechStatigiaire@yahoo.com";
        public static string SmtpServer = "smtp.mail.yahoo.com";
        public static int Port = 465;
        public static string Username = "JustechStatigiaire@yahoo.com";
        public static string Password = "Bako4560";
        private string To { get; set; }
        private string subjet { get; set; }

        private string content { get; set; }
        public static Message sendmessage(string adresse ,string subjet, string contente) {

            try
            {
                SmtpMail oMail = new SmtpMail("TryIt");
                oMail.From = From;

                // Set recipient email address
                oMail.To = adresse;

                // Set email subject
                oMail.Subject = subjet;

                // Set email body
                oMail.TextBody = contente;

                // Yahoo SMTP server address
                SmtpServer oServer = new SmtpServer("smtp.mail.yahoo.com");

                // For example: your email is "myid@yahoo.com", then the user should be "myid@yahoo.com"
                oServer.User = Username;
                oServer.Password = Password;


                // Because yahoo deploys SMTP server on 465 port with direct SSL connection.
                // So we should change the port to 465. you can also use 25 or 587
                oServer.Port = 465;

                // detect SSL type automatically
                oServer.ConnectType = SmtpConnectType.ConnectSSLAuto;

                Console.WriteLine("start to send email over SSL ...");

                SmtpClient oSmtp = new SmtpClient();
                oSmtp.SendMail(oServer, oMail);

                Console.WriteLine("email was sent successfully!");

                return new Message(true, "meail envoiee");

            }
            catch (Exception e)
            {
                return new Message(false, e.Message);
            }
        }


    }
}
