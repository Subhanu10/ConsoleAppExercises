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
        public List<DoctorDetails> GetDoctors()
        {
            try
            {
                string connectionString = "Server=DESKTOP-BLBGEHJ\\SQLEXPRESS;Database=batch11;User Id=sa;Password=Anaiyaan@123;";
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

        public void AddDoctors(DoctorDetails Record)
        {
            try
            {
                string connectionString = "Server=DESKTOP-BLBGEHJ\\SQLEXPRESS;Database=batch11;User Id=sa;Password=Anaiyaan@123;";
                string sql = $"insert into doctors values('{DoctorDetails record}')";
                var connection = new SqlConnection(connectionString);
                connection.Open();
                var result = connection.Query<DoctorDetails>(sql).ToList();
                connection.Close();
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

    }
}
