using System;
class SnakeNLadder
{
    static int[,] ladder = {{5,23},{9,11},{10,32},{19,37},{39,58},{44,53},{63,77},{71,90},{85,95}};
    static int[,] snake = {{12,6},{18,3},{47,13},{56,35},{67,48},{82,60},{86,65},{93,87},{97,83}};
    static Random random = new Random();
    string[] playerName;

    int[] pos;
    int n=0;

    

    static void Main()
    {
        SnakeNLadder game = new SnakeNLadder();
        game.GameMenu();
    }

    // Show menu
    void GameMenu()
    {
        while (true)
        {
            Console.WriteLine("1: Start \n2: Menu\nother : Exit Environment");
            int num = Convert.ToInt32(Console.ReadLine());
            switch (num)
            {
                case 1 : Start();
                break;
                case 2 : break;
                default : Environment.Exit(0);
                break;
            }
        }
    }

    // Start The Game

    void Start()
    {
        TakeInput();
        Console.WriteLine("Initials Positions: ");
        ShowPosition();
        while (true)
        {
            for(int i = 0; i < n; i++)
            {
                Console.Write($"\nPlayer {playerName[i]} Turn || Enter Any Key to Roll Dice ");
                Console.ReadKey();
                int dice = RollDice();
                Console.Write($"\nNo on dice : {dice}");
                MovePlayer(i,dice);
            }
            ShowPosition();
        }
    }

    // Taking no of players and assigning pos and PlayerName array

    void TakeInput()
    {
        while(true){
            Console.Write("Enter no. of Players {2,3,4}: ");
            n = Convert.ToInt32(Console.ReadLine());
            if(n<2 || n>4) Console.WriteLine("\nInvalid no of Players Enter Again");
            else break;
        }

        pos = new int[n];
        playerName = new string[n];

        Console.WriteLine("Enter Players Name : ");
        for(int i = 0; i < n; i++)
        {
            Console.Write($"Player {i+1} name : ");
            playerName[i] = Console.ReadLine();
        }
    }



    // checking for player if on ladder or snack
    void ApplySnackAndLadder(int player)
    {
        int curr = pos[player];
        // checking for ladder
        for(int i = 0; i < ladder.GetLength(0); i++)
        {
            if (ladder[i,0] == curr){
                Console.WriteLine($"\n---Player {playerName[player]} climbing Ladder from {pos[player]} to {ladder[i,1]}---");
                pos[player] = ladder[i,1];
            }
        }
        // checking for snacks
        for(int i = 0; i < snake.GetLength(0); i++)
        {
            if (snake[i,0] == curr){
                Console.WriteLine($"\n---Player {playerName[player]} Bitten by Snack from {pos[player]} to {snake[i,1]}---");
                pos[player] = snake[i,1];
            }
        }

    }

    // roll the dice and generate a random no [1,7)
    int RollDice()
    {
        return random.Next(1,7);
    }

    // move player based on player no and dice value
    void MovePlayer(int player,int dice)
    {
        int curr = pos[player];
        if(curr+dice<=100){
            pos[player] += dice;
            ApplySnackAndLadder(player);
            CheckWin(player);
        }
    }

    // check player if on winning position

    void CheckWin(int player)
    {
        if (pos[player] == 100)
        {
            Console.WriteLine("\n-----------------------------------");
            Console.WriteLine($"\nPlayer {playerName[player]} Won");
            Console.WriteLine("-----------------------------------");

            GameMenu();
        }
    }

    // show all players positions
    void ShowPosition()
    {
        for(int i = 0; i < pos.Length; i++)
        {
            Console.WriteLine($"\nPlayer : {playerName[i]}  Position : {pos[i]}");
        }

        Console.WriteLine("------------------------------------------");
    }

}