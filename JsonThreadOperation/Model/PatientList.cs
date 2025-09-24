using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using System.IO;
using System.Linq;

namespace JsonThreadOperation.Model
{
    class Information
    {

        static string Filepath = "C:\\Users\\Anaiyaan\\source\\repos\\ConsoleAppExercises\\ConsoleAppExercises\\Data\\";
        static List<Patient> patients = new List<Patient>();
        static void ChoiceAction()
        {
            LoadPatients();
            while (true)
            {
                Console.WriteLine("Patient Details");
                Console.WriteLine("1. Add Patients");
                Console.WriteLine("2. Update Patients");
                Console.WriteLine("3. Delete Patients");
                Console.WriteLine("4. View Patients");
                Console.WriteLine("5. Search Patients");
                Console.WriteLine("6.Exist");
                Console.WriteLine("Choose the ChoiceOption: ");
                int Option = Convert.ToInt32(Console.ReadLine());
                switch (Option)
                {
                    case 1:
                        AddPatient();
                        break;
                    case 2:
                        UpdatePatient();
                        break;
                    case 3:
                        DeletePatient();
                        break;
                    case 4:
                        PrintPatientDetails();
                        break;
                    case 5:
                        SearchPatient();
                        break;
                    case 6:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid Option. Please enter the valid Option.");
                        break;
                }
            }
        }
        static void LoadPatients()
        {
            if (File.Exists(Filepath))
            {
                string json = File.ReadAllText(Filepath);
                patients = JsonConvert.DeserializeObject<List<Patient>>(json);
                File.WriteAllText(Filepath, json);
            }
        }
        static void SavePatients()
        {
            string json = JsonConvert.SerializeObject(patients, Formatting.Indented);
            File.WriteAllText(Filepath, json);
        }
        static void AddPatient()
        {
            try
            {
                Console.WriteLine("Enter the Index:");
                int a = Convert.ToInt32(Console.ReadLine());
                for (int i = 0; i < a; i++)
                {
                    Patient p = new Patient();
                    Console.WriteLine("Enter the Name:");
                    p.Name = Console.ReadLine();
                    Console.WriteLine("Enter the MobileNumber:");
                    p.MobileNumber = Convert.ToInt64(Console.ReadLine());
                    Console.WriteLine("Enter the Email:");
                    p.Email = Console.ReadLine();
                    Console.WriteLine("Enter the Location:");
                    p.Location = Console.ReadLine();
                    Console.WriteLine("Enter the Address:");
                    p.Address = Console.ReadLine();


                    SavePatients();
                    if (patients.Any(type => type.MobileNumber == p.MobileNumber || type.Email == p.Email))
                        {
                            patients.Add(p);
                            Console.WriteLine("Patient Details added successfully!");
                        }
                    else
                        {
                            Console.WriteLine("Patient Details does not exist");
                        }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
                throw;
            }
        }
        static void UpdatePatient()
        {
            try
            {

                Console.WriteLine("Enter the MoibleNumber to Update");
                long mobiletoupdate = Convert.ToInt64(Console.ReadLine());

                Patient update = patients.FirstOrDefault(s => s.MobileNumber == mobiletoupdate);
                if (update != null)
                {
                    Console.WriteLine("Name:" + update.Name);
                    string Name = Console.ReadLine();
                    if (!string.IsNullOrEmpty(Name)) update.Name = Name;
                    Console.WriteLine("Email:" + update.Email);
                    string Email = Console.ReadLine();
                    if (!string.IsNullOrEmpty(Email)) update.Email = Email;
                    Console.WriteLine("Address:" + update.Address);
                    string Address = Console.ReadLine();
                    if (!string.IsNullOrEmpty(Address)) update.Address = Address;
                    Console.WriteLine("Location:" + update.Location);
                    string Location = Console.ReadLine();
                    if (!string.IsNullOrEmpty(Location)) update.Location = Location;

                    SavePatients();
                    Console.WriteLine("Patient Details Updated Successfully!");
                }
                else
                {
                    Console.WriteLine("Patient not found!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
        }
        static void DeletePatient()
        {
            try
            {
                Console.WriteLine("Enter a number to delete:");
                long MobileNumberTodelete = Convert.ToInt64(Console.ReadLine());
                long patient = patients.RemoveAll(p => p.MobileNumber == MobileNumberTodelete);
                if (patient > 0)
                {
                    SavePatients();
                    Console.WriteLine("Patient Successfully Deleted!");
                }
                else
                {
                    Console.WriteLine("Patient not Found");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
        }
        static void SearchPatient()
        {
            try
            {
                Console.WriteLine("Enter the MobileNumber or Name or Email to Search:");
                string keyword = Console.ReadLine();

                List<Patient> patient = patients.Where(p => p.Name.Contains(keyword) || p.MobileNumber.ToString().Contains(keyword) || p.Email.Contains(keyword)).ToList();
                if (patient.Any())
                {
                    foreach (Patient filter in patient)
                    {
                        Console.WriteLine($"{ filter.Name} {filter.MobileNumber} {filter.Email} {filter.Location} {filter.Address}");

                    }
                }

                else
                {
                    Console.WriteLine("Patient not found");
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
        }
        static void PrintPatientDetails()
        {
            Console.WriteLine("Name         MobileNumber            Email           Location            Address");
            foreach (Patient view in patients)
            {
                Console.WriteLine("" + view.Name + "            " + view.MobileNumber + "           " + view.Email + "          " + view.Location + "           " + view.Address + "            ");

            }
        }
    }
}       
               