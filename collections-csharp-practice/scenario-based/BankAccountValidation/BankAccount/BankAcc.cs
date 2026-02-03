namespace BankAccount;

public class BankAcc
{
    private double Balance {get;set;}
    
    public BankAcc(double initialBalance)
    {
        this.Balance = initialBalance;
    }

    public double GetBalance() => Balance;

    public void Deposit(double amount)
    {
        if(amount<0) throw new InvalidAmountException("Deposit amount cannot be negative");

        this.Balance += amount;

    }

    public void Withdraw(double amount)
    {
       
        if(amount>this.Balance) throw new InvalidAmountException("Insufficient funds.");

        this.Balance -= amount;
        
    }
}

