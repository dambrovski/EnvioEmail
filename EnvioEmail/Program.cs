using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;

namespace EnvioEmail
{
    class Program
    {
        static void Main(string[] args)
        {

            string FROM = "cotacaoprojetomaster@gmail.com";
            string FROMNAME = "Airton";

            string TO = "cotacaoprojetomaster@gmail.com";


            string SMTP_USERNAME = "cotacaoprojetomaster@gmail.com";
            string SMTP_PASSWORD = "91WmOCOw";
            string CONFIGSET = "ConfigSet";
            string HOST = "smtp.gmail.com";

            int PORT = 587;


            string SUBJECT =
                "TESTE DE EMAIL EM C#";


            string BODY =
                "<h1>TESTE DE EMAIL</h1>" +
                "<p>PARAGRAFO DO EMAIL</p>";


            MailMessage message = new MailMessage();
            message.IsBodyHtml = true;
            message.From = new MailAddress(FROM, FROMNAME);
            message.To.Add(new MailAddress(TO));
            message.Subject = SUBJECT;
            message.Body = BODY;

            message.Headers.Add("X-SES-CONFIGURATION-SET", CONFIGSET);

            using (var client = new System.Net.Mail.SmtpClient(HOST, PORT))
            {
                client.Credentials =
                    new NetworkCredential(SMTP_USERNAME, SMTP_PASSWORD);

                client.EnableSsl = true;

                try
                {
                    Console.WriteLine("Enviando email...");
                    client.Send(message);
                    Console.WriteLine("Email enviado!");
                    Console.ReadKey();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("O Email não foi enviado.");
                    Console.WriteLine("Mensagem de Erro: " + ex.Message);
                    Console.ReadKey();
                }
            }
        }
    }
}