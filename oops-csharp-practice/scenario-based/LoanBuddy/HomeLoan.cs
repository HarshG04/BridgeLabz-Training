class HomeLoan : LoanApplication
{
    public HomeLoan(int term) : base("Home Loan", term, 8.5) { }

    public override bool ApproveLoan(Applicant applicant)
    {
        if (applicant.GetCreditScore() >= 700 && applicant.Income >= 50000)
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

