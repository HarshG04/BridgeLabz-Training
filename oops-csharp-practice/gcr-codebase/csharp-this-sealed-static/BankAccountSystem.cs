class BankAccount
{
    static string bankName = "LoL Bank";
    static int totalAccounts;

    readonly int AccountNumber;
    string holderName;

    BankAccount(string name,int anum)
    {
        this.holderName = name;
        this.AccountNumber = anum;
        totalAccounts++;
    }


    static void GetTotalAccounts()
    {
        Console.WriteLine("Total Accounts: "+totalAccounts);
    }

    static void ShowAccountDetails(object acc)
    {
        if(acc is BankAccount account)
        {
            Console.WriteLine("Bank Name: " + bankName);
            Console.WriteLine("Holder Name: " + account.holderName);
            Console.WriteLine("Account Number: "+ account.AccountNumber);
        }
    }

    static void Main()
    {
        BankAccount b1 = new BankAccount("Harsh",125);
        ShowAccountDetails(b1);
        BankAccount.GetTotalAccounts();
        BankAccount b2 = new BankAccount("aditya",258);
        ShowAccountDetails(b2);
        BankAccount.GetTotalAccounts();
    }
} 