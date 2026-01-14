class AutoLoan : LoanApplication
{
    public AutoLoan(int term) : base("Auto Loan", term, 10.5) { }

    public override bool ApproveLoan(Applicant applicant)
    {
        if (applicant.GetCreditScore() >= 650 && applicant.Income >= 30000)
        {
            isApproved = true;
        }
        else
        {
            isApproved = false;
        }

        return isApproved;
    }

    public override double CalculateEMI(double amount)
    {
        return LoanUtility.CalculateEMI(amount, InterestRate, Term);
    }
}

