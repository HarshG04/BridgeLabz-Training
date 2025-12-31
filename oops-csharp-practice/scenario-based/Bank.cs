using System;

class Bank
{
    static int nextId = 101;
    public static int minBalance = 1000;
    static string bankName = "LoL Bank";

    public int accountCapacity = 0;
    public int activeAccount = 0;
    public User[] users;
    public string branchName;
    public string branchId;

    public Bank(string branchName, int capacity)
    {
        this.branchName = branchName;
        this.accountCapacity = capacity;
        users = new User[capacity];
        this.branchId = "B" + nextId;
        nextId++;
    }

    public void ShowBranchDetails()
    {
        Console.WriteLine($"\nBank Name  : {bankName}");
        Console.WriteLine($"Branch Name: {branchName}");
        Console.WriteLine($"Branch ID  : {branchId}");
    }
}

class Manager
{
    static int nextId = 101;
    private Bank bank;
    private string managerName;
    private string managerId;
    private int managerPassword;

    public Manager(string name, int pass, Bank b)
    {
        managerName = name;
        managerPassword = pass;
        bank = b;
        managerId = "M" + nextId;
        nextId++;
    }

    public bool Login(int pass)
    {
        if (pass == managerPassword)
        {
            Console.WriteLine("Login Successful!");
            return true;
        }
        return false;
    }

    public void CreateNewAccount()
    {
        if (bank.activeAccount >= bank.accountCapacity)
        {
            Console.WriteLine("------ Bank Capacity is full -----");
            return;
        }

        Console.Write("Enter User Name: ");
        string name = Console.ReadLine();

        Console.Write("Enter PIN: ");
        int pin = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter Initial Amount: ");
        int amount = Convert.ToInt32(Console.ReadLine());

        if (amount < Bank.minBalance)
        {
            Console.WriteLine($"Opening balance must be at least {Bank.minBalance}");
            return;
        }

        User newUser = new User(name, pin, amount, bank.branchId);
        bank.users[bank.activeAccount] = newUser;
        bank.activeAccount++;

        Console.WriteLine("\n--- New User Registered Successfully ---");
        newUser.ViewAccount();
    }

    public User FindAccount(string accId)
    {
        for (int i = 0; i < bank.activeAccount; i++)
        {
            if (bank.users[i].accountId.Equals(accId))
            {
                return bank.users[i];
            }
        }

        Console.WriteLine("--- User Not Found ---");
        return null;
    }

    public void ViewAccount(string accId)
    {
        User user = FindAccount(accId);
        if (user == null) return;

        user.ViewAccount();
    }

    public void DepositMoney(string accId, int amnt)
    {
        User user = FindAccount(accId);
        if (user == null) return;

        user.DepositMoney(amnt);
    }

    public void WithdrawMoney(string accId, int amnt)
    {
        User user = FindAccount(accId);
        if (user == null) return;

        if (amnt <= user.accountAmount && user.accountAmount - amnt >= Bank.minBalance)
        {
            user.accountAmount -= amnt;
            Console.WriteLine("Amount Withdrawn Successfully");
        }
        else
        {
            Console.WriteLine("Minimum balance condition not satisfied");
        }
    }
}

class User
{
    private static int nextId = 101;
    public string userName;
    public string accountId;
    private int accountPIN;
    string branchId;
    public int accountAmount = 0;

    public User(string name, int pin, int amount, string branchId)
    {
        userName = name;
        accountPIN = pin;
        this.branchId = branchId;

        accountId = "U" + nextId;
        accountAmount = amount;
        nextId++;
    }

    public bool Login(int pin)
    {
        if (pin == accountPIN)
        {
            Console.WriteLine("Login Successful!");
            return true;
        }

        Console.WriteLine("Wrong PIN!");
        return false;
    }

    public void ViewAccount()
    {
        Console.WriteLine("\n----- User Details -----");
        Console.WriteLine("Name      : " + userName);
        Console.WriteLine("AccountId : " + accountId);
        Console.WriteLine("Balance   : " + accountAmount);
        Console.WriteLine("------------------------");
    }

    public void DepositMoney(int amnt)
    {
        if (amnt <= 0) return;
        accountAmount += amnt;
        Console.WriteLine("Amount Deposited Successfully");
    }

    public void WithdrawMoney(int amnt)
    {
        if (accountAmount - amnt >= Bank.minBalance)
        {
            accountAmount -= amnt;
            Console.WriteLine("Amount Withdrawn Successfully");
        }
        else
        {
            Console.WriteLine("Minimum balance condition not satisfied");
        }
    }
}

class MathematicalUtility
{
    public static long FactorialFun(int num)
    {
        if (num < 0) return -1;
        if (num == 0) return 1;
        return num * FactorialFun(num - 1);
    }

    public static bool PrimeFun(int num)
    {
        if (num == 0 || num == 1) return false;
        for (int i = 2; i * i <= num; i++)
            if (num % i == 0) return false;
        return true;
    }

    public static int GCDFun(int a, int b)
    {
        a = Math.Abs(a);
        b = Math.Abs(b);
        if (b == 0) return a;
        return GCDFun(b, a % b);
    }

    public static int FibonacciFun(int n)
    {
        if (n < 0) return -1;
        if (n == 0) return 0;
        if (n == 1) return 1;

        int a = 0, b = 1, c = 0;
        for (int i = 2; i <= n; i++)
        {
            c = a + b;
            a = b;
            b = c;
        }
        return c;
    }

    public static void RunMathUtility()
    {
        while (true)
        {
            Console.WriteLine("\n---- MATH UTILITY ----");
            Console.WriteLine("1. Factorial");
            Console.WriteLine("2. Prime Check");
            Console.WriteLine("3. GCD");
            Console.WriteLine("4. Fibonacci");
            Console.WriteLine("5. Back");
            Console.Write("Choice: ");

            int ch = Convert.ToInt32(Console.ReadLine());

            switch (ch)
            {
                case 1:
                    Console.Write("Enter number: ");
                    int f = Convert.ToInt32(Console.ReadLine());
                    long fr = FactorialFun(f);
                    Console.WriteLine(fr == -1 ? "Invalid" : "Result = " + fr);
                    break;

                case 2:
                    Console.Write("Enter number: ");
                    int p = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine(PrimeFun(p) ? "Prime" : "Not Prime");
                    break;

                case 3:
                    Console.Write("Enter A: ");
                    int a = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Enter B: ");
                    int b = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("GCD = " + GCDFun(a, b));
                    break;

                case 4:
                    Console.Write("Enter N: ");
                    int n = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Result = " + FibonacciFun(n));
                    break;

                case 5:
                    return;

                default:
                    Console.WriteLine("Invalid Choice");
                    break;
            }
        }
    }
}

class Program
{
    static void Main()
    {
        while (true)
        {
            Console.WriteLine("\n========= MAIN MENU =========");
            Console.WriteLine("1. Banking System");
            Console.WriteLine("2. Mathematical Utility");
            Console.WriteLine("3. Exit");
            Console.Write("Choice: ");

            int mainChoice = Convert.ToInt32(Console.ReadLine());

            switch (mainChoice)
            {
                case 1:
                    RunBankingSystem();
                    break;

                case 2:
                    MathematicalUtility.RunMathUtility();
                    break;

                case 3:
                    return;

                default:
                    Console.WriteLine("Invalid Choice");
                    break;
            }
        }
    }

    static void RunBankingSystem()
    {
        Console.Write("Enter Branch Name: ");
        string bname = Console.ReadLine();

        Console.Write("Enter Bank Capacity: ");
        int cap = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter Minimum Balance: ");
        Bank.minBalance = Convert.ToInt32(Console.ReadLine());

        Bank bank = new Bank(bname, cap);
        bank.ShowBranchDetails();

        Console.Write("Enter Manager Name: ");
        string mname = Console.ReadLine();

        Console.Write("Set Manager Password: ");
        int mpass = Convert.ToInt32(Console.ReadLine());

        Manager manager = new Manager(mname, mpass, bank);

        while (true)
        {
            Console.WriteLine("\nChoose Role");
            Console.WriteLine("1. Manager");
            Console.WriteLine("2. User");
            Console.WriteLine("3. Back");
            Console.Write("Choice: ");

            int role = Convert.ToInt32(Console.ReadLine());

            switch (role)
            {
                case 1:
                    RunManagerMenu(manager);
                    break;

                case 2:
                    RunUserMenu(manager);
                    break;

                case 3:
                    return;

                default:
                    Console.WriteLine("Invalid Choice");
                    break;
            }
        }
    }

    static void RunManagerMenu(Manager manager)
    {
        int tries = 3;
        bool isLoggedIn = false;

        while (tries-- > 0)
        {
            Console.Write("Enter Manager Password: ");
            int pass = Convert.ToInt32(Console.ReadLine());

            if (manager.Login(pass))
            {
                isLoggedIn = true;
                break;
            }
            Console.WriteLine("Wrong password. Remaining: " + tries);
        }

        while (isLoggedIn)
        {
            Console.WriteLine("\n1. Create Account");
            Console.WriteLine("2. Deposit");
            Console.WriteLine("3. Withdraw");
            Console.WriteLine("4. View Account");
            Console.WriteLine("5. Logout");
            Console.Write("Choice: ");

            int c = Convert.ToInt32(Console.ReadLine());

            switch (c)
            {
                case 1:
                    manager.CreateNewAccount();
                    break;

                case 2:
                    Console.Write("Enter Account ID: ");
                    string d = Console.ReadLine();
                    Console.Write("Enter Amount: ");
                    manager.DepositMoney(d, Convert.ToInt32(Console.ReadLine()));
                    break;

                case 3:
                    Console.Write("Enter Account ID: ");
                    string w = Console.ReadLine();
                    Console.Write("Enter Amount: ");
                    manager.WithdrawMoney(w, Convert.ToInt32(Console.ReadLine()));
                    break;

                case 4:
                    Console.Write("Enter Account ID: ");
                    manager.ViewAccount(Console.ReadLine());
                    break;

                case 5:
                    Console.WriteLine("Manager Logged Out");
                    isLoggedIn = false;
                    break;

                default:
                    Console.WriteLine("Invalid Choice");
                    break;
            }
        }
    }


    static void RunUserMenu(Manager manager)
    {
        Console.Write("Enter Account ID: ");
        string id = Console.ReadLine();

        User user = manager.FindAccount(id);
        if (user == null) return;

        bool isLoggedIn = false;

        for (int t = 3; t > 0; t--)
        {
            Console.Write("Enter PIN: ");
            if (user.Login(Convert.ToInt32(Console.ReadLine())))
            {
                isLoggedIn = true;
                break;
            }
            Console.WriteLine("Wrong PIN. Remaining: " + (t - 1));
        }

        while (isLoggedIn)
        {
            Console.WriteLine("\n1. View Account");
            Console.WriteLine("2. Deposit");
            Console.WriteLine("3. Withdraw");
            Console.WriteLine("4. Logout");
            Console.Write("Choice: ");

            int c = Convert.ToInt32(Console.ReadLine());

            switch (c)
            {
                case 1:
                    user.ViewAccount();
                    break;

                case 2:
                    Console.Write("Enter Amount: ");
                    user.DepositMoney(Convert.ToInt32(Console.ReadLine()));
                    break;

                case 3:
                    Console.Write("Enter Amount: ");
                    user.WithdrawMoney(Convert.ToInt32(Console.ReadLine()));
                    break;

                case 4:
                    Console.WriteLine("User Logged Out");
                    isLoggedIn = false;
                    break;

                default:
                    Console.WriteLine("Invalid Choice");
                    break;
            }
        }
    }

}
