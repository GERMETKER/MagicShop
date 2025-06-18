using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MagicShop
{
    public class LegendaryArtifact : Artifact
    {
        public string CurseDesruption {  get; set; }
        public bool IsCursed { get; set; }

        public override void Serialize()
        {
           /* var legendaryArtifact = new LegendaryArtifact { Id = 1, Name = "Narek`s Backpack", SRarity = Rarity.Legendary, PowerLewel = 999, IsCursed = true,
                CurseDesruption = "You must play Clash Royale forever" };*/
            using (StreamWriter writer = new StreamWriter("LegendaryArtifact.txt"))
            {
                writer.WriteLine($"{Id}|{Name}|{PowerLewel}|{SRarity}|{IsCursed}" +
                    $"|{CurseDesruption}");
            }
            
        }
    }
}
