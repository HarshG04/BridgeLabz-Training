namespace ATMDispenser
{
    class ATM
    {
        static int[] notes = [1,2,5,10,20,50,100,200,500];
        static void Main()
        {
            Console.WriteLine("Enter Quantity Of Each Note: ");
            int[] quantity = new int[9];
            for(int i = 0; i < notes.Length; i++)
            {
                Console.Write($"{notes[i]} : ");
                quantity[i] = Convert.ToInt32(Console.ReadLine());
            }
            // ScenarioA(quantity);
            // ScenarioB(quantity);
            ScenarioC(883,quantity);
        }

        static void ScenarioA(int[] quantity)
        {
            int total = 880;
            int idx = notes.Length-1;
            string s = "";
            while (total > 0 && idx>=0)
            {
                int count = 0;
                while (idx>=0 && quantity[idx]>0 && total >= notes[idx])
                {
                    total -= notes[idx];
                    quantity[idx]--;
                    count++;
                }
                if(count>0) s += $"{notes[idx]} : {count}, ";
                idx--;
            }

            Console.WriteLine(s);
        }

        static void ScenarioB(int[] quantity)
        {
            int total = 880;
            int idx = notes.Length-2;

            string s = "";
            while (total > 0 && idx>=0)
            {
                int count = 0;
                while (idx>=0 && quantity[idx]>0 && total >= notes[idx])
                {
                    total -= notes[idx];
                    quantity[idx]--;
                    count++;
                }
                if(count>0) s += $"{notes[idx]} : {count}, ";
                idx--;
            }

            Console.WriteLine(s);
        }

        static void ScenarioC(int total,int[] quantity)
        {
            int idx = notes.Length-1;
            int reqMoney = total;
            int sum = 0;

            string s = "";
            while (total > 0 && idx>=0)
            {
                int count = 0;
                while (idx>=0 && quantity[idx]>0 && total >= notes[idx])
                {
                    sum += notes[idx];
                    total -= notes[idx];
                    quantity[idx]--;
                    count++;
                }
                if(count>0) s += $"{notes[idx]} : {count}, ";
                idx--;
            }
            Console.WriteLine($"Requested Money : {reqMoney}");
            Console.WriteLine($"Dispance Amount : {sum}");
            Console.WriteLine($"Remaning Amount : {sum}");
            Console.WriteLine(s);
        }

        

    }
}