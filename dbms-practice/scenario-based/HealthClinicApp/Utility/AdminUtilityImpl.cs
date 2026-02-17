using System.Data;
using Microsoft.Data.SqlClient;
using HealthClinicApp.DatabaseConnection;
using HealthClinicApp.Interface;

namespace HealthClinicApp.Utility;

class AdminUtilityImpl : IAdmin
{
    public void AddNewAdmin()
    {
        try
        {
            using(SqlConnection con = ConnectDB.BuildConnection())
            {
                SqlCommand cmd = new SqlCommand("RegisterAdmin", con);
                cmd.CommandType = CommandType.StoredProcedure;

                Console.Write("Enter Admin Name: ");
                cmd.Parameters.Add("@Name", SqlDbType.VarChar, 50).Value = Console.ReadLine();

                Console.Write("Enter Admin Phone: ");
                cmd.Parameters.Add("@Phone", SqlDbType.VarChar, 10).Value = Console.ReadLine();

                con.Open();
                int rows = cmd.ExecuteNonQuery();

                Console.WriteLine(
                    rows > 0 ? "Admin added successfully." : "Admin insertion failed."
                );
            }
        }
        catch(SqlException ex)
        {
            Console.WriteLine("Database Error: " + ex.Message);
        }
    }
}
