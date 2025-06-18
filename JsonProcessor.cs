using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicShop
{
    public class JsonProcessor : IDataProcessor<ModernArtifact>
    {
        public List<ModernArtifact> LoadData(string filePath)
        {
            string jsonFromFile = File.ReadAllText(filePath);
            var modernArtifacts = JsonConvert.DeserializeObject<List<ModernArtifact>>(jsonFromFile);
            return modernArtifacts;
        }
        public void SaveData(List<ModernArtifact> data, string filePath)
        {
            var settings = new JsonSerializerSettings
            {
                Formatting = Formatting.Indented
            };
            string json = JsonConvert.SerializeObject(data, settings);
            File.WriteAllText(filePath, json);
        }
    }
}
