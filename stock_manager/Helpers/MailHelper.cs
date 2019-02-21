
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using System;

namespace stock_manager.Helpers
{
    public class MailHelper
    {
        public static void EnviarCorreo(string nombre, string dir_elec, string asunto, string mensaje)
        {
            string remitente = "julianaweb@systemsltda.com";
            string servidor = "mail.systemsltda.com";
            int puerto = 587;
            string usuario = "julianaweb@systemsltda.com";
            string clave = "Juliana2002";
            bool ssl = true;

            mensaje = mensaje.Replace("@ano", DateTime.Now.Year.ToString());

            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Notificaciones", remitente));
            //message.To.Add(new MailboxAddress(addressName, adminMail)); // test change for line below in prod
            var correos = dir_elec.Split(';');
            foreach (string c in correos)
            {
                message.To.Add(new MailboxAddress(nombre.Trim(), c.Trim()));
            }

            message.Subject = asunto;
            var builder = new BodyBuilder();
            builder.HtmlBody = mensaje;
            message.Body = builder.ToMessageBody();
            using (var client = new SmtpClient())
            {
                var secureOption = ssl ? SecureSocketOptions.StartTls : SecureSocketOptions.None;
                client.ServerCertificateValidationCallback = (sender, certificate, chain, sslPolicyErrors) =>
                {
                    return true;
                };
                client.Connect(servidor, puerto, secureOption);
                if (client.Capabilities.HasFlag(SmtpCapabilities.Authentication))
                {
                    client.Authenticate(usuario, clave);
                }
                client.Send(message);
                client.Disconnect(true);
            }
        }

        public static void EnviarCorreoConAdjunto(string addressName, string address, string subject, string body, byte[] attachFile, string filename, string id)
        {
            string remitente = "soporte@systemsltda.com";
            string servidor = "mail.systemsltda.com";
            int puerto = 587;
            string usuario = "soporte@systemsltda.com";
            string clave = "Juliana2002";
            bool ssl = true;

            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Notificaciones Plataforma de Outsourcing", remitente));
            //message.To.Add(new MailboxAddress(addressName, adminMail)); // test change for line below in prod
            //message.To.Add(new MailboxAddress(addressName, address.Trim()));
            var correos = address.Split(';');
            foreach (string c in correos)
            {
                message.To.Add(new MailboxAddress(c.Trim(), c.Trim()));
            }
            message.Subject = subject;
            var builder = new BodyBuilder();
            builder.HtmlBody = body;
            builder.Attachments.Add(filename, attachFile);

            message.Body = builder.ToMessageBody();
            using (var client = new SmtpClient())
            {
                var secureOption = ssl ? SecureSocketOptions.StartTls : SecureSocketOptions.None;
                client.Connect(servidor, puerto, secureOption);
                client.Authenticate(usuario, clave);
                client.Send(message);
                client.Disconnect(true);
            }

            message.MessageId = id;
        }
    }
}
