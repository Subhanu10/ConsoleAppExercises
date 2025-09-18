using System;


namespace ConsoleAppExercises
{
    class Program
    {
        static void  Main(string[] args)
        {
            Console.WriteLine("Starting email sending process....");
            
            string fromAddress = "your.email@gmail.com";
            var sender = new MailKitEmailSender();
            await sender.SendEmailAsync(fromAddress);

        }
    }
}
