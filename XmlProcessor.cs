using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MagicShop
{
    public class XmlProcessor : IDataProcessor<AntiqueArtifact>
    {
        public List<AntiqueArtifact> LoadData(string filePath)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(AntiqueArtifact));
            List<AntiqueArtifact> antiqueArtifacts = new List<AntiqueArtifact>();
            using (var reader = new StreamReader("AntiqueArtifact.xml"))
            {
                AntiqueArtifact antiqueArtifact1 = (AntiqueArtifact)xmlSerializer.Deserialize(reader);
                antiqueArtifacts.Add(antiqueArtifact1);
            }

            return antiqueArtifacts;
        }
        public void SaveData(List<AntiqueArtifact> data, string filePath)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<AntiqueArtifact>));
            using (var writer = new StreamWriter(filePath))
            {
                xmlSerializer.Serialize(writer, data);
            }
        }
    }
}
