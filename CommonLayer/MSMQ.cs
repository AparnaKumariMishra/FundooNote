using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using Experimental.System.Messaging;

namespace CommonLayer
{
    public class MSMQ
    {
       Experimental.System.Messaging. MessageQueue messageQueue = new Experimental.System.Messaging.MessageQueue();
        private string recieverEmailAddr;
        private string recieverName;
        public void sendData2Queue(string token, string emailId, string name)
        {
            recieverEmailAddr = emailId;
            recieverName = name;
            messageQueue.Path = @".\private$\Token";
            try
            {
                if (!MessageQueue.Exists(messageQueue.Path))
                {
                    MessageQueue.Create(messageQueue.Path);
                }
                messageQueue.Formatter = new XmlMessageFormatter(new Type[] { typeof(string) });
                messageQueue.ReceiveCompleted += MessageQueue_ReceiveCompleted;
                messageQueue.Send(token);
                messageQueue.BeginReceive();
                messageQueue.Close();
            }
            catch(Exception)
            {
                throw;
            }
            }

        public void MessageQueue_ReceiveCompleted(object sender,ReceiveCompletedEventArgs e)
        {
            try
            {
                var msg = messageQueue.EndReceive(e.AsyncResult);
                string token = msg.Body.ToString();
                MailMessage mailMessage = new MailMessage();
                string subject = "FundoNoteRestLink";
                string Body = token;
                SmtpClient smtpClient = new SmtpClient("smtp.gmail.com")
                {
                    Port = 587,
                    Credentials = new NetworkCredential("aparna252mishra@gmail.com", "qpumhjdkcuvpjjya"),
                    EnableSsl = true,
                };
               mailMessage.From = new MailAddress("aparna252mishra@gmail.com");
                mailMessage.To.Add(new MailAddress(recieverEmailAddr));
                string mailBody = $"<!Doctype html>" +
                    $"<html>" +
                    $"<style>" +
                    $"<.blink>" +
                    $"</style>" +
                    $"<body style = \"background-color:Blue;text-align:center;padding:5px;\">" +
                    $"<h1 style = \"color:#6A8002; border-bottom: 3px solid #84AF88;margin-top:5px;\"> Dear <b>{recieverName}</b></h1>\n" +
                    $"<h3 style = \"color:#8AB411\">; For Resetting Password the Below Link Is Issued</h3>" +
                    $"<h3 style = \"color:#8AB411\">; please check the link Below To Reset Your Password</h3>" +
                    $"<a style = \"color:#00802b; text-decoration: non;font-size:20px;\'href=http://localhost:4200/resetpassword/{token}' > click me</a>\n" +
                    $"<h3 style = \"color:#8Ab411;margin-bottom:5px;\"><blink>This Token will be valid for next 6 Hours<blink></h3>" +
                    $"</body>" +
                    $"</html>";
                mailMessage.Body = mailBody;
                mailMessage.IsBodyHtml = true;
                mailMessage.Subject = "FundoNote Password Reset Link";
                smtpClient.Send(mailMessage);
                //smtp.Send("aaparna252mishra@gmail.com","aaparna252mishra@gmail.com",subject, Body);

            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
