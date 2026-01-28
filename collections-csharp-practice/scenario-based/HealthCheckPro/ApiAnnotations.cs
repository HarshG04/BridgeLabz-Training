using System;

namespace HealthCheckPro
{
    [AttributeUsage(AttributeTargets.Method)]
    public class PublicAPIAttribute : Attribute
    {
        public string Description { get; set; }

        public PublicAPIAttribute(string description)
        {
            Description = description;
        }
    }

    [AttributeUsage(AttributeTargets.Method)]
    public class RequiresAuthAttribute : Attribute
    {
        public string Role { get; set; }

        public RequiresAuthAttribute(string role)
        {
            Role = role;
        }
    }
}
