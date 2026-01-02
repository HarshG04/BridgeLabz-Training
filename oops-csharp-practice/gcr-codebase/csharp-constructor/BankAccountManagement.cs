class BankAccount
{
    public string accountNumber;
    protected string accountHolder;
    private double balance;

    public BankAccount(string accNo, string holder, double bal)
    {
        this.accountNumber = accNo;
        this.accountHolder = holder;
        this.balance = bal;
    }

    public double GetBalance()
    {
        return balance;
    }

    public void SetBalance(double bal)
    {
        balance = bal;
    }

    public void ShowAccount()
    {
        Console.WriteLine(accountNumber);
        Console.WriteLine(accountHolder);
        Console.WriteLine(balance);
    }
}

class Program
{
    static void Main()
    {
        BankAccount acc = new BankAccount("ACC101", "Ravi", 5000);
        acc.ShowAccount();
        acc.SetBalance(7500);
        Console.WriteLine(acc.GetBalance());
    }
}