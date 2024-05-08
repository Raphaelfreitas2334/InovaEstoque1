using Microsoft.Extensions.Configuration;
using System.Net;
using System.Net.Mail;

namespace WebApplication1.helper
{
    public class Email : IEmail
    {
        private readonly IConfiguration _configuration;

        public Email(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public bool Enviar(string email, string assunto, string mensagem)
        {
            try
            {
                //aqui esta pegando as informações para o envio do email
                string host = _configuration.GetValue<string>("SMTP:Host");
                string nome = _configuration.GetValue<string>("SMTP:Nome");
                string username = _configuration.GetValue<string>("SMTP:UserName");
                string senha = _configuration.GetValue<string>("SMTP:Senha");
                int porta = _configuration.GetValue<int>("SMTP:Porta");

                //criando o email
                MailMessage mail = new MailMessage()
                {
                    From = new MailAddress(username, nome),
                };

                //contruindo o email
                mail.To.Add(email);// pra quem e o email
                mail.Subject = assunto; // o assunto do email
                mail.Body = mensagem; //a mensagem do email
                mail.IsBodyHtml = true; // email aceita html
                mail.Priority = MailPriority.High; // email de alta prioridade


                using (SmtpClient smtp = new SmtpClient(host, porta)) 
                {
                    smtp.Credentials = new NetworkCredential(username, senha);
                    //essa linha deixa o email sendo seguro
                    smtp.EnableSsl = true;

                    //essa linha manda o email
                    smtp.Send(mail);
                    return true;
                }
            }
            catch (System.Exception ex)
            {

                return false;
            }
        }
    }
}
