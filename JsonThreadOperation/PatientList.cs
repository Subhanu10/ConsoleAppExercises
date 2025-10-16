using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using System.IO;
using System.Linq;

namespace JsonThreadOperation.Model
{
    public class Information
    {

        static string Filepath = AppDomain.CurrentDomain.BaseDirectory + "\\Data\\Data.json";

        static List<Patient> patients = new List<Patient>();
        
        public void LoadPatients()
        {
            if (File.Exists(Filepath))
            {
                try
                {
                    string json = File.ReadAllText(Filepath);
                    patients = JsonConvert.DeserializeObject<List<Patient>>(json);
                }
                catch(JsonException ex)
                {
                    Console.WriteLine("Error deserializing JSON:" + ex.Message);
                    throw;
                }
            }
        }

        public List<Patient> ReadJsonALLforPatients()
        {
            try
            {
               var listOfpatients =  File.ReadAllText(Filepath);

               var list =  JsonConvert.DeserializeObject<List<Patient>>(listOfpatients);

                return list != null && list.Count > 0 ? list : new List<Patient>();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error serializing JSON:" + ex.Message);
                throw;
            }
        }
        public void SavePatients()
        {
            try
            {
                string json = JsonConvert.SerializeObject(patients, Formatting.Indented);
                File.WriteAllText(Filepath, json);
            }
            catch(JsonException ex)
            {
                Console.WriteLine("Error serializing JSON:" + ex.Message);
            }
        }
        public void AddPatient(Patient patient)
        {
            try
            {
                patient.Id = patients.Count + 1;
                
                bool isDuplicated = patients.Any(type => type.MobileNumber == patient.MobileNumber || type.Email == patient.Email);
                    if (!isDuplicated)
                    {
                        patients.Add(patient);
                        SavePatients();
                        Console.WriteLine("Patient Details added successfully!");
                    }
                    else
                    {
                        Console.WriteLine("Patient Details does not exist");
                    }
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
                throw;
            }
        }
        public void UpdatePatient(Patient patient)
        {
            try
            {


                Patient update = patients.FirstOrDefault(s => s.MobileNumber == patient.MobileNumber);
                if (update != null)
                {
                    update.Name = patient.Name;
                    update.MobileNumber = patient.MobileNumber;
                    update.Email = patient.Email;
                    update.Location = patient.Location;
                    update.Address = patient.Address;

                    SavePatients();                  
                }
               
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
        }
        public void DeletePatient(int Id)
        {
            try
            {
               
                var delete = patients.FirstOrDefault(p => p.Id == Id);
                if (delete != null)
                {
                    
                    patients.Remove(delete);
                    SavePatients();
                }
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
        }
        public void SearchPatient(string keyword)
        {
            try
            {
                

                List<Patient> patient = patients.Where(p => p.Name.Contains(keyword) || p.MobileNumber.ToString().Contains(keyword) || p.Email.Contains(keyword)).ToList();
                if (patient.Any())
                {
                    Console.WriteLine("Name         MobileNumber            Email           Location            Address");

                    foreach (Patient filter in patient)
                    {

                        Console.WriteLine($"{ filter.Name} {filter.MobileNumber} {filter.Email} {filter.Location} {filter.Address}");
                    }
                }

               
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
        }
        public void PrintPatientDetails()
        {
            Console.WriteLine("Name         MobileNumber            Email           Location            Address");
            foreach (Patient view in patients)
            {
                Console.WriteLine("" + view.Name + "            " + view.MobileNumber + "           " + view.Email + "          " + view.Location + "           " + view.Address + "            ");

            }
        }
        public List<Patient> GetAllPatients()
        {
            return patients;
        }
        public Patient GetPatientById(int Id)
        {
            return patients.FirstOrDefault(p => p.Id == Id);
        }
    }
}       
               