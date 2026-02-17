using HealthClinicApp.DatabaseConnection;
using HealthClinicApp.Interface;
using Microsoft.Data.SqlClient;
using System.Data;

namespace HealthClinicApp.Utility;

class AuditLogUtilityImpl : IAuditLog
{
    public void ViewAuditLogs()
    {
        using(SqlConnection con = ConnectDB.BuildConnection())
        {
            SqlCommand cmd = new SqlCommand("ViewAuditLogs",con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine(
                    reader["AuditLogID"] + " " +
                    reader["RecordID"] + " " +
                    reader["TableName"] + " " +
                    reader["Operation"] + " " +
                    reader["OldValue"] + " " +
                    reader["NewValue"] + " " +
                    reader["CreatedAt"]
                );
            }


            reader.Close();
        }
    }
}