class LoanUtility
{
    public static double CalculateEMI(double principal, double rate, int months)
    {
        double monthlyRate = rate / (12 * 100);
        double emi = (principal * monthlyRate *
                    Math.Pow(1 + monthlyRate, months)) /
                    (Math.Pow(1 + monthlyRate, months) - 1);

        return emi;
    }
}