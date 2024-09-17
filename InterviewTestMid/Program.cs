using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using static InterviewTestMid.JSONClass;

namespace InterviewTestMid
{
    public class Program
    {
        private readonly LoggerInterface _logger;

        public Program(LoggerInterface logger)
        {
            _logger = logger;
            DoWork();
        }

        private void DoWork()
        {
            _logger.WriteLogMessage("Starting JSON tasks...");

            // Load the JSON file
            string jsonData = File.ReadAllText("Data/SampleData.json");
            List<Part> parts = JsonSerializer.Deserialize<List<Part>>(jsonData);
            _logger.WriteLogMessage("Finished loading JSON data.");

            // LINQ query to get material descriptions for the FOIL part
            var foilMaterials = parts
                .Where(p => p.PartDesc == "FOIL")
                .SelectMany(p => p.Materials)
                .Select(m => m.Material.LookDesc)
                .ToList();

            // Log the material descriptions
            _logger.WriteLogMessage("Materials for FOIL part:");
            foreach (var material in foilMaterials)
            {
                _logger.WriteLogMessage(material);
            }

            // Change the PartWeight for the FOIL part
            var foilPart = parts.FirstOrDefault(p => p.PartDesc == "FOIL");
            if (foilPart != null)
            {
                _logger.WriteLogMessage($"Original PartWeight: {foilPart.PartWeight.Value}");
                foilPart.PartWeight.Value = 1.5; 
                _logger.WriteLogMessage($"Updated PartWeight: {foilPart.PartWeight.Value}");
            }

            // Serialize the updated object back to a new JSON file
            string updatedJsonData = JsonSerializer.Serialize(parts, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText("C:\\Users\\90cal\\Source\\Repos\\pablocaldasG\\InterviewTestMSCaldasPablo\\InterviewTestMid\\Data\\UpdatedSampleData.json", updatedJsonData);

            _logger.WriteLogMessage("Serialized the updated object to a new JSON file.");
        }

        static void Main(string[] args)
        {
            LoggerInterface logger = new Logger();
            Program program = new Program(logger);
        }
    }
}
