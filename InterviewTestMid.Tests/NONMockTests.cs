using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using Xunit;

namespace InterviewTestMid.Tests
{
    public class JsonTests
    {
        private class Part
        {
            public int PartId { get; set; }
            public string PartNbr { get; set; }
            public string PartDesc { get; set; }
            public Meta Meta { get; set; }
            public List<MaterialInfo> Materials { get; set; }
        }

        private class Meta
        {
            public PartClassification PartClassification { get; set; }
            public PartMasterType PartMasterType { get; set; }
            public PartColour PartColour { get; set; }
            public PartOpacity PartOpacity { get; set; }
        }

        // Meta sub-objects (simplified for brevity)
        private class PartClassification { }
        private class PartMasterType { }
        private class PartColour { }
        private class PartOpacity { }

        private class MaterialInfo
        {
            public MaterialDetails Material { get; set; }
            public double Percentage { get; set; }
        }

        private class MaterialDetails
        {
            public int LookId { get; set; }
            public string LookNbr { get; set; }
            public string LookDesc { get; set; }
        }

        [Fact]
        public void CheckNumberOfMetaObjects()
        {
            // Load your JSON data
            string jsonData = File.ReadAllText("C:\\Users\\90cal\\Source\\Repos\\pablocaldasG\\InterviewTestMSCaldasPablo\\InterviewTestMid\\Data\\SampleData.json");

            // Deserialize JSON into Part class structure
            var parts = JsonSerializer.Deserialize<List<Part>>(jsonData);

            // Ensure deserialization happened correctly
            Assert.NotNull(parts);
            Assert.True(parts.Count > 0, "No parts were deserialized.");

            // Ensure the Meta object is not null for each part
            foreach (var part in parts)
            {
                Assert.NotNull(part.Meta); // This is the line causing the current failure
            }

            // Check the number of meta objects, for example:
            int numberOfMetaObjects = parts.Count(p => p.Meta != null);
            Assert.True(numberOfMetaObjects > 0, "No Meta objects found.");
        }
    }
}
