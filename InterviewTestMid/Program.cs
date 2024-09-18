using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using static InterviewTestMid.JSONClass;

namespace InterviewTestMid
{
    // The Program class performs various tasks related to JSON processing and logging.
    public class Program
    {
        // A logger interface used for logging messages during the execution of the program.
        private readonly LoggerInterface _logger;

        // Constructor initializes the logger and starts the work by calling DoWork().
        public Program(LoggerInterface logger)
        {
            _logger = logger;
            DoWork();
        }

        // Main logic of the program. Performs JSON deserialization, data processing, and serialization.
        private void DoWork()
        {
            _logger.WriteLogMessage("Starting JSON tasks...");

            // Load the JSON file from the specified path and deserialize it into a list of Part objects.
            string jsonData = File.ReadAllText("Data/SampleData.json");
            List<Part> parts = JsonSerializer.Deserialize<List<Part>>(jsonData);
            _logger.WriteLogMessage("Finished loading JSON data.");

            // LINQ query to get the material descriptions for all "FOIL" parts.
            var foilMaterials = parts
                .Where(p => p.PartDesc == "FOIL")
                .SelectMany(p => p.Materials)
                .Select(m => m.Material.LookDesc)
                .ToList();

            // Log each material description for the FOIL part.
            _logger.WriteLogMessage("Materials for FOIL part:");
            foreach (var material in foilMaterials)
            {
                _logger.WriteLogMessage(material);
            }

            // Find the first "FOIL" part and update its PartWeight.
            var foilPart = parts.FirstOrDefault(p => p.PartDesc == "FOIL");
            if (foilPart != null)
            {
                _logger.WriteLogMessage($"Original PartWeight: {foilPart.PartWeight.Value}");
                foilPart.PartWeight.Value = 1.5; // Update the part weight to 1.5
                _logger.WriteLogMessage($"Updated PartWeight: {foilPart.PartWeight.Value}");
            }

            // Serialize the updated list of parts back to a new JSON file with indentation for readability.
            string updatedJsonData = JsonSerializer.Serialize(parts, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText("C:\\Users\\90cal\\Source\\Repos\\pablocaldasG\\InterviewTestMSCaldasPablo\\InterviewTestMid\\Data\\UpdatedSampleData.json", updatedJsonData);

            _logger.WriteLogMessage("Serialized the updated object to a new JSON file.");
        }

        // Entry point of the program. Creates an instance of Logger and runs the Program.
        static void Main(string[] args)
        {
            LoggerInterface logger = new Logger(); // Instantiate the logger.
            Program program = new Program(logger); // Start the program.
        }
    }
}
