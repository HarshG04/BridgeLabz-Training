namespace BankAccount.Tests;

public class BankAccTests
{

    [Test]
    public void Test_Deposit_ValidAmount()
    {
        BankAcc account = new BankAcc(100);
        account.Deposit(500);

        Assert.That(600,Is.EqualTo(account.GetBalance()));
    }

    [Test]
    public void Test_Deposit_NegativeAmount()
    {
        BankAcc account = new BankAcc(100);

        Assert.That(()=> account.Deposit(-10), Throws.TypeOf<InvalidAmountException>().With.Message.EqualTo("Deposit amount cannot be negative"));
    }

    [Test]
    public void Test_Withdraw_ValidAmount()
    {
        BankAcc account = new BankAcc(650);
        account.Withdraw(120);

        Assert.That(530,Is.EqualTo(account.GetBalance()));
    }

    [Test]
    public void Test_Withdraw_InsufficientFunds()
    {
        BankAcc account = new BankAcc(100);

        Assert.That(()=> account.Withdraw(150), Throws.TypeOf<InvalidAmountException>().With.Message.EqualTo("Insufficient funds."));

    }
}
