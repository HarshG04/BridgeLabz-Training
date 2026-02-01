namespace LexicalTwist;

class LexicalTwistMenu
{
    private LexicalTwistUtility utility;

    public LexicalTwistMenu()
    {
        utility = new LexicalTwistUtility();
    }

    public void Start()
    {
        while(true)
        {
            Console.WriteLine("\n============");
            Console.WriteLine("1: Start");
            Console.WriteLine("2: Exit");
            Console.Write("Enter Choice: ");
            int ch = Convert.ToInt32(Console.ReadLine());
            
            if(ch==2) return;
            else if(ch==1) utility.TakeInput();
        }
    }
}
