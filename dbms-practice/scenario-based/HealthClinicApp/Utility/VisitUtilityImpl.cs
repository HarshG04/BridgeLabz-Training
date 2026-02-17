using System.Data;
using HealthClinicApp.DatabaseConnection;
using HealthClinicApp.Interface;
using Microsoft.Data.SqlClient;

namespace HealthClinicApp.Utility;

class VisitUtilityImpl : IVisit
{
    public void RecordPatientVisit()
    {
        try
        {
            Console.Write("Enter AppointmentId: ");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Notes: ");
            string notes = Console.ReadLine();
            Console.Write("Enter Diagnosis: ");
            string diagnosis = Console.ReadLine();

            using(SqlConnection con = ConnectDB.BuildConnection())
            {
                SqlCommand cmd = new SqlCommand("RecordPatientVisit",con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@AppointmentID",SqlDbType.Int).Value = id;
                cmd.Parameters.Add("@Notes",SqlDbType.VarChar).Value = notes;
                cmd.Parameters.Add("@Diagnosis",SqlDbType.VarChar).Value = diagnosis;

                con.Open();
                int rows = cmd.ExecuteNonQuery();
                Console.WriteLine(rows>0?"Visit Recorded" : "Error While Recording Visit");
            }
        }
        catch(Exception e)
        {
            Console.WriteLine(e.Message);
        }
        
    }

    public void ViewPatientMedicalHistory()
    {
        try
        {
            Console.Write("Enter Patient ID: ");
            int id = Convert.ToInt32(Console.ReadLine());
            using(SqlConnection con = ConnectDB.BuildConnection())
            {
                SqlCommand cmd = new SqlCommand("ViewPatientMedicalHistory",con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@PatientID",SqlDbType.Int).Value = id;

                con.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine(
                    reader["VisitID"] + " " +
                    reader["VisitDate"] + " " +
                    reader["Diagnosis"] + " " +
                    reader["DoctorID"] + " " +
                    reader["PatientID"]
                );

                }

                reader.Close();
            }
        }
        catch(Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
}