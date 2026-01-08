using System;

class FriendNode
{
    public int friendId;
    public FriendNode next;

    public FriendNode(int id)
    {
        friendId = id;
        next = null;
    }
}

class UserNode
{
    public int userId;
    public string name;
    public int age;

    public FriendNode friends;   // head of friend list
    public UserNode next;        // next user

    public UserNode(int id, string name, int age)
    {
        this.userId = id;
        this.name = name;
        this.age = age;
        this.friends = null;
        this.next = null;
    }
}

class SocialNetwork
{
    private UserNode head = null;

    //--------------- Add User ----------------
    public void AddUser()
    {
        Console.Write("Enter User ID: ");
        int id = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter Name: ");
        string name = Console.ReadLine();

        Console.Write("Enter Age: ");
        int age = Convert.ToInt32(Console.ReadLine());

        UserNode newUser = new UserNode(id, name, age);

        if (head == null)
        {
            head = newUser;
            Console.WriteLine("User added.");
            return;
        }

        UserNode temp = head;
        while (temp.next != null)
            temp = temp.next;

        temp.next = newUser;

        Console.WriteLine("User added.");
    }

    //---------------- Find User ----------------
    private UserNode GetUser(int id)
    {
        UserNode temp = head;
        while (temp != null)
        {
            if (temp.userId == id)
                return temp;
            temp = temp.next;
        }
        return null;
    }

    //---------------- Add Friend ----------------
    public void AddFriend()
    {
        Console.Write("Enter User ID: ");
        int u1 = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter Friend User ID: ");
        int u2 = Convert.ToInt32(Console.ReadLine());

        UserNode user1 = GetUser(u1);
        UserNode user2 = GetUser(u2);

        if (user1 == null || user2 == null)
        {
            Console.WriteLine("User not found.");
            return;
        }

        AddFriendLink(user1, u2);
        AddFriendLink(user2, u1);

        Console.WriteLine("Friend connection added.");
    }

    private void AddFriendLink(UserNode user, int fid)
    {
        FriendNode fn = new FriendNode(fid);

        if (user.friends == null)
        {
            user.friends = fn;
            return;
        }

        FriendNode temp = user.friends;
        while (temp.next != null)
            temp = temp.next;

        temp.next = fn;
    }

    //---------------- Remove Friend ----------------
    public void RemoveFriend()
    {
        Console.Write("Enter User ID: ");
        int u1 = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter Friend User ID to Remove: ");
        int u2 = Convert.ToInt32(Console.ReadLine());

        UserNode user1 = GetUser(u1);
        UserNode user2 = GetUser(u2);

        if (user1 == null || user2 == null)
        {
            Console.WriteLine("User not found.");
            return;
        }

        RemoveFriendLink(user1, u2);
        RemoveFriendLink(user2, u1);

        Console.WriteLine("Friend removed.");
    }

    private void RemoveFriendLink(UserNode user, int fid)
    {
        if (user.friends == null) return;

        if (user.friends.friendId == fid)
        {
            user.friends = user.friends.next;
            return;
        }

        FriendNode temp = user.friends;

        while (temp.next != null && temp.next.friendId != fid)
            temp = temp.next;

        if (temp.next != null)
            temp.next = temp.next.next;
    }

    //---------------- Display All Friends ----------------
    public void ShowFriends()
    {
        Console.Write("Enter User ID: ");
        int id = Convert.ToInt32(Console.ReadLine());

        UserNode user = GetUser(id);

        if (user == null)
        {
            Console.WriteLine("User not found.");
            return;
        }

        Console.WriteLine($"\nFriends of {user.name}:");

        FriendNode temp = user.friends;

        if (temp == null)
        {
            Console.WriteLine("No friends.");
            return;
        }

        while (temp != null)
        {
            Console.WriteLine($"Friend ID: {temp.friendId}");
            temp = temp.next;
        }
    }

    //---------------- Mutual Friends ----------------
    public void ShowMutualFriends()
    {
        Console.Write("Enter First User ID: ");
        int u1 = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter Second User ID: ");
        int u2 = Convert.ToInt32(Console.ReadLine());

        UserNode user1 = GetUser(u1);
        UserNode user2 = GetUser(u2);

        if (user1 == null || user2 == null)
        {
            Console.WriteLine("User not found.");
            return;
        }

        Console.WriteLine("\nMutual Friends:");

        FriendNode f1 = user1.friends;

        while (f1 != null)
        {
            FriendNode f2 = user2.friends;

            while (f2 != null)
            {
                if (f1.friendId == f2.friendId)
                    Console.WriteLine($"User ID: {f1.friendId}");

                f2 = f2.next;
            }

            f1 = f1.next;
        }
    }

    //---------------- Search User ----------------
    public void SearchUser()
    {
        Console.Write("Enter User ID or Name: ");
        string input = Console.ReadLine();

        UserNode temp = head;
        while (temp != null)
        {
            if (temp.userId.ToString() == input || temp.name.Equals(input, StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine($"Found → ID:{temp.userId}, Name:{temp.name}, Age:{temp.age}");
                return;
            }

            temp = temp.next;
        }

        Console.WriteLine("User not found.");
    }

    //---------------- Count Friends ----------------
    public void CountFriends()
    {
        Console.Write("Enter User ID: ");
        int id = Convert.ToInt32(Console.ReadLine());

        UserNode user = GetUser(id);

        if (user == null)
        {
            Console.WriteLine("User not found.");
            return;
        }

        int count = 0;
        FriendNode temp = user.friends;

        while (temp != null)
        {
            count++;
            temp = temp.next;
        }

        Console.WriteLine($"{user.name} has {count} friends.");
    }
}

class Program
{
    static void Main()
    {
        SocialNetwork sn = new SocialNetwork();

        while (true)
        {
            Console.WriteLine("\n===== Social Network Menu =====");
            Console.WriteLine("1. Add User");
            Console.WriteLine("2. Add Friend Connection");
            Console.WriteLine("3. Remove Friend Connection");
            Console.WriteLine("4. Show Friends of User");
            Console.WriteLine("5. Show Mutual Friends");
            Console.WriteLine("6. Search User");
            Console.WriteLine("7. Count Friends");
            Console.WriteLine("8. Exit");
            Console.Write("Enter choice: ");

            int ch = Convert.ToInt32(Console.ReadLine());
            if (ch == 8) break;

            switch (ch)
            {
                case 1: sn.AddUser(); break;
                case 2: sn.AddFriend(); break;
                case 3: sn.RemoveFriend(); break;
                case 4: sn.ShowFriends(); break;
                case 5: sn.ShowMutualFriends(); break;
                case 6: sn.SearchUser(); break;
                case 7: sn.CountFriends(); break;
                default: Console.WriteLine("Invalid choice."); break;
            }
        }
    }
}
