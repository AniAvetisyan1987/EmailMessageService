using System.Net.Mail;
using System.Net;
using System.Xml.Linq;

namespace EmailMessageService
{
    internal class EmailClass
    {
        private const string MAIL_SENDER = "teambasic329@gmail.com";
        private const string MAIL_PASSWORD = "tentikgwsgijqaqx";
        private const string MAIL_FROM = "teambasic329@gmail.com";
        public static string getHtml(Dictionary<string, string> data)
        {
            try
            {
                string message = "<font>Hi dear user: </font><br><br>";
                if (data.Count == 0) return message;
                string htmlBody = "Hi dear " + data["name"] + "" + data["surname"] + ".";
                message += htmlBody;
                return message;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public static void Email(string to, string mail_subject, string mail_message)
        {
            try
            {
                var stmp = new SmtpClient();
                {
                    stmp.Host = "smtp.gmail.com";
                    stmp.Port = 587;
                    stmp.EnableSsl = true;
                    stmp.DeliveryMethod = SmtpDeliveryMethod.Network;
                    stmp.Credentials = new NetworkCredential(MAIL_SENDER, MAIL_PASSWORD);
                    stmp.Timeout = 20000;
                }
                stmp.Send(MAIL_FROM, to, mail_subject, mail_message);
            }
            catch (Exception)
            {
                //Console.WriteLine("CATCH");
            }
        }
    }
}
