using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace JsonHandsOnPractice
{
    class User
    {
        public string Name { get; set; } = "";
        public int Age { get; set; }
        public string Email { get; set; } = "";
    }

    class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public int Salary { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== JSON HANDS-ON PRACTICE ===\n");

            ReadJsonAndPrintKeys();
            ConvertListToJsonArray();
            FilterUsersOlderThan25();
            MergeTwoJsonFiles();
            ConvertJsonToXml();
            ConvertCsvToJson();
            GenerateJsonReportFromDatabase();

            Console.WriteLine("\n=== END ===");
            Console.ReadLine();
        }

        // 1️⃣ Read a JSON file and print all keys and values
        static void ReadJsonAndPrintKeys()
        {
            Console.WriteLine("\n1. Read JSON and Print Keys & Values");

            string jsonText = "{ 'name': 'Amit', 'age': 28, 'email': 'amit@gmail.com' }";
            JObject jsonObject = JObject.Parse(jsonText);

            foreach (JProperty prop in jsonObject.Properties())
            {
                Console.WriteLine(prop.Name + " : " + prop.Value);
            }
        }

        // 2️⃣ Convert a list of C# objects into a JSON array
        static void ConvertListToJsonArray()
        {
            Console.WriteLine("\n2. Convert List to JSON Array");

            List<User> users = new List<User>();
            users.Add(new User { Name = "Amit", Age = 24, Email = "amit@gmail.com" });
            users.Add(new User { Name = "Ravi", Age = 28, Email = "ravi@gmail.com" });

            string jsonArray = JsonConvert.SerializeObject(
                users,
                Newtonsoft.Json.Formatting.Indented
            );

            Console.WriteLine(jsonArray);
        }

        // 3️⃣ Filter JSON data: users older than 25
        static void FilterUsersOlderThan25()
        {
            Console.WriteLine("\n3. Filter Users Older Than 25");

            string jsonData = @"[
              { 'name': 'Amit', 'age': 24 },
              { 'name': 'Ravi', 'age': 28 },
              { 'name': 'Neha', 'age': 30 }
            ]";

            JArray array = JArray.Parse(jsonData);

            foreach (JToken token in array)
            {
                int age = token["age"] != null ? (int)token["age"] : 0;

                if (age > 25)
                {
                    Console.WriteLine(token.ToString());
                }
            }
        }

        // 4️⃣ Validate email (simple – schema explained below)
        static void ValidateEmailSimple()
        {
            Console.WriteLine("\n4. Validate Email (Simple)");

            string email = "test@gmail.com";
            bool isValid = email.Contains("@") && email.Contains(".");

            Console.WriteLine(isValid ? "Valid Email" : "Invalid Email");
        }

        // 5️⃣ Merge two JSON files into one JSON object
        static void MergeTwoJsonFiles()
        {
            Console.WriteLine("\n5. Merge Two JSON Objects");

            JObject json1 = JObject.Parse("{ 'name': 'Amit' }");
            JObject json2 = JObject.Parse("{ 'email': 'amit@gmail.com' }");

            json1.Merge(json2);
            Console.WriteLine(json1.ToString());
        }

        // 6️⃣ Convert JSON to XML
        static void ConvertJsonToXml()
        {
            Console.WriteLine("\n6. Convert JSON to XML");

            string json = "{ 'name': 'Amit', 'age': 28 }";
            XmlDocument xmlDoc = JsonConvert.DeserializeXmlNode(json, "Root");

            if (xmlDoc != null)
            {
                Console.WriteLine(xmlDoc.OuterXml);
            }
        }

        // 7️⃣ Convert CSV data into JSON
        static void ConvertCsvToJson()
        {
            Console.WriteLine("\n7. Convert CSV to JSON");

            string[] csvLines =
            {
                "Name,Age",
                "Amit,25",
                "Ravi,30"
            };

            JArray jsonArray = new JArray();

            for (int i = 1; i < csvLines.Length; i++)
            {
                string[] values = csvLines[i].Split(',');

                JObject obj = new JObject();
                obj["Name"] = values[0];
                obj["Age"] = values[1];

                jsonArray.Add(obj);
            }

            Console.WriteLine(jsonArray.ToString());
        }

        // 8️⃣ Generate JSON report from database records (simulated)
        static void GenerateJsonReportFromDatabase()
        {
            Console.WriteLine("\n8. Generate JSON Report from Database");

            List<Employee> employees = new List<Employee>();
            employees.Add(new Employee { Id = 1, Name = "Amit", Salary = 50000 });
            employees.Add(new Employee { Id = 2, Name = "Ravi", Salary = 60000 });

            string jsonReport = JsonConvert.SerializeObject(
                employees,
                Newtonsoft.Json.Formatting.Indented
            );

            Console.WriteLine(jsonReport);
        }
    }
}
