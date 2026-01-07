using System;
using System.Collections.Generic;

abstract class BankAccount
{
    private string accountNumber;
    private string holderName;
    private double balance;

    public string AccountNumber
    {
        get => accountNumber;
        set => accountNumber = value ?? string.Empty;
    }

    public string HolderName
    {
        get => holderName;
        set => holderName = value ?? string.Empty;
    }

    public double Balance
    {
        get => balance;
        protected set => balance = value;
    }

    internal virtual string GetInternalInfo() => "BaseAccount";

    public BankAccount(string acc, string holder, double balance)
    {
        AccountNumber = acc;
        HolderName = holder;
        Balance = balance;
    }

    public void Deposit(double amount)
    {
        if (amount > 0) Balance += amount;
    }

    public bool Withdraw(double amount)
    {
        if (amount > 0 && amount <= Balance)
        {
            Balance -= amount;
            return true;
        }
        return false;
    }

    public abstract double CalculateInterest();
}

interface ILoanable
{
    bool ApplyForLoan(double amount);
    double CalculateLoanEligibility();
}

class SavingsAccount : BankAccount, ILoanable
{
    private double interestRate;

    public SavingsAccount(string acc, string holder, double balance, double interestRate) : base(acc, holder, balance)
    {
        this.interestRate = interestRate;
    }

    internal override string GetInternalInfo() => "Savings";

    public override double CalculateInterest() => Balance * interestRate;

    public bool ApplyForLoan(double amount) => amount <= CalculateLoanEligibility();

    public double CalculateLoanEligibility() => Balance * 2; // simple rule
}

class CurrentAccount : BankAccount, ILoanable
{
    private double overdraftLimit;

    public CurrentAccount(string acc, string holder, double balance, double overdraftLimit) : base(acc, holder, balance)
    {
        this.overdraftLimit = overdraftLimit;
    }

    internal override string GetInternalInfo() => "Current";

    public override double CalculateInterest() => 0; // no interest

    public bool ApplyForLoan(double amount) => amount <= CalculateLoanEligibility();

    public double CalculateLoanEligibility() => Balance + overdraftLimit;
}

class ProgramBanking
{
    static void Main()
    {
        var accounts = new List<BankAccount>
        {
            new SavingsAccount("S-100", "Carol", 1000, 0.04),
            new CurrentAccount("C-200", "Dave", 200, 500)
        };

        foreach (var acc in accounts)
        {
            Console.WriteLine($"Account: {acc.AccountNumber}, Holder: {acc.HolderName}, Balance: {acc.Balance:C}");
            Console.WriteLine($"Type: {acc.GetType().Name}, Interest: {acc.CalculateInterest():C}");
            if (acc is ILoanable loan)
            {
                Console.WriteLine($"Loan Eligible: {loan.CalculateLoanEligibility():C}");
            }
            Console.WriteLine();
        }
    }
}
