using System.Text;

namespace PasswordCracker
{
    class PasswordUtilityImpl : IPassword
    {
        private Vault vault;
        private int n;

        public PasswordUtilityImpl()
        {
            vault = new Vault();
        }

        public void SetPassword()
        {
            Console.Write("Enter Password: ");
            string password = Console.ReadLine();

            vault.Password = password;
            n = password.Length;

            Console.WriteLine($"Password Set Successfully");
        }


        public void GenerateStrings()
        {
            Console.Write("Enter The Length Of String: ");
            int len = Convert.ToInt32(Console.ReadLine());
            GenerateStrings(new StringBuilder(),len);
        }

        private void GenerateStrings(StringBuilder sb,int len)
        {
            if(sb.Length == len)
            {
                string str = sb.ToString();
                Console.WriteLine(str);
                return;
            }

            for(int i = 0; i < 26; i++)
            {
                char ch = (char)(i+97);

                sb.Append(ch);
                GenerateStrings(sb,len);
                sb.Remove(sb.Length-1,1);
            }

        }

        public void DecodePassword()
        {
            if(vault.Password == null)
            {
                Console.WriteLine("Set Password First");
                return;
            }
            Console.WriteLine("Decoding Password...");
            DecodingPassword(new StringBuilder());

        }

        private bool DecodingPassword(StringBuilder sb)
        {
            if(sb.Length == n)
            {
                string str = sb.ToString();
                Console.Write("\rTrying: " + str);

                if (str.Equals(vault.Password))
                {
                    Console.Clear();
                    Console.WriteLine($"\nPassWord Cracked: {str}");
                    return true;
                }
                return false;
            }

            for(int i = 0; i < 26; i++)
            {
                char ch = (char)(i+97);

                sb.Append(ch);
                bool isCracked = DecodingPassword(sb);
                if(isCracked) return isCracked;
                sb.Remove(sb.Length-1,1);
            }

            return false;
        }


    }
}