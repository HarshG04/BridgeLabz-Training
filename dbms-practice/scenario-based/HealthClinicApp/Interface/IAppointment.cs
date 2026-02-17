namespace HealthClinicApp.Interface;
interface IAppointment
{
    void BookAppointment();
    void CheckDoctorAvailability();
    void CancelAppointment();
    void RescheduleAppointment();
    void ViewDailyAppointmentSchedule();
}