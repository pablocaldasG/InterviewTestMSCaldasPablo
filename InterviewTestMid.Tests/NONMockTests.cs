using System.Collections.Generic;
using System.IO;
using System.Linq; // For Count() method
using System.Text.Json;
using Xunit;

namespace InterviewTestMid.Tests
{
    // Unit tests for handling JSON data related to Part objects.
    public class JsonTests
    {
        // Nested classes representing the structure of the JSON data.
        private class Part
        {
            public int PartId { get; set; }
            public string PartNbr { get; set; }
            public string PartDesc { get; set; }
            public Meta Meta { get; set; } // Meta object that contains classification and details about the part.
            public List<MaterialInfo> Materials { get; set; } // List of materials associated with the part.
        }

        private class Meta
        {
            public PartClassification PartClassification { get; set; }
            public PartMasterType PartMasterType { get; set; }
            public PartColour PartColour { get; set; }
            public PartOpacity PartOpacity { get; set; }
        }

        // Classes used to represent details about part classifications, types, colours, and opacity.
        private class PartClassification { }
        private class PartMasterType { }
        private class PartColour { }
        private class PartOpacity { }

        private class MaterialInfo
        {
            public MaterialDetails Material { get; set; } // Material details for each part.
            public double Percentage { get; set; } // Percentage of the material in the part.
        }

        private class MaterialDetails
        {
            public int LookId { get; set; }
            public string LookNbr { get; set; }
            public string LookDesc { get; set; }
        }

        // Test case: Verifies the number of Meta objects in the deserialized JSON data.
        [Fact]
        public void CheckNumberOfMetaObjects()
        {
            // Construct the relative path to the JSON file (ensuring compatibility across different platforms).
            string projectDir = Directory.GetCurrentDirectory();
            string jsonFilePath = Path.Combine(projectDir, "Data", "SampleData.json");

            // Assert that the JSON file exists at the specified location.
            Assert.True(File.Exists(jsonFilePath), $"SampleData.json not found at {jsonFilePath}");

            // Load the JSON file content into a string.
            string jsonData = File.ReadAllText(jsonFilePath);

            // Deserialize the JSON data into a list of Part objects.
            var parts = JsonSerializer.Deserialize<List<Part>>(jsonData);

            // Assert that the parts list is not null and contains elements.
            Assert.NotNull(parts);
            Assert.True(parts.Count > 0, "No parts were deserialized.");

            // Verify that each Part object contains a non-null Meta object.
            foreach (var part in parts)
            {
                Assert.NotNull(part.Meta); // Ensure the Meta property is not null for every part.
            }

            // Check the number of parts that have a non-null Meta object.
            int numberOfMetaObjects = parts.Count(p => p.Meta != null);
            Assert.True(numberOfMetaObjects > 0, "No Meta objects found."); // Assert that there is at least one Meta object.
        }
    }
}
