using MailKit.Net.Smtp;
using MimeKit;
using WBAuth.BO;


namespace WBAuth.BLL.Manager
{
    public interface IEmailSender
    {
        void SendEmail(Message message);
        Task SendEmailAsync(Message message, string action);
    }


    public class EmailSender : IEmailSender
    {
        private readonly EmailConfiguration _emailConfig;

        public EmailSender(EmailConfiguration emailConfig)
        {
            _emailConfig = emailConfig;
        }


        public async Task SendEmailAsync(Message message ,string action)
        {
            var mailMessage = CreateEmailMessage(message ,action);
            await SendAsync(mailMessage);
        }

        private MimeMessage CreateEmailMessage(Message message ,string action)
        {
          if(action == "réinitialisation"){ 
            var emailMessage = new MimeMessage();
            emailMessage.From.Add(new MailboxAddress("WBConcept", _emailConfig.From));
            emailMessage.To.AddRange(message.To);
            emailMessage.Subject = message.Subject;
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html) {
               Text = string.Format(
                 "<div style='display:flex; flex-direction: row; justify-content:center; align-items:center; border:solid 2px #111; margin :3% 20% 3% 20%; font-family:Verdana;'>" +
                 "<div> <div style='padding:10px 20px 10px 20px;'> <h3 style='color:black;'><b> Bonjour, </b></h3> " +
                 "<span style='font-size:14;'> Réinitialisez votre mot de passe par le lien suivant : {0}</span>" + "</div><hr>" +
                 "<img src='https://wbconcept.com/wp-content/uploads/2023/07/logo-wbc-c2-05.png' alt='WBConcept' width='140px' height='140px' style='padding:0px 0px 10px 15px;'/> </div></div>"
              ,message.Content)
            };
            return emailMessage;
          }
          else if(action == "emailConfirmation"){
            var emailMessage = new MimeMessage();
            emailMessage.From.Add(new MailboxAddress("WBConcept", _emailConfig.From));
            emailMessage.To.AddRange(message.To);
            emailMessage.Subject = message.Subject;
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html) {
               Text = string.Format(
                 "<div style='display:flex; flex-direction: row; justify-content:center; align-items:center; border:solid 2px #111; margin :3% 20% 3% 20%; font-family:Verdana;'>" +
                 "<div> <div style='padding:10px 20px 10px 20px;'> <h3 style='color:black;'><b> Bonjour, </b></h3> " +
                 "<span style='font-size:14;'> Veuillez confirmer votre inscription par le lien suivant : {0}</span>" + "</div><hr>" +
                 "<img src='https://wbconcept.com/wp-content/uploads/2023/07/logo-wbc-c2-05.png' alt='WBConcept' width='140px' height='140px' style='padding:0px 0px 10px 15px;'/> </div></div>"
              ,message.Content)
            };
            return emailMessage;
          }
          else if (action == "verificationDoubleFacteur"){
            var emailMessage = new MimeMessage();
            emailMessage.From.Add(new MailboxAddress("WBConcept", _emailConfig.From));
            emailMessage.To.AddRange(message.To);
            emailMessage.Subject = message.Subject;
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html){
               Text = string.Format(
                 "<div style='display:flex; flex-direction: row; justify-content:center; align-items:center; border:solid 2px #111; margin :3% 33% 3% 33%; font-family:Verdana;'>" +
                 "<div> <div style='padding:10px 20px 10px 20px;'> <h2 style='color:black;'><b> Bonjour, </b></h2> " +
                 "<h3 style='color:black'><b> Veuillez vérifier votre identifiant par le code suivant : </b></h3>" +
                 "<center><h1 style='border:solid 2px #3DB3E6; border-radius:10px; padding:5px;'> <b> {0} </b> </h1> </center></div><hr><br>" +
                 "<img src='https://wbconcept.com/wp-content/uploads/2023/07/logo-wbc-c2-05.png' alt='WBConcept' width='140px' height='140px' style='padding:0px 0px 10px 15px;'/> </div></div>"
              ,message.Content)
            };
            return emailMessage;
          }


            return null;
        }


        private async Task SendAsync(MimeMessage mailMessage)
        {
            using (var client = new SmtpClient())
            {
                try
                {
                    client.ServerCertificateValidationCallback = (s, c, h, e) => true; // Desactivation TSL/SSL sauf au test 
                    await client.ConnectAsync(_emailConfig.SmtpServer, _emailConfig.Port, true);
                    client.AuthenticationMechanisms.Remove("XOAUTH2");
                    await client.AuthenticateAsync(_emailConfig.UserName, _emailConfig.Password);
                    await client.SendAsync(mailMessage);
            }
                catch { throw new Exception("Erreur d'envoie ou erreur de configuration d'email !"); }
                finally
                {
                await client.DisconnectAsync(true);
                client.Dispose();
            }
        }
        }


/*-------------------------------------------------- NON ASYNC ---------------------------------------------------------------*/
        public void SendEmail(Message message)
        {
            var emailMessage = CreateEmailMessage(message ,"");
            Send(emailMessage);
        }
        private void Send(MimeMessage mailMessage)
        {
            using (var client = new SmtpClient())
            {
                try
                {
                    client.Connect(_emailConfig.SmtpServer, _emailConfig.Port, true);
                    client.AuthenticationMechanisms.Remove("XOAUTH2");
                    client.Authenticate(_emailConfig.UserName, _emailConfig.Password);
                    client.Send(mailMessage);
                }
                catch { throw new Exception("Erreur d'envoie ou erreur de configuration d'email !"); }
                finally
                {
                    client.Disconnect(true);
                    client.Dispose();
                }
            }
        }



    }
}