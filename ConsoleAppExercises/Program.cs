using System;

namespace ConsoleAppExercises
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting email sending process....");
            var sender = new MailKitEmailSender();
            sender.SendEmailAsync()
        }
    }
}
