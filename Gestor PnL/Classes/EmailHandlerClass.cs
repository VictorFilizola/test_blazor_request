using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gestor_PnL.Classes
{
    internal class EmailHandlerClass
    {
        //send e-mails
        public void SendEmail(string Mensagem, string ToMsg, string MessageHeader)
        {
            string to = ToMsg;
            string from = "gestor.despesas.application@bbraun.com";
            MailMessage message = new MailMessage(from, to);

            message.Subject = MessageHeader;
            message.Body = Mensagem;
            SmtpClient client = new SmtpClient(@"smtp.bbmag.bbraun.com");
            client.Port = 25;

            //the credentials are necessary in order for the client to be authenticated if the server
            //requests for them before sending an e-mail
            client.UseDefaultCredentials = true;
            try
            {
                client.Send(message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception caught in CreateTestMessage2(): {0}", ex.ToString());
            }
        }
    }
}
