using System;
using EmailService;


namespace ConsoleAppExercises
{
    class Program
    {
        static void Main(string[] args)
        
        {
            //try
            //{
            //Console.WriteLine("Starting email sending process....");
            //var sender = new MailKitEmailSender();
            //sender.SendEmailAsync();
            //}
            //catch(Exception ex )
            //{

            //}
            try
            {
                Console.WriteLine("Starting email sending process...");
                var sender = new InbuildEmailSender();
                sender.SendEmail();
            }
            catch
            {

            }

        }
    }
}
