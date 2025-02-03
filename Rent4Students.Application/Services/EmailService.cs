using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using Rent4Students.Application.Services.Interfaces;
using Rent4Students.Domain.Entities;

namespace Rent4Students.Application.Services
{
    public class EmailService : IEmailService
    {
        public async Task<bool> SendAccessEmailForFaculty(Faculty faculty)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Rent4Students", "rent4studentsapp@gmail.com"));
            message.To.Add(new MailboxAddress(faculty.SecretaryName, faculty.Email));
            message.Subject = "Cont creat pe Rent4Students";

            message.Body = new TextPart("plain")
            {
                Text =
                $@"Dragă {faculty.SecretaryName},

Suntem încântați să vă anunțăm că contul dumneavoastră de Secretar de Facultate pentru aplicația Rent4Students a fost creat cu succes! Acest cont vă va permite să gestionați studenții și să accesați toate funcțiile aplicației destinate universității dumneavoastră.

Detalii cont:
• Email utilizator: {faculty.Email}
• Parola temporară: {faculty.EncryptedPassword}

Instrucțiuni pentru acces:
1. Accesați aplicația Rent4Students.
2. Introduceți numele de utilizator și parola temporară.
3. Vă recomandăm să schimbați parola imediat după primul acces pentru a asigura securitatea contului.

Funcționalități disponibile:
• Gestionarea studenților
• Crearea cererilor de ajutor pentru chirie
• Monitorizarea statutului cererilor

Dacă aveți întrebări sau întâmpinați dificultăți la accesarea aplicației, nu ezitați să ne contactați la adresa rent4studentsapp@gmail.com.

Vă mulțumim pentru colaborare și vă dorim mult succes în gestionarea studenților!
Cu respect,
Echipa Rent4Students"
            };

            using (var client = new SmtpClient())
            {
                try
                {
                    await client.ConnectAsync("smtp.gmail.com", 465, SecureSocketOptions.SslOnConnect);
                    await client.AuthenticateAsync("rent4studentsapp@gmail.com", "lptnozcxqgdehfaw");
                    var send = await client.SendAsync(message);
                    await client.DisconnectAsync(true);
                    Console.WriteLine("Email sent successfully!");
                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error sending email: " + ex.Message);
                }
            }

            return false;
        }
    }
}
