class InvoiceGenerator
{
    private string[,] invoice;

    public void InvoiceMenu()
    {
        while (true)
        {
            Console.WriteLine("\n\n------------------------------------");
            Console.WriteLine("-------Invoice Menu----------");
            Console.WriteLine("1. Enter New Invoice");
            Console.WriteLine("2. Get Total Amount");
            Console.WriteLine("3. Print Invoice");
            Console.WriteLine("other: Exit Invoice Generator");
            int option = Convert.ToInt32(Console.ReadLine());
            switch (option)
            {
                case 1 : TakeInput();
                    break;
                case 2 : GetTotalAmount();
                    break;
                case 3 : PrintInvoice();
                    break;
                default : return;
            }
        }
    }

    void TakeInput()
    {
        Console.WriteLine("Enter Your Invoice String");
        string s = Console.ReadLine();
        ParseInvoice(s);
    }
    void ParseInvoice(string s)
    {
        string[] tasks = s.Split(",");
        invoice = new string[tasks.Length,2];
        

        for(int i = 0; i < tasks.Length; i++)
        {   int idx = 0;
            if(i>0) idx++;
            int j = tasks[i].IndexOf("-");
            int k = tasks[i].IndexOf("INR");
            invoice[i,0] = tasks[i].Substring(idx,j-idx-1);
            invoice[i,1] = tasks[i].Substring(j+2,(k-j-2)).ToString();

        }
    }

    void GetTotalAmount()
    {
        if(invoice==null)
        {
            Console.WriteLine("-----No Active Invoice Found-----");
            return;
        }
        int total = 0;
        for(int i = 0; i < invoice.GetLength(0); i++)
        {
            total += Convert.ToInt32(invoice[i,1]);
        }
        Console.WriteLine($"Total Amount : {total}");
    }

    void PrintInvoice()
    {
        if(invoice==null)
        {
            Console.WriteLine("-----No Active Invoice Found-----");
            return;
        }
        Console.WriteLine("------Your Invoice---------------");
        for(int i = 0; i < invoice.GetLength(0); i++)
        {
            Console.WriteLine($"{i+1}. {invoice[i,0]}: {invoice[i,1]}");
        }
        Console.WriteLine("------Your Invoice---------------");
    }
}


class Program
{
    static void Main()
    {
        InvoiceGenerator ig = new InvoiceGenerator();
        ig.InvoiceMenu();
    }
}