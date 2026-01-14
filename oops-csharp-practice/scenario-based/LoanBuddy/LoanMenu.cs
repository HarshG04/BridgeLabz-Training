class LoanMenu
{
    public void Menu()
    {
        while (true)
        {
            Console.WriteLine("\n===== LoanBuddy Menu =====");
            Console.WriteLine("1. Apply for Loan");
            Console.WriteLine("2. Exit");
            Console.Write("Enter choice: ");

            int menuChoice = Convert.ToInt32(Console.ReadLine());

            switch (menuChoice)
            {
                case 1:
                    ApplyLoan();
                    break;

                case 2:
                    Console.WriteLine("Thank you for using LoanBuddy!");
                    return; // exits Start()

                default:
                    Console.WriteLine("Invalid choice. Try again.");
                    break;
            }
        }
    }

    private void ApplyLoan()
    {
        // Applicant details
        Console.Write("Enter Name: ");
        string name = Console.ReadLine();

        Console.Write("Enter Monthly Income: ");
        double income = Convert.ToDouble(Console.ReadLine());

        Console.Write("Enter Loan Amount: ");
        double loanAmount = Convert.ToDouble(Console.ReadLine());

        Console.Write("Enter Credit Score: ");
        int creditScore = Convert.ToInt32(Console.ReadLine());

        Applicant applicant =
            new Applicant(name, income, loanAmount, creditScore);

        Console.WriteLine("\nSelect Loan Type:");
        Console.WriteLine("1. Home Loan");
        Console.WriteLine("2. Auto Loan");
        Console.Write("Enter choice: ");

        int loanChoice = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter Loan Term (in months): ");
        int term = Convert.ToInt32(Console.ReadLine());

        LoanApplication loan = null;

        switch (loanChoice)
        {
            case 1:
                loan = new HomeLoan(term);
                break;

            case 2:
                loan = new AutoLoan(term);
                break;

            default:
                Console.WriteLine("Invalid loan type.");
                return;
        }

        bool approved = loan.ApproveLoan(applicant);

        Console.WriteLine("\n===== Loan Result =====");
        Console.WriteLine("Loan Type: " + loan.LoanType);
        Console.WriteLine("Approved: " + approved);

        if (approved)
        {
            double emi = loan.CalculateEMI(applicant.LoanAmount);
            Console.WriteLine("Monthly EMI: " + emi);
        }
        else
        {
            Console.WriteLine("Loan rejected due to eligibility rules.");
        }
    }
}

