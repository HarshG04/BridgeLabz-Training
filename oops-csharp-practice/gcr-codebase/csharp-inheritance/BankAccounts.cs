using System;

public class BankAccount
{
    public string accountNumber;
    public double balance;
    public virtual void DisplayAccountType()
    {
        Console.WriteLine($"AccountNumber: {accountNumber}, Balance: {balance}");
    }
}

public class SavingsAccount : BankAccount
{
    public double interestRate;
    public override void DisplayAccountType()
    {
        Console.WriteLine($"SavingsAccount - AccountNumber: {accountNumber}, Balance: {balance}, InterestRate: {interestRate}");
    }
}

public class CheckingAccount : BankAccount
{
    public double withdrawalLimit;
    public override void DisplayAccountType()
    {
        Console.WriteLine($"CheckingAccount - AccountNumber: {accountNumber}, Balance: {balance}, WithdrawalLimit: {withdrawalLimit}");
    }
}

public class FixedDepositAccount : BankAccount
{
    public int tenureMonths;
    public override void DisplayAccountType()
    {
        Console.WriteLine($"FixedDepositAccount - AccountNumber: {accountNumber}, Balance: {balance}, TenureMonths: {tenureMonths}");
    }
}

public class Program
{
    public static void Main()
    {
        BankAccount savings = new SavingsAccount { accountNumber = "SA123", balance = 5000, interestRate = 3.5 };
        BankAccount checking = new CheckingAccount { accountNumber = "CA456", balance = 1500, withdrawalLimit = 500 };
        BankAccount fd = new FixedDepositAccount { accountNumber = "FD789", balance = 10000, tenureMonths = 12 };
        savings.DisplayAccountType();
        checking.DisplayAccountType();
        fd.DisplayAccountType();
    }
}

