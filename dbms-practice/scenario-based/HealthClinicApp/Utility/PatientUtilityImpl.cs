using System.Data;
using System.Text.RegularExpressions;
using HealthClinicApp.DatabaseConnection;
using HealthClinicApp.Exceptions;
using HealthClinicApp.Interface;
using Microsoft.Data.SqlClient;

namespace HealthClinicApp.Utility;

class PatientUtilityImpl : IPatient
{
    public void AddNewPatient()
    {
        try
        {
            Console.Write("Enter Name: ");
            string name = Console.ReadLine();
            if(!Regex.IsMatch(name,@"^[a-zA-Z]+(\s+[a-zA-Z]+)*$")) throw new InvalidInputException("Patient Name Input is Not Correct ");

            Console.Write("Enter Phone: ");
            string phone = Console.ReadLine();
            if(!Regex.IsMatch(phone,@"^[1-9][0-9]{9}$")) throw new InvalidInputException("Patient Phone Input is Not Correct ");

            Console.Write("Enter Date Of Birth[dd-mm-yyyy]: ");
            string dob = Console.ReadLine();
            if(!Regex.IsMatch(dob,@"^(0[1-9]|[12][0-9]|[3][01])-(0[1-9]|1[0-2])-[12][0-9]{3}$")) throw new InvalidInputException("Patient DOB Input is Not Correct ");

            Console.Write("Enter Address: ");
            string address = Console.ReadLine();

            Console.Write("Enter Blood Group: ");
            string bloodGroup = Console.ReadLine();
            
            using (SqlConnection con = ConnectDB.BuildConnection())
            {
                SqlCommand cmd = new SqlCommand("RegisterPatient",con);
                cmd.CommandType = CommandType.StoredProcedure;
                
                cmd.Parameters.Add("@Name", SqlDbType.VarChar).Value = name;
                cmd.Parameters.Add("@DOB", SqlDbType.Date).Value = DateOnly.ParseExact(dob, "dd-MM-yyyy", null);
                cmd.Parameters.Add("@Phone", SqlDbType.VarChar).Value = phone;
                cmd.Parameters.Add("@Address", SqlDbType.VarChar).Value = address;
                cmd.Parameters.Add("@BloodGroup", SqlDbType.VarChar).Value = bloodGroup;

                con.Open();
                int rows = cmd.ExecuteNonQuery();
                Console.WriteLine(
                    rows>0 ? "New Patient Added SuccessFully." : "Patient data Failed to Add"
                );
                
            }
        }
        catch(InvalidInputException e)
        {
            Console.WriteLine(e.Message);
        }
        catch(Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }

    public void SearchPatientRecord()
    {
        try
        {
            Console.Write("Enter Id/Phone/Name To Search: ");
            string key = Console.ReadLine();

            bool isId = false;
            bool isPhone = false;
            bool isName = false;
            
            string IdRegex = @"^[1-9][0-9]{0,}$";
            string PhoneRegex = @"^[1-9][0-9]{9}$";
            string NameRegex = @"^[a-zA-Z]+(\s+[a-zA-Z]+)*$";

            if(Regex.IsMatch(key,PhoneRegex)) isPhone = true;
            else if(Regex.IsMatch(key,IdRegex)) isId = true;
            else if(Regex.IsMatch(key,NameRegex)) isName = true;
            else throw new Exception("Id/Phone/Name Input Is Not Correct");

            using (SqlConnection con = ConnectDB.BuildConnection())
            {
                SqlCommand cmd = new SqlCommand("SearchPatientRecord",con);
                cmd.CommandType = CommandType.StoredProcedure;

                if(isId) cmd.Parameters.Add("@PatientID",SqlDbType.Int).Value = Convert.ToInt32(key);
                else if(isPhone) cmd.Parameters.Add("@Phone",SqlDbType.VarChar).Value = key;
                else if(isName) cmd.Parameters.Add("@Name",SqlDbType.VarChar).Value = key;

                con.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine(reader["PatientID"] + " " +reader["PatientName"] +" "+ reader["DOB"]+" "+reader["Phone"]+" "+reader["BloodGroup"]+" "+reader["Address"]);
                }

                reader.Close();
            
            }
        
        }
        catch(InvalidInputException e)
        {
            Console.WriteLine(e.Message);
        }
        catch(Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }

    public void UpdatePatientInfo()
    {
        try
        {
            Console.Write("Enter Id/Phone: ");
            string key = Console.ReadLine();

            Console.Write("Enter Updated Name: ");
            string name = Console.ReadLine();
            if(!Regex.IsMatch(name,@"^[a-zA-z]{3,}[\s]*[a-zA-Z]*$")) throw new InvalidInputException("Patient Name Input is Not Correct ");

            Console.Write("Enter Updated Phone: ");
            string phone = Console.ReadLine();
            if(!Regex.IsMatch(phone,@"^[1-9][0-9]{9}$")) throw new InvalidInputException("Patient Phone Input is Not Correct ");

            Console.Write("Enter Updated DOB: ");
            string dob = Console.ReadLine();
            if(!Regex.IsMatch(dob,@"^(0[1-9]|[12][0-9]|[3][01])-(0[1-9]|1[0-2])-[12][0-9]{3}$")) throw new InvalidInputException("Patient DOB Input is Not Correct ");


            Console.Write("Enter Updated Address: ");
            string address = Console.ReadLine();
            Console.Write("Enter Updated BloodGroup: ");
            string bloodGroup = Console.ReadLine();

            bool isId = false;
            bool isPhone = false;
            string IdRegex = @"^[1-9][0-9]{0,}$";
            string PhoneRegex = @"^[1-9][0-9]{9}$";

            if(Regex.IsMatch(key,PhoneRegex)) isPhone = true;
            else if(Regex.IsMatch(key,IdRegex)) isId = true;
            else throw new Exception("Id/Phone Input Is Not Correct");

            using (SqlConnection con = ConnectDB.BuildConnection())
            {
                SqlCommand cmd = new SqlCommand("UpdatePatientInfo",con);
                cmd.CommandType = CommandType.StoredProcedure;

                if(isId) cmd.Parameters.Add("@PatientID",SqlDbType.Int).Value = Convert.ToInt32(key);
                else if(isPhone) cmd.Parameters.Add("@Phone",SqlDbType.VarChar).Value = key;

                cmd.Parameters.Add("@Name", SqlDbType.VarChar).Value = name;
                cmd.Parameters.Add("@DOB", SqlDbType.Date).Value = DateOnly.ParseExact(dob, "dd-MM-yyyy", null);
                if(phone.Length!=0) cmd.Parameters.Add("@NewPhone", SqlDbType.VarChar).Value = phone;
                cmd.Parameters.Add("@Address", SqlDbType.VarChar).Value = address;
                cmd.Parameters.Add("@BloodGroup", SqlDbType.VarChar).Value = bloodGroup;
                
                con.Open();
                int rows = cmd.ExecuteNonQuery();
                Console.WriteLine(rows>0 ? "Patient Updated Successfully." : "Patient Not Updated.");
            }
        }
        catch(InvalidInputException e)
        {
            Console.WriteLine(e.Message);
        }
        catch(Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }

    public void ViewPatientHistory()
    {
        try
        {
            Console.Write("Enter Patient ID: ");
            string id = Console.ReadLine();

            if (!Regex.IsMatch(id, @"^[1-9][0-9]{0,}$")){
                throw new InvalidInputException("Id Input Type Is Not Valid");
            }

            using(SqlConnection con = ConnectDB.BuildConnection())
            {
                SqlCommand cmd = new SqlCommand("ViewPatientHistory",con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@PatientID",SqlDbType.Int).Value = Convert.ToInt32(id);
                con.Open();
                
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine(reader["PatientID"] + " " +reader["PatientName"] +" "+ reader["DoctorID"]+" "+reader["DoctorName"]+" "+reader["AppointmentID"]+" "+reader["VisitID"]+" "+reader["Diagnosis"]);
                }

                reader.Close();
            }
        }
        catch(InvalidInputException e)
        {
            Console.WriteLine(e.Message);
        }
        catch(Exception e)
        {
            Console.WriteLine(e.Message);
        }
        

    }
}