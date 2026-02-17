using Microsoft.Data.SqlClient;

namespace HealthClinicApp.DatabaseConnection;
class ConnectDB
{
    public static SqlConnection BuildConnection()
    {
        string connectionString = @"Server=localhost\SQLEXPRESS;Database=HealthClinicApp;Trusted_Connection=True;TrustServerCertificate=True";
        return new SqlConnection(connectionString);
    }
}