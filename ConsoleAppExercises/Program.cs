using System;
using Newtonsoft.Json;
using JsonThreadOperation.Model;
using DB_threadOperation;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Text;



namespace ConsoleAppExercises
{
    class Program
    {
        static void Main(string[] args)

        {

            MyHttpclient obj = new MyHttpclient();
           var result = obj.GetPatientsAsync();
            obj.HttpClientEmail();


            //try
            //{
            //Console.WriteLine("Starting email sending process....");
            //var sender = new MailKitEmailSender();
            //sender.SendEmailAsync();
            //}
            //catch (Exception ex)
            //{

            //}
            //try
            //{
            //Console.WriteLine("Starting email sending process...");
            //var sender = new InbuildEmailSender();
            //sender.SendEmail();
            //}
            //catch
            //{

            //}


            //Information details = new Information();
            //details.ChoiceAction();
            //try
            //{
            //DoctorRepository obj = new DoctorRepository();
            //obj.ChoiceAction();

            //}
            //catch(Exception ex)
            //{
            //Console.WriteLine("Something went wrong");
            //}


        }

    }
}
