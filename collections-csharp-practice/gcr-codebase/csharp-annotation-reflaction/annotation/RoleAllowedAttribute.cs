using System;
using System.Reflection;

[AttributeUsage(AttributeTargets.Method)]
class RoleAllowedAttribute : Attribute
{
    public string Role;

    public RoleAllowedAttribute(string role)
    {
        Role = role;
    }
}

class AdminPanel
{
    [RoleAllowed("ADMIN")]
    public void DeleteUser()
    {
        Console.WriteLine("User Deleted!");
    }

    [RoleAllowed("USER")]
    public void ViewProfile()
    {
        Console.WriteLine("Profile Viewed!");
    }
}

class CurrentUser
{
    public static string Role = "USER";
}


class AccessController
{
    public static void Execute(object obj, string methodName)
    {
        MethodInfo method = obj.GetType().GetMethod(methodName);

        var attr = method.GetCustomAttribute<RoleAllowedAttribute>();

        if (attr != null)
        {
            if (CurrentUser.Role == attr.Role)
            {
                method.Invoke(obj, null);
            }
            else
            {
                Console.WriteLine("Access Denied!");
            }
        }
        else
        {
            method.Invoke(obj, null);
        }
    }
}

class Program
{
    static void Main()
    {
        AdminPanel panel = new AdminPanel();

        AccessController.Execute(panel, "DeleteUser");
        AccessController.Execute(panel, "ViewProfile");

        CurrentUser.Role = "ADMIN";
        AccessController.Execute(panel, "DeleteUser");
    }
}
