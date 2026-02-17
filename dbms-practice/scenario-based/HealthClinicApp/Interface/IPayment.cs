namespace HealthClinicApp.Interface;

interface IPayment
{
    void GenerateBill();
    void PayBill();
    void ViewOutstandingBills();
    void GenerateRevenueReport();

}