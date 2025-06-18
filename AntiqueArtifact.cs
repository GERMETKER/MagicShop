using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MagicShop
{
    public class AntiqueArtifact : Artifact
    {
        public int Age { get; set; }
        public string OriginRealm { get; set; }

        public override void Serialize()
        {
           /* var antiqueArtifact = new AntiqueArtifact { Name = "Light Ring", Id = 1, PowerLewel = 15, Age = 200, OriginRealm = "Brawlstarsia", SRarity = Rarity.Rare}; */ 
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(AntiqueArtifact));
            using (var writer = new StreamWriter("AntiqueArtifact.xml"))
            {
                xmlSerializer.Serialize(writer, this);
            }

            /*List<AntiqueArtifact> antiqueArtifacts = new List<AntiqueArtifact>();
            using (var reader = new StreamReader("AntiqueArtifact.xml"))
            {
                AntiqueArtifact antiqueArtifact1 = (AntiqueArtifact)xmlSerializer.Deserialize(reader);
                antiqueArtifacts.Add(antiqueArtifact1);
            }*/


        }
    }
}
