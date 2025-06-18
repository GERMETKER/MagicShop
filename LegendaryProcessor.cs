using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MagicShop.Artifact;
using System.Xml.Linq;

namespace MagicShop
{
    public class LegendaryProcessor
    {
        public List<LegendaryArtifact> LoadData(string filePath)
        {
            List<LegendaryArtifact> legendaryArtifacts = new List<LegendaryArtifact>();
            using (StreamReader reader = new StreamReader(filePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] elements = line.Split('|');
                    LegendaryArtifact temp_legendaryArtifact = new LegendaryArtifact();
                    if (elements[3] == "Common")
                    {
                        temp_legendaryArtifact.SRarity = Rarity.Common;
                    }
                    else if(elements[3] == "Rare")
                    {
                        temp_legendaryArtifact.SRarity = Rarity.Rare;
                    }
                    else if(elements[3] == "Epic")
                    {
                        temp_legendaryArtifact.SRarity = Rarity.Epic;
                    }
                    else if (elements[3] == "Legendary")
                    {
                        temp_legendaryArtifact.SRarity = Rarity.Legendary;
                    }
                    legendaryArtifacts.Add(new LegendaryArtifact
                    {
                        Id = Convert.ToInt32(elements[0]),
                        Name = elements[1],
                        PowerLewel = Convert.ToInt32(elements[2]),
                        SRarity = temp_legendaryArtifact.SRarity,
                        IsCursed = Convert.ToBoolean(elements[4]),
                        CurseDesruption = elements[5]
                    });
                }
                return legendaryArtifacts;
            }
        }
        public void SaveData(List<LegendaryArtifact> data, string filePath)
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                foreach (var i in data)
                {
                    writer.WriteLine($"{i.Id}|{i.Name}|{i.PowerLewel}|{i.SRarity}|{i.IsCursed}" +
                        $"|{i.CurseDesruption}");
                }
            }
        }
    }
}
