using MailKit.Net.Pop3;
using MailKit.Net.Smtp;
using MimeKit;
using MimeKit.Text;
using RelacionamentoPadaria.Models;

namespace RelacionamentoPadaria.Services
{
    public class EmailService : IEmailService
    {
        private readonly IEmailServerConfig _config;
        public EmailService(IEmailServerConfig config)
        {
            _config = config;
        }

        public List<EmailMensagemModel> ReceberEmail(int maximo = 10)
        {
            using (var emailClient = new Pop3Client())
            {
                emailClient.Connect(_config.PopServer, _config.PopPort, true);
                emailClient.AuthenticationMechanisms.Remove("XOAUTH2");
                emailClient.Authenticate(_config.PopUsername, _config.PopPassword);

                List<EmailMensagemModel> emails = new List<EmailMensagemModel>();
                for (int i = 0; i < emailClient.Count && i < maximo; i++)
                {
                    var mensagem = emailClient.GetMessage(i);
                    var emailMensagem = new EmailMensagemModel
                    {
                        Conteudo = !string.IsNullOrEmpty(mensagem.HtmlBody)
                                   ? mensagem.HtmlBody : mensagem.TextBody,

                        Assunto = mensagem.Subject
                    };
                    emailMensagem.ParaEnderecos.AddRange(mensagem.To.Select(x =>
                                 (MailboxAddress)x).Select(x => new EmailEnderecoModel
                                 { Endereco = x.Address, Nome = x.Name }));

                    emailMensagem.DeEnderecos.AddRange(mensagem.From.Select(x =>
                                 (MailboxAddress)x).Select(x => new EmailEnderecoModel
                                 { Endereco = x.Address, Nome = x.Name }));

                    emails.Add(emailMensagem);
                }

                return emails;
            }
        }

        public void EnviarEmail(EmailMensagemModel emailMensagem)
        {
            var mensagem = new MimeMessage();
            mensagem.To.AddRange(emailMensagem.ParaEnderecos.Select(x =>
                                new MailboxAddress(x.Nome, x.Endereco)));

            mensagem.From.AddRange(emailMensagem.DeEnderecos.Select(x =>
                                  new MailboxAddress(x.Nome, x.Endereco)));

            mensagem.Subject = emailMensagem.Assunto;
            //Enviando HTML (podemos usar texto tambem)
            mensagem.Body = new TextPart(TextFormat.Html)
            {
                Text = emailMensagem.Conteudo
            };

            //{
            //    var email = new MimeMessage();

            //    email.From.Add(new MailboxAddress("Sender Name", "sender@email.com"));
            //    email.To.Add(new MailboxAddress("Receiver Name", "receiver@email.com"));

            //    email.Subject = "Testing out email sending";
            //    email.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            //    {
            //        Text = "<b>Hello all the way from the land of C#</b>"
            //    };

                using (var smtp = new SmtpClient())
                {
                    smtp.Connect(_config.SmtpServer, _config.SmtpPort, false);

                    // Note: only needed if the SMTP server requires authentication
                    smtp.Authenticate(_config.SmtpUsername, _config.SmtpPassword);

                    smtp.Send(mensagem);
                    smtp.Disconnect(true);
                }
                //Use a classe SmtpClient do Mailkit
                //using (var emailClient = new SmtpClient())
                //{
                //    try
                //    {
                //        //O ultimo parametro é para usar SSL
                //        emailClient.Connect(_config.SmtpServer, _config.SmtpPort, true);

                //        //Remover qualquer funcionalidade OAuth
                //        emailClient.AuthenticationMechanisms.Remove("XOAUTH2");
                //        emailClient.Authenticate(_config.SmtpUsername, _config.SmtpPassword);
                //        emailClient.Send(mensagem);
                //        emailClient.Disconnect(true);
                //    }
                //    catch(Exception ex)
                //    {
                //        Console.WriteLine(ex.Message);
                //    }
            //}
        }
    }
}
