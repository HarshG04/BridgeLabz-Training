using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace IPLAndCensorshipAnalyzer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== IPL AND CENSORSHIP ANALYZER ===\n");

            string jsonInput = "ipl_input.json";
            string jsonOutput = "ipl_censored.json";
            string csvInput = "ipl_input.csv";
            string csvOutput = "ipl_censored.csv";

            ProcessJson(jsonInput, jsonOutput);
            ProcessCsv(csvInput, csvOutput);

            Console.WriteLine("\nCensorship completed successfully.");
            Console.ReadLine();
        }

        // ✅ CORRECT TEAM NAME MASKING LOGIC
        // Rule: Keep first word, replace rest with ***
        static string MaskTeamName(string teamName)
        {
            if (string.IsNullOrEmpty(teamName))
            {
                return teamName;
            }

            string[] parts = teamName.Split(' ');

            if (parts.Length == 1)
            {
                return parts[0] + " ***";
            }

            return parts[0] + " ***";
        }

        // ---------- JSON PROCESSING ----------
        static void ProcessJson(string inputFile, string outputFile)
        {
            Console.WriteLine("Processing JSON file...");

            string jsonText = File.ReadAllText(inputFile);
            JArray matches = JArray.Parse(jsonText);

            foreach (JObject match in matches)
            {
                string team1 = match["team1"] != null ? match["team1"].ToString() : "";
                string team2 = match["team2"] != null ? match["team2"].ToString() : "";
                string winner = match["winner"] != null ? match["winner"].ToString() : "";

                string maskedTeam1 = MaskTeamName(team1);
                string maskedTeam2 = MaskTeamName(team2);
                string maskedWinner = MaskTeamName(winner);

                match["team1"] = maskedTeam1;
                match["team2"] = maskedTeam2;
                match["winner"] = maskedWinner;
                match["player_of_match"] = "REDACTED";

                // Fix score object keys
                JObject oldScore = (JObject)match["score"];
                JObject newScore = new JObject();

                foreach (JProperty prop in oldScore.Properties())
                {
                    string maskedKey = MaskTeamName(prop.Name);
                    newScore[maskedKey] = prop.Value;
                }

                match["score"] = newScore;
            }

            File.WriteAllText(
                outputFile,
                matches.ToString(Newtonsoft.Json.Formatting.Indented)
            );

            Console.WriteLine("JSON censorship done.");
        }

        // ---------- CSV PROCESSING ----------
        static void ProcessCsv(string inputFile, string outputFile)
        {
            Console.WriteLine("Processing CSV file...");

            string[] lines = File.ReadAllLines(inputFile);
            List<string> outputLines = new List<string>();

            // Header
            outputLines.Add(lines[0]);

            for (int i = 1; i < lines.Length; i++)
            {
                string[] cols = lines[i].Split(',');

                string team1 = MaskTeamName(cols[1]);
                string team2 = MaskTeamName(cols[2]);
                string winner = MaskTeamName(cols[5]);

                string censoredLine =
                    cols[0] + "," +
                    team1 + "," +
                    team2 + "," +
                    cols[3] + "," +
                    cols[4] + "," +
                    winner + "," +
                    "REDACTED";

                outputLines.Add(censoredLine);
            }

            File.WriteAllLines(outputFile, outputLines);

            Console.WriteLine("CSV censorship done.");
        }
    }
}
