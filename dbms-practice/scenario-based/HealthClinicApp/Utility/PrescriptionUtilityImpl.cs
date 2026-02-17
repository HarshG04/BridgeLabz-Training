using System.Collections;
using System.Data;
using HealthClinicApp.DatabaseConnection;
using HealthClinicApp.Interface;
using Microsoft.Data.SqlClient;

namespace HealthClinicApp.Utility;

class PrescriptionUtilityImpl : IPrescription
{
    public void CreatePrescription()
    {
        try
        {
            Console.Write("Enter Visit Id: ");
            int id = Convert.ToInt32(Console.ReadLine());
            
            using(SqlConnection con = ConnectDB.BuildConnection())
            {
                SqlCommand cmd = new SqlCommand("CreatePrescription",con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@VisitID",SqlDbType.Int).Value = id;

                con.Open();
                int rows = cmd.ExecuteNonQuery();

                Console.WriteLine(rows>0 ? "Prescription Added Successfully" : "Error While Adding Prescription");
            }
        }
        catch(Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }

    public void AddMedicine()
    {
        try
        {
            Console.Write("Enter Prescription ID: ");
            int id = Convert.ToInt32(Console.ReadLine());

            IList<string[]> medicines = new List<string[]>();
            char ch = 'y';
            do
            {
                string[] med = new string[3];
                Console.Write("Enter Medine Name: ");
                med[0] = Console.ReadLine();
                Console.Write("Enter Dosage: ");
                med[1] = Console.ReadLine();
                Console.Write("Enter Duration: ");
                med[2] = Console.ReadLine();

                medicines.Add(med);

                Console.Write("Another Medicine[y|n]");
                ch = Console.ReadLine()[0];
            }while(ch!='n' && ch!='N');

            using(SqlConnection con = ConnectDB.BuildConnection())
            {
                SqlCommand cmd = new SqlCommand("AddMedicine",con);
                cmd.CommandType = CommandType.StoredProcedure;

                con.Open();
                int rows = 0;
                foreach(string[] med in medicines)
                {
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add("@PrescriptionID",SqlDbType.Int).Value = id;
                    cmd.Parameters.Add("@MedicineName",SqlDbType.VarChar).Value = med[0];
                    cmd.Parameters.Add("@Dosage",SqlDbType.VarChar).Value = med[1];
                    cmd.Parameters.Add("@Duration",SqlDbType.VarChar).Value = med[2];

                    rows += cmd.ExecuteNonQuery();
                }
                Console.WriteLine(rows>0 ? "Medicines Added Successfully" : "Error While Adding Medicines");
            }

        }
        catch(Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
}