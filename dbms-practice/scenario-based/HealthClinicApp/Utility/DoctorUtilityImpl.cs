using System.Data;
using System.Text.RegularExpressions;
using HealthClinicApp.DatabaseConnection;
using HealthClinicApp.Exceptions;
using HealthClinicApp.Interface;
using Microsoft.Data.SqlClient;

namespace HealthClinicApp.Utility;

class DoctorUtilityImpl : IDoctor
{

    public void RegisterNewDoctor()
    {
        try
        {
            Console.Write("Enter Name: ");
            string name = Console.ReadLine();
            if(!Regex.IsMatch(name,@"^[a-zA-Z]+(\s+[a-zA-Z]+)*$")) throw new InvalidInputException("Doctor Name Input is Not Correct ");

            Console.Write("Enter Phone: ");
            string phone = Console.ReadLine();
            if(!Regex.IsMatch(phone,@"^[1-9][0-9]{9}$")) throw new InvalidInputException("Doctor Phone Input is Not Correct ");

            Console.Write("Enter Fee: ");
            string fee = Console.ReadLine();
            if(!Regex.IsMatch(fee,@"^\d+(\.\d{1,2})?$")) throw new InvalidInputException("Doctor Fee Input is Not Correct ");

            Console.Write("Enter Specialty Name: ");
            string specialty = Console.ReadLine();
            
            using(SqlConnection con = ConnectDB.BuildConnection())
            {
                SqlCommand cmd = new SqlCommand("RegisterDoctor",con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@Name", SqlDbType.VarChar).Value = name;
                cmd.Parameters.Add("@Phone", SqlDbType.VarChar).Value = phone;
                cmd.Parameters.Add("@SpecialtyName", SqlDbType.VarChar).Value = specialty;
                cmd.Parameters.Add("@Fee", SqlDbType.Decimal).Value = Convert.ToDecimal(fee);

                con.Open();
                int rows = cmd.ExecuteNonQuery();
                Console.WriteLine(rows>0 ? "New Doctor Added Successfully" : "Doctor Not Added");
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

    public void AddDoctorSchedule()
    {
        try
        {
            Console.Write("Enter Doctor ID: ");
            int doctorId = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter Day Of Week (Monday-Sunday): ");
            string day = Console.ReadLine();

            Console.Write("Enter Start Time (HH:mm): ");
            TimeOnly start = TimeOnly.Parse(Console.ReadLine());

            Console.Write("Enter End Time (HH:mm): ");
            TimeOnly end = TimeOnly.Parse(Console.ReadLine());

            Console.Write("Enter Slot Duration (minutes): ");
            int slot = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter Max Patients Per Slot: ");
            int max = Convert.ToInt32(Console.ReadLine());

            using(SqlConnection con = ConnectDB.BuildConnection())
            {
                SqlCommand cmd = new SqlCommand("AddDoctorSchedule", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@DoctorID", SqlDbType.Int).Value = doctorId;
                cmd.Parameters.Add("@DayOfWeek", SqlDbType.VarChar).Value = day;
                cmd.Parameters.Add("@StartTime", SqlDbType.Time).Value = start.ToTimeSpan();
                cmd.Parameters.Add("@EndTime", SqlDbType.Time).Value = end.ToTimeSpan();
                cmd.Parameters.Add("@SlotDuration", SqlDbType.Int).Value = slot;
                cmd.Parameters.Add("@MaxPatientsPerSlot", SqlDbType.Int).Value = max;

                con.Open();
                int rows = cmd.ExecuteNonQuery();

                Console.WriteLine(rows > 0 ? 
                    "Doctor Schedule Added Successfully" : 
                    "Error While Adding Schedule");
            }
        }
        catch(Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }


    public void SetDoctorSpecility()
    {
        try
        {
            Console.Write("Enter Doctor Id: ");
            string id = Console.ReadLine();
            if(!Regex.IsMatch(id,@"^[1-9][0-9]{0,}$")) throw new InvalidInputException("Doctor Id Input is Not Correct ");

            Console.Write("Enter Specialty Name: ");
            string specialty = Console.ReadLine();
            
            using(SqlConnection con = ConnectDB.BuildConnection())
            {
                SqlCommand cmd = new SqlCommand("SetDoctorSpecility",con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@DoctorID", SqlDbType.Int).Value = Convert.ToInt32(id);
                cmd.Parameters.Add("@SpecialtyName", SqlDbType.VarChar).Value = specialty;

                con.Open();
                int rows = cmd.ExecuteNonQuery();
                Console.WriteLine(rows>0 ? "Doctor's Specialty Updated Successfully" : "Doctor's Specialty Not Updated");
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

    public void ViewDoctorsBySpecialty()
    {
        try
        {
            Console.Write("Enter Specialty Name: ");
            string specialty = Console.ReadLine();
            
            using(SqlConnection con = ConnectDB.BuildConnection())
            {
                SqlCommand cmd = new SqlCommand("ViewDoctorsBySpecialty",con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@SpecialtyName", SqlDbType.VarChar).Value = specialty;

                con.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine(reader["DoctorID"] + " "+reader["DoctorName"] + " " +reader["SpecialtyName"] +" "+ reader["StartTime"]+" "+reader["EndTime"]);
                }

                reader.Close();
            }
        }
        catch(SqlException e)
        {
            Console.WriteLine(e.Message);
        }
        catch(Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
    public void DeactivateDoctorProfile()
    {
        try
        {
            Console.Write("Enter Doctor ID: ");
            string id = Console.ReadLine();
            if(!Regex.IsMatch(id,@"^[1-9][0-9]{0,}$")) throw new InvalidInputException("Doctor Id Input is Not Correct ");

            using(SqlConnection con = ConnectDB.BuildConnection())
            {
                SqlCommand cmd = new SqlCommand("DeactivateDoctorProfile",con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@DoctorID", SqlDbType.Int).Value = Convert.ToInt32(id);
                con.Open();
                int rows = cmd.ExecuteNonQuery();

                Console.WriteLine(rows>0 ? "Doctor Deactivated Successfully" : "Doctor Not Deactivated");

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