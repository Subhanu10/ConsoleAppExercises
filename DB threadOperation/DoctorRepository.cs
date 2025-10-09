using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Data.SqlClient;
using System.Collections.Generic;
namespace DB_threadOperation
{
    public class DoctorRepository
    {
        static List<DoctorDetails> doctordetails = new List<DoctorDetails>();
        string connectionString = "Server=DESKTOP-BLBGEHJ\\SQLEXPRESS;Database=batch11;User Id=sa;Password=Anaiyaan@123;";
        public void ChoiceAction()
        {

            while (true)
            {
                Console.WriteLine("Doctors Details");
                Console.WriteLine("1. Add Doctors");
                Console.WriteLine("2. Update Doctors");
                Console.WriteLine("3. Delete Doctors");
                Console.WriteLine("4. Search Doctors");
                Console.WriteLine("5. View Doctors");
                Console.WriteLine("6.Exist");
                Console.WriteLine("Choose the ChoiceOption: ");
                int Option = Convert.ToInt32(Console.ReadLine());
                switch (Option)
                {
                    case 1:

                        AddDoctors();
                        break;
                    case 2:
                        UpdateDoctors();
                        break;
                    case 3:
                        DeleteDoctors();
                        break;                                            
                    case 4:
                        SearchDoctors();
                        break;
                    case 5:
                        ViewDoctors();
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
        
        public List<DoctorDetails> ViewDoctors()
        {
            try
            {
                
                string sql = $"select*from doctors";
                var connection = new SqlConnection(connectionString);
                connection.Open();
                var result = connection.Query<DoctorDetails>(sql).ToList();
                connection.Close();
                return result;
            }
            catch(SqlException ex)
            {
                throw; 
            }
            catch(Exception ex)
            {
                throw;
            }
        }

        public void AddDoctors()
        {
            try
            {

                Console.WriteLine("Enter the Number of Doctors Details to add:");
                int a = Convert.ToInt32(Console.ReadLine());
                for (int i = 0; i < a; i++)
                {
                    DoctorDetails p = new DoctorDetails();
                    Console.WriteLine("Enter the Name:");
                    p.Name = Console.ReadLine();
                    Console.WriteLine("Enter the Email:");
                    p.Email = Console.ReadLine();
                    Console.WriteLine("Enter the Age:");
                    p.Age = Convert.ToInt32(Console.ReadLine());

                    
                    string sql = $"INSERT INTO doctors VALUES('{p.Name}','{p.Email}',{p.Age})";
                    var connection = new SqlConnection(connectionString);
                    connection.Open();
                    var result = connection.Execute(sql);
                    connection.Close();
                    Console.WriteLine("Successfully Added!");
                }
            }
            catch (SqlException ex)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        
        public void UpdateDoctors()
        {
            try
            {
                Console.WriteLine("Enter the Id to find the Details:");
                int update = Convert.ToInt32(Console.ReadLine());
                DoctorDetails updatedata = doctordetails.FirstOrDefault(s => s.Id == update);
                if (updatedata != null)
                {
                    Console.WriteLine("Name:" + updatedata.Name);
                    string Name = Console.ReadLine();
                    if (!string.IsNullOrEmpty(Name)) updatedata.Name = Name;
                    Console.WriteLine("Email:" + updatedata.Email);
                    string Email = Console.ReadLine();
                    if (!string.IsNullOrEmpty(Email)) updatedata.Email = Email;
                    Console.WriteLine("Age:" + updatedata.Age);
                    int Age = Convert.ToInt32(Console.ReadLine());
                    if (Age>0)updatedata.Age = Age;
                    
                    string sql = $"UPDATE Doctors SET updatedata.Name = Name, updatedata.Email = Email, updatedata.Age = Age WHERE id = @Id";
                    var connection = new SqlConnection(connectionString);
                    connection.Open();
                    var result = connection.Execute(sql);
                    connection.Close();
                    Console.WriteLine("Successfully Updated!");
                }
            }
            catch(SqlException ex)
            {
                throw;
            }
            catch(Exception ex)
            {
                throw;
            }
        }
        public void DeleteDoctors()
        {
            try
            {
                Console.WriteLine("Enter the Doctor Id to delete:");
                var id = Console.ReadLine();
                
                string sql = $"DELETE FROM doctors WHERE DoctorsId = @id";
                var connection = new SqlConnection(connectionString);
                connection.Open();
                var result = connection.Execute(sql);
                connection.Close();
                Console.WriteLine("deleted Successfully");
            }
            catch(SqlException ex)
            {

            }
            catch(Exception ex)
            {

            }
        }
        public void SearchDoctors()
        {
            try
            {
                Console.WriteLine("To Search the Doctordetails:");
                var value = Console.ReadLine();
                
                string sql = $"SELECT*FROM doctors WHERE Name LIKE value% ";
                var connection = new SqlConnection(connectionString);
                connection.Open();
                var result = connection.Execute(sql);
                connection.Close();
            }
            catch (SqlException ex)
            {

            }
            catch (Exception ex)
            {

            }
        }        
    }
}