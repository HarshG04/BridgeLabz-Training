
class Applicant
{
    public string Name { get; }
    public double Income { get; }
    public double LoanAmount { get; }

    private int creditScore;

    public Applicant(string name, double income, double loanAmount, int creditScore)
    {
        Name = name;
        Income = income;
        LoanAmount = loanAmount;
        this.creditScore = creditScore;
    }

    protected internal int GetCreditScore()
    {
        return creditScore;
    }
}

