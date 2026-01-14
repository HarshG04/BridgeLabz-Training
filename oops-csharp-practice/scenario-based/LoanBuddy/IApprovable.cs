interface IApprovable
{
    bool ApproveLoan(Applicant applicant);
    double CalculateEMI(double amount);
}

