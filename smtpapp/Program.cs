using System;
using MailKit.Net.Smtp;
using MailKit;
using MimeKit;

namespace smtpapp
{
    internal class Program
    {
        static void Main(string[] args)
        {

            MimeMessage message = new MimeMessage();
            message.From.Add(new MailboxAddress("zinny", "melainegrace03@gmail.com"));

            message.To.Add(MailboxAddress.Parse("melainegrace03@gmail.com"));

            message.Subject = "zinny2";

            message.Body = new TextPart("plain")
            {
                Text = @"Yes, Hello!"
            };

            Console.Write("Email: ");
            string emailAddress = Console.ReadLine();

            Console.Write("Password; ");

            ConsoleColor originalBGColor = Console.BackgroundColor;
            ConsoleColor originalFGColor = Console.ForegroundColor;

            Console.BackgroundColor = ConsoleColor.Green;
            Console.ForegroundColor = ConsoleColor.Green;

            string password = Console.ReadLine();

            Console.BackgroundColor = originalBGColor;
            Console.ForegroundColor = originalFGColor;

            SmtpClient client = new SmtpClient();

            try
            {
                client.Connect("smtp.gmail.com", 465, true);
                client.Authenticate(emailAddress, password);
                client.Send(message);

                Console.WriteLine("Email Sent!.");
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                client.Disconnect(true);
                client.Dispose();
            }
            Console.ReadLine();
        }
    }
}
