using System;
using System.Collections.Generic;
using System.Xml;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace JsonHandsOn_NoSchema
{
    class Student
    {
        public string Name { get; set; } = "";
        public int Age { get; set; }
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
            Console.WriteLine("=== JSON HANDS-ON PRACTICE (NO JSchema) ===\n");

            ReadJsonAndPrintKeys();
            ConvertListToJsonArray();
            FilterUsersAbove25();
            ValidateEmailSimple();
            MergeTwoJsonObjects();
            ConvertJsonToXml();
            ConvertCsvToJson();
            GenerateJsonReportFromDatabase();

            Console.WriteLine("\n=== END ===");
            Console.ReadLine();
        }

        // 1️⃣ Read JSON and print keys & values
        static void ReadJsonAndPrintKeys()
        {
            Console.WriteLine("\n1. Read JSON and Print Keys");

            string jsonText = "{ 'name': 'Amit', 'age': 28, 'email': 'amit@gmail.com' }";
            JObject jsonObject = JObject.Parse(jsonText);

            foreach (JProperty prop in jsonObject.Properties())
            {
                Console.WriteLine(prop.Name + " : " + prop.Value);
            }
        }

        // 2️⃣ Convert List to JSON Array
        static void ConvertListToJsonArray()
        {
            Console.WriteLine("\n2. Convert List to JSON Array");

            List<Student> students = new List<Student>();
            students.Add(new Student { Name = "Amit", Age = 24 });
            students.Add(new Student { Name = "Ravi", Age = 28 });

            string json = JsonConvert.SerializeObject(
                students,
                Newtonsoft.Json.Formatting.Indented
            );

            Console.WriteLine(json);
        }

        // 3️⃣ Filter users age > 25
        static void FilterUsersAbove25()
        {
            Console.WriteLine("\n3. Filter Users Age > 25");

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

        // 4️⃣ Simple Email Validation (NO Schema)
        static void ValidateEmailSimple()
        {
            Console.WriteLine("\n4. Validate Email (Simple)");

            string email = "test@gmail.com";

            bool isValid = email.Contains("@") && email.Contains(".");

            Console.WriteLine(isValid ? "Valid Email" : "Invalid Email");
        }

        // 5️⃣ Merge two JSON objects
        static void MergeTwoJsonObjects()
        {
            Console.WriteLine("\n5. Merge JSON Objects");

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
            XmlDocument xml = JsonConvert.DeserializeXmlNode(json, "Root");

            if (xml != null)
            {
                Console.WriteLine(xml.OuterXml);
            }
        }

        // 7️⃣ Convert CSV to JSON
        static void ConvertCsvToJson()
        {
            Console.WriteLine("\n7. Convert CSV to JSON");

            string[] csv =
            {
                "Name,Age",
                "Amit,25",
                "Ravi,30"
            };

            JArray array = new JArray();

            for (int i = 1; i < csv.Length; i++)
            {
                string[] values = csv[i].Split(',');

                JObject obj = new JObject();
                obj["Name"] = values[0];
                obj["Age"] = values[1];

                array.Add(obj);
            }

            Console.WriteLine(array.ToString());
        }

        // 8️⃣ Generate JSON report from DB (simulated)
        static void GenerateJsonReportFromDatabase()
        {
            Console.WriteLine("\n8. Generate JSON Report");

            List<Employee> employees = new List<Employee>();
            employees.Add(new Employee { Id = 1, Name = "Amit", Salary = 50000 });
            employees.Add(new Employee { Id = 2, Name = "Ravi", Salary = 60000 });

            string json = JsonConvert.SerializeObject(
                employees,
                Newtonsoft.Json.Formatting.Indented
            );

            Console.WriteLine(json);
        }
    }
}
