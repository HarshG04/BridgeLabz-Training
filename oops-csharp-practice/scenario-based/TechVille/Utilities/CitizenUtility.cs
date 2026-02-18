using System;

namespace TechVille
{
    public static class CitizenUtility
    {
        // Method To Format Input Name
        public static string FormatName(string name)
        {
            name = name.Trim().ToLower();
            return char.ToUpper(name[0]) + name.Substring(1);
        }
    }
}