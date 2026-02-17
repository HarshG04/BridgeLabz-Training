using System.Data;
using Microsoft.Data.SqlClient;
using HealthClinicApp.DatabaseConnection;
using HealthClinicApp.Interface;

namespace HealthClinicApp.Utility;
class ReceptionistUtilityImpl : IReceptionist
{
    public void AddNewReceptionist()
    {
        try
        {
            using(SqlConnection con = ConnectDB.BuildConnection())
            {
                SqlCommand cmd = new SqlCommand("RegisterReceptionist",con);
                cmd.CommandType = CommandType.StoredProcedure;
                Console.Write("Enter Receptionist Name: ");
                cmd.Parameters.Add("@Name", SqlDbType.VarChar, 50).Value = Console.ReadLine();

                Console.Write("Enter Receptionist Phone: ");
                cmd.Parameters.Add("@Phone", SqlDbType.VarChar, 10).Value = Console.ReadLine();

                con.Open();
                int rows = cmd.ExecuteNonQuery();

                Console.WriteLine(
                    rows > 0 ? "Receptionist added successfully." : "Receptionist insertion failed."
                );
            }
        }
        catch(SqlException ex)
        {
            Console.WriteLine("Database Error: " + ex.Message);
        }
    }


}
