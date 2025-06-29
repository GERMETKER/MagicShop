using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MagicShop
{
    public class ShopManager
    {
        public List<Artifact> artifacts = new List<Artifact>();

        public List<Artifact> LoadAllData(string fileAntuque, string fileModrn, string filelegendary)
        {
            List<AntiqueArtifact> antiqueArtifacts = new List<AntiqueArtifact>();
            List<ModernArtifact> modernArtifacts = new List<ModernArtifact>();
            List<LegendaryArtifact> legendaryArtifacts = new List<LegendaryArtifact>();

            XmlProcessor xmlProcessor = new XmlProcessor();
            JsonProcessor jsonProcessor = new JsonProcessor();
            LegendaryProcessor legendaryProcessor = new LegendaryProcessor();

            antiqueArtifacts = xmlProcessor.LoadData(fileAntuque);
            modernArtifacts = jsonProcessor.LoadData(fileModrn);
            legendaryArtifacts = legendaryProcessor.LoadData(filelegendary);

            foreach (var art in antiqueArtifacts)
            {
                artifacts.Add( art );
            }
            foreach (var art in modernArtifacts)
            {
                artifacts.Add(art);
            }
            foreach (var art in legendaryArtifacts)
            {
                artifacts.Add(art);
            }

            return artifacts;

        }


        public void GenerateReport(string filename, List<Artifact> temp_artefacts)
        {
            var grouped = temp_artefacts.GroupBy(a => a.SRarity);

            var rarityPlusPowerlevels = new Dictionary<Artifact.Rarity, List<int>>();

            foreach (var i in grouped)
            {
                var powerlevels = new List<int>();
                foreach (var j in i)
                {
                    powerlevels.Add(j.PowerLewel);
                }
                rarityPlusPowerlevels.Add(i.Key, powerlevels);
            }

            using (StreamWriter writer = new StreamWriter(filename))
            {
                foreach (var i in rarityPlusPowerlevels)
                {
                    writer.WriteLine($"{i.Key} - {i.Value.Average()}");
                }
            }
        }
        
        public void FindCursedArtifacts(List<LegendaryArtifact> temp_legendaryartifacts)
        {
            //return temp_legendaryartifacts.Where(s => s.IsCursed = true && s.PowerLewel > 200).ToList();
            var result = temp_legendaryartifacts.Where(s => s.IsCursed = true && s.PowerLewel > 200).ToList();

            foreach (var i in result)
            {
                Console.WriteLine($"Имя: {i.Name}, Проклятие: {i.IsCursed}, Описание проклятия: {i.CurseDesruption}, Уровень Силы: {i.PowerLewel}, Редкость: {i.SRarity}");
            }
            Console.WriteLine();
        }

        public void GroupByRarity(List<Artifact> temp_artifacts)
        {
            //Dictionary<Artifact.Rarity, int>
            var groupedArtifacts = temp_artifacts.GroupBy(a => a.SRarity);
            var rarityAndCount = new Dictionary<Artifact.Rarity, int>();

            foreach (var i in groupedArtifacts)
            {
                int n = 0;
                foreach (var j in i)
                {
                    n++;
                }
                rarityAndCount.Add(i.Key, n);
            }
            foreach(var i in rarityAndCount)
            {
                Console.WriteLine($"{i.Key} - {i.Value}");
            }
            Console.WriteLine();

        }

        public void TopByPower(int count, List<Artifact> temp_artifacts)
        {
            var result = temp_artifacts.OrderByDescending(s => s.PowerLewel).ToList();
            int n = 0;
            foreach(var i in result)
            {
                if (n < count)
                {
                    Console.WriteLine($"{i.Name}, {i.PowerLewel}, {i.SRarity}");
                    n++;
                }
                else
                {
                    break;
                }
                
            }
            Console.WriteLine();
        }


    }
}
