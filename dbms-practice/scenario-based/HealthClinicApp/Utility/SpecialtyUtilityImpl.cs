using System.Data;
using System.Text.RegularExpressions;
using HealthClinicApp.DatabaseConnection;
using HealthClinicApp.Interface;
using Microsoft.Data.SqlClient;

namespace HealthClinicApp.Utility;

class SpecialtyUtilityImpl : ISpecialty
{
    public void AddNewSpecialty()
    {
        try
        {
            Console.Write("Enter Specialty Name: ");
            string name = Console.ReadLine();
            
            using(SqlConnection con = ConnectDB.BuildConnection())
            {
                SqlCommand cmd = new SqlCommand("AddNewSpecialty",con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@SpecialtyName",SqlDbType.VarChar).Value = name;

                con.Open();
                int rows = cmd.ExecuteNonQuery();
                Console.Write(rows>0 ? "Specialty Added Successfully" : "Error While Adding Specialty");
            }
        }
        catch(Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }

    public void DisplayAllSpecialty()
    {
        using(SqlConnection con = ConnectDB.BuildConnection())
        {
            SqlCommand cmd = new SqlCommand("DisplayAllSpecialty",con);
            cmd.CommandType = CommandType.StoredProcedure;


            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine(
                    reader["SpecialtyID"] + " " +
                    reader["SpecialtyName"]
                );
            }

            reader.Close();
        }
    }

    public void UpdateSpecialty()
    {
        try
        {
            Console.Write("Enter Specialty ID/Old Name: ");
            string key = Console.ReadLine();

            Console.Write("Enter New Specialty Name: ");
            string newName = Console.ReadLine();

            bool isId = false;

            string IdRegex = @"^[1-9][0-9]{0,}$";
            if (Regex.IsMatch(key, IdRegex)) isId = true;
 
            using (SqlConnection con = ConnectDB.BuildConnection())
            {
                SqlCommand cmd = new SqlCommand("UpdateSpecialty", con);
                cmd.CommandType = CommandType.StoredProcedure;

                if (isId) cmd.Parameters.Add("@SpecialtyID", SqlDbType.Int).Value = Convert.ToInt32(key);
                else cmd.Parameters.Add("@SpecialtyOldName", SqlDbType.VarChar).Value = key;

                cmd.Parameters.Add("@SpecialtyNewName", SqlDbType.VarChar).Value = newName;

                con.Open();
                int rows = cmd.ExecuteNonQuery();
                Console.WriteLine(rows > 0 ? "Specialty Updated Successfully" : "Specialty Update Failed");
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }


    public void DeleteSpecialty()
    {
        try
        {
            Console.Write("Enter Specialty ID/Name To Delete: ");
            string key = Console.ReadLine();

            bool isId = false;
            string IdRegex = @"^[1-9][0-9]{0,}$";

            if (Regex.IsMatch(key, IdRegex)) isId = true;
    
            using (SqlConnection con = ConnectDB.BuildConnection())
            {
                SqlCommand cmd = new SqlCommand("DeleteSpecialty", con);
                cmd.CommandType = CommandType.StoredProcedure;

                if (isId) cmd.Parameters.Add("@SpecialtyID", SqlDbType.Int).Value = Convert.ToInt32(key);
                else cmd.Parameters.Add("@SpecialtyName", SqlDbType.VarChar).Value = key;

                con.Open();
                int rows = cmd.ExecuteNonQuery();
                Console.WriteLine(rows > 0 ? "Specialty Deleted Successfully" : "Delete Failed");
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }



}