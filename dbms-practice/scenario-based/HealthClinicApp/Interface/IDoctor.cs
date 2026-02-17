namespace HealthClinicApp.Interface;

interface IDoctor
{
    void RegisterNewDoctor();
    void AddDoctorSchedule();
    void SetDoctorSpecility();
    void ViewDoctorsBySpecialty();
    void DeactivateDoctorProfile();
}