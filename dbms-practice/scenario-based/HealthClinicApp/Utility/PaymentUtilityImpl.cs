using System.Data;
using HealthClinicApp.DatabaseConnection;
using HealthClinicApp.Interface;
using Microsoft.Data.SqlClient;

namespace HealthClinicApp.Utility;

class PaymentUtilityImpl : IPayment
{
    public void GenerateBill()
    {
        try
        {
            Console.Write("Enter Visit Id: ");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Additional Charges: ");
            decimal additionalFee = Convert.ToDecimal(Console.ReadLine());
            Console.Write("Enter Discount Amount: ");
            decimal discount = Convert.ToDecimal(Console.ReadLine());

            using(SqlConnection con = ConnectDB.BuildConnection())
            {
                SqlCommand cmd = new SqlCommand("GenerateBill",con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@VisitID",SqlDbType.Int).Value = id;
                cmd.Parameters.Add("@AdditionalCharges",SqlDbType.Decimal).Value = additionalFee;
                cmd.Parameters.Add("@DiscountAmount",SqlDbType.Decimal).Value = discount;

                con.Open();
                int rows = cmd.ExecuteNonQuery();
                Console.WriteLine(rows>0?"Bill Generated Successfully" : "Error While Generating Bill");
            }   
        }
        catch(FormatException)
        {
            Console.WriteLine("Error: Invalid input format. Please enter valid numbers.");
        }
        catch(Exception e)
        {
            Console.WriteLine("Error: " + e.Message);
        }
    }

    public void PayBill()
    {
        Console.Write("Enter Bill Id: ");
        int id = Convert.ToInt32(Console.ReadLine());
        Console.Write("Enter Amount To diposit: ");
        decimal amount = Convert.ToDecimal(Console.ReadLine());
        Console.Write("Enter Payment Mode: ");
        string payMode = Console.ReadLine();
        
        using(SqlConnection con = ConnectDB.BuildConnection())
        {
            SqlCommand cmd = new SqlCommand("PayBill",con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@BillID",SqlDbType.Int).Value = id;
            cmd.Parameters.Add("@Amount",SqlDbType.Decimal).Value = amount;
            cmd.Parameters.Add("@PaymentMode",SqlDbType.VarChar).Value = payMode;

            con.Open();
            int rows = cmd.ExecuteNonQuery();
            Console.WriteLine(rows>0?"Payment Successfully" : "Error While Payment");
        }
    }

    public void ViewOutstandingBills()
    {
        using(SqlConnection con = ConnectDB.BuildConnection())
        {
            SqlCommand cmd = new SqlCommand("ViewOutstandingBills",con);
            cmd.CommandType = CommandType.StoredProcedure;
            
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine(
                reader["PatientID"] + " " +
                reader["PatientName"] + " " +
                reader["BillID"] + " " +
                reader["TotalBill"] + " " +
                reader["PaymentStatus"]
            );

            }

            reader.Close();
            
        }   
    }

    public void GenerateRevenueReport()
    {
        using(SqlConnection con = ConnectDB.BuildConnection())
        {
            Console.Write("Enter Start Date (yyyy-MM-dd): ");
            DateOnly startDate = DateOnly.Parse(Console.ReadLine());

            Console.Write("Enter End Date (yyyy-MM-dd): ");
            DateOnly endDate = DateOnly.Parse(Console.ReadLine());

            Console.Write("Enter Minimum Revenue (press Enter for 0): ");
            string minRevInput = Console.ReadLine()?.Trim() ?? "";
            decimal minRevenue = string.IsNullOrEmpty(minRevInput) ? 0 : Convert.ToDecimal(minRevInput);

            SqlCommand cmd = new SqlCommand("GenerateRevenueReport",con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@StartDate", SqlDbType.Date).Value = startDate;
            cmd.Parameters.Add("@EndDate", SqlDbType.Date).Value = endDate;
            cmd.Parameters.Add("@MinRevenue", SqlDbType.Decimal).Value = minRevenue;

            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine(
                    reader["RevenueDate"] + " " +
                    reader["DoctorName"] + " " +
                    reader["SpecialtyName"] + " " +
                    reader["TotalRevenue"]
                );

            }

            reader.Close();
        } 
    }
}