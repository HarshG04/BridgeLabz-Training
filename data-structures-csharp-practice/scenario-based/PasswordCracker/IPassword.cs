namespace PasswordCracker
{
    interface IPassword
    {
        void SetPassword();
        void DecodePassword();

        void GenerateStrings();
    }
}