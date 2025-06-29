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
            /*XmlSerializer xmlSerializer = new XmlSerializer(typeof(AntiqueArtifact));
            List<AntiqueArtifact> antiqueArtifacts = new List<AntiqueArtifact>();
            using (var reader = new StreamReader(filePath))
            {
                if ((AntiqueArtifact)xmlSerializer.Deserialize(reader) != null)
                {
                    AntiqueArtifact antiqueArtifact1 = (AntiqueArtifact)xmlSerializer.Deserialize(reader);
                    antiqueArtifacts.Add(antiqueArtifact1);
                }
            }*/
            /*var antiqueArtifacts = new List<AntiqueArtifact>();
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(AntiqueArtifact));
            using (var reader = new StreamReader(filePath))
            {
                AntiqueArtifact antiqueArtifact = (AntiqueArtifact)xmlSerializer.Deserialize(reader);
                antiqueArtifacts.Add(antiqueArtifact);
            }*/

            XmlSerializer serializer = new XmlSerializer(typeof(List<AntiqueArtifact>));
            var antiqueArtifactsss = new List<AntiqueArtifact>();
            using (FileStream fileStream = new FileStream(filePath, FileMode.Open))
            {
                List<AntiqueArtifact> antiqueArtifacts = ((List<AntiqueArtifact>)serializer.Deserialize(fileStream));
                //antiqueArtifacts.Add(antiqueArtifact);
                //Console.WriteLine($"Имя: {person.Name}, Возраст: {person.Age}");
                antiqueArtifactsss = antiqueArtifacts;

            }


            return antiqueArtifactsss;
        }
        public void SaveData(List<AntiqueArtifact> data, string filePath)
        {

            /* XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<AntiqueArtifact>));
             using (var writer = new StreamWriter(filePath))
             {
                 xmlSerializer.Serialize(writer, data);
             }*/

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<AntiqueArtifact>));

            using (var i = new StreamWriter(filePath))
            {
                xmlSerializer.Serialize(i, data);
            }

        }
    }
}
