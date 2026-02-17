using System.Data;
using HealthClinicApp.DatabaseConnection;
using HealthClinicApp.Interface;
using Microsoft.Data.SqlClient;

namespace HealthClinicApp.Utility;

class AppointmentUtilityImpl : IAppointment
{
    public void BookAppointment()
    {
        try
        {
            Console.Write("Enter Patient ID: ");
            int patientId = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Doctor ID: ");
            int doctorId = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter time: ");
            TimeOnly time = TimeOnly.Parse(Console.ReadLine());
            Console.Write("Enter Date: ");
            DateOnly date = DateOnly.Parse(Console.ReadLine());

            using(SqlConnection con = ConnectDB.BuildConnection())
            {
                SqlCommand cmd = new SqlCommand("BookAppointment",con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@PatientID",SqlDbType.Int).Value = patientId;
                cmd.Parameters.Add("@DoctorID",SqlDbType.Int).Value = doctorId;
                cmd.Parameters.Add("@Time",SqlDbType.Time).Value = time;
                cmd.Parameters.Add("@Date",SqlDbType.Date).Value = date;

                con.Open();
                int rows = cmd.ExecuteNonQuery();
                Console.WriteLine(rows>0 ? "Appointment Added Successfully." : "Error While Adding Appointment.");
            }
        }
        catch(Exception e)
        {
            Console.WriteLine(e.Message);
        }        
    }

    public void CancelAppointment()
    {
        try
        {
            Console.Write("Enter Appointment ID: ");
            int id = Convert.ToInt32(Console.ReadLine());
            
            using(SqlConnection con = ConnectDB.BuildConnection())
            {
                SqlCommand cmd = new SqlCommand("CancelAppointment",con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@AppointmentID",SqlDbType.Int).Value = id;

                con.Open();
                int rows = cmd.ExecuteNonQuery();

                Console.WriteLine(rows>0 ? "Appointment Cancel Successfully." : "Error While Canceling Appointment.");
            }
        }
        catch(Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }

    public void CheckDoctorAvailability()
    {
        try
        {
            Console.Write("Enter Doctor Id: ");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Date: ");
            DateOnly date = DateOnly.Parse(Console.ReadLine());

            using(SqlConnection con = ConnectDB.BuildConnection())
            {
                SqlCommand cmd = new SqlCommand("CheckDoctorAvailability",con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@DoctorID",SqlDbType.Int).Value = id;
                cmd.Parameters.Add("@Date",SqlDbType.Date).Value = date;

                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine(reader["DoctorID"] + " "+reader["DoctorName"] + " " +reader["StartTime"] +" "+ reader["EndTime"]+" "+reader["MaxPatientsPerSlot"]+" "+reader["Booked"]+" "+reader["Available"]);
                }

                reader.Close();
            }
        }
        catch(Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }

    public void RescheduleAppointment()
    {
        try
        {
            Console.Write("Enter Appointment ID: ");
            int appointmentId = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter New Time: ");
            TimeOnly time = TimeOnly.Parse(Console.ReadLine());
            Console.Write("Enter New Date: ");
            DateOnly date = DateOnly.Parse(Console.ReadLine());
            Console.Write("Enter Doctor Id: ");
            int doctorID = Convert.ToInt32(Console.ReadLine());
            
            using(SqlConnection con = ConnectDB.BuildConnection())
            {
                SqlCommand cmd = new SqlCommand("RescheduleAppointment",con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@AppointmentID",SqlDbType.Int).Value = appointmentId;
                cmd.Parameters.Add("@Time",SqlDbType.Time).Value = time;
                cmd.Parameters.Add("@Date",SqlDbType.Date).Value = date;
                cmd.Parameters.Add("@DoctorID",SqlDbType.Int).Value = doctorID;

                con.Open();
                int rows = cmd.ExecuteNonQuery();

                Console.WriteLine(rows>0 ? "Appointment Rescheduled Successfully" : "Error While Rescheduling");
            }

        }
        catch(Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }

    public void ViewDailyAppointmentSchedule()
    {
        try
        {
            
            Console.WriteLine("Enter date: ");
            string str = Console.ReadLine();
            DateOnly date = DateOnly.MinValue;
            if(str.Length>0) date = DateOnly.Parse(str);

            using(SqlConnection con = ConnectDB.BuildConnection())
            {
                SqlCommand cmd = new SqlCommand("ViewDailyAppointmentSchedule",con);
                cmd.CommandType = CommandType.StoredProcedure;

                if(str.Length>0) cmd.Parameters.Add("@Date",SqlDbType.Date).Value = date;

                con.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine(reader["DoctorName"] + " "+reader["PatientName"] + " " +reader["AppointmentTime"]);
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