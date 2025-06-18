using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicShop
{
    public class ModernArtifact : Artifact
    {
        public double TechLevel { get; set; }
        public string Manufacturer { get; set; }

        public override void Serialize()
        {
            /*ModernArtifact modernArtifact = new ModernArtifact { Id = 1, Name = "Gorget of Life", PowerLewel = 53, TechLevel = 95, Manufacturer = "Elf king", SRarity = Rarity.Epic};*/

            var settings = new JsonSerializerSettings
            {
                Formatting = Formatting.Indented
            };
            string json = JsonConvert.SerializeObject(this, settings);
            File.WriteAllText("ModernArtifact.json", json);
        }
    }
}
