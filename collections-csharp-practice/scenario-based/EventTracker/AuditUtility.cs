using System;
using System.Reflection;
using System.Text;

namespace EventTracker
{
    public class AuditUtility : IAuditScanner
    {
        public void ScanAndGenerateLogs(Type classType)
        {
            MethodInfo[] methods = classType.GetMethods(
                BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);

            Console.WriteLine("\nAudit Logs (JSON Format):\n");

            foreach (MethodInfo method in methods)
            {
                AuditTrailAttribute auditAttr =
                    (AuditTrailAttribute)method.GetCustomAttribute(typeof(AuditTrailAttribute));

                if (auditAttr != null)
                {
                    AuditEventInfo eventInfo = new AuditEventInfo();
                    eventInfo.MethodName = method.Name;
                    eventInfo.ActionName = auditAttr.ActionName;
                    eventInfo.TimeStamp = DateTime.Now.ToString();

                    string json = ConvertToJson(eventInfo);
                    Console.WriteLine(json);
                }
            }
        }

        private string ConvertToJson(AuditEventInfo info)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("{ ");
            sb.Append("\"MethodName\": \"" + info.MethodName + "\", ");
            sb.Append("\"ActionName\": \"" + info.ActionName + "\", ");
            sb.Append("\"TimeStamp\": \"" + info.TimeStamp + "\" ");
            sb.Append("}");
            return sb.ToString();
        }
    }
}
