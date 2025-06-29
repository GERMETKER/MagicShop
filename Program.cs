namespace MagicShop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var antiqueArtifacts = new List<AntiqueArtifact>();
            antiqueArtifacts.Add(new AntiqueArtifact { Id = 1, Age = 1000, Name = "Кольцо Меркурия", SRarity = AntiqueArtifact.Rarity.Epic, OriginRealm = "Греция", PowerLewel = 120 });
            antiqueArtifacts.Add(new AntiqueArtifact { Id = 2, Age = 1200, Name = "Ожерелье Петуса", SRarity = AntiqueArtifact.Rarity.Rare, OriginRealm = "Египет", PowerLewel = 97 });
            antiqueArtifacts.Add(new AntiqueArtifact { Id = 3, Age = 920, Name = "Киста Перфоратора", SRarity = AntiqueArtifact.Rarity.Common, OriginRealm = "Терарийская Империя", PowerLewel = 79 });

            var modernArtifacts = new List<ModernArtifact>();
            modernArtifacts.Add(new ModernArtifact { Id = 1, TechLevel = 70, Name = "Винтовка Снайдера", SRarity = ModernArtifact.Rarity.Rare, Manufacturer = "Оружейный завод Снайдера", PowerLewel = 101 });
            modernArtifacts.Add(new ModernArtifact { Id = 2, TechLevel = 89, Name = "Бур Всевластия", SRarity = ModernArtifact.Rarity.Epic, Manufacturer = "Горнодобывающая кампания Вольтек", PowerLewel = 150 });
            modernArtifacts.Add(new ModernArtifact { Id = 3, TechLevel = 54, Name = "Исцеляющий Желет", SRarity = ModernArtifact.Rarity.Common, Manufacturer = "Медицинская компания Аризона", PowerLewel = 79 });

            var legendaryArtifact = new List<LegendaryArtifact>();
            legendaryArtifact.Add(new LegendaryArtifact { Id = 1, Name = "Кнопка Активации Ядерного взрыва", IsCursed = false, PowerLewel = 200, CurseDesruption = " ", SRarity = LegendaryArtifact.Rarity.Legendary });
            legendaryArtifact.Add(new LegendaryArtifact { Id = 2, Name = "Убийца Драконов", IsCursed = true, PowerLewel = 220, CurseDesruption = "Использование приведёт к постепенному снижению здоровья", SRarity = LegendaryArtifact.Rarity.Legendary });
            legendaryArtifact.Add(new LegendaryArtifact { Id = 3, Name = "Леденатор 3000", IsCursed = false, PowerLewel = 190, CurseDesruption = " ", SRarity = LegendaryArtifact.Rarity.Legendary });

            var xmlProcessor = new XmlProcessor();
            var jsonProcessor = new JsonProcessor();
            var legendaryProcessor = new LegendaryProcessor();

            //
            //
            //

            Console.WriteLine("Введите имя файла для Старинных артифактов(.xml формат данных)");
            string fileAntuque = Console.ReadLine();

            Console.WriteLine("Введите имя файла для Современных артифактов(.json формат данных)");
            string fileModrn = Console.ReadLine();

            Console.WriteLine("Введите имя файла для Легендарных артифактов(.txt формат данных)");
            string filelegendary = Console.ReadLine();

            xmlProcessor.SaveData(antiqueArtifacts, fileAntuque);
            jsonProcessor.SaveData(modernArtifacts, fileModrn);
            legendaryProcessor.SaveData(legendaryArtifact, filelegendary);

            ShopManager shopManager = new ShopManager();
            List<Artifact> artifacts = shopManager.LoadAllData(fileAntuque, fileModrn, filelegendary);

            Console.WriteLine("Введите имя файла для среднего уровня силы по редкости");
            string averageLevels = Console.ReadLine();

            shopManager.GenerateReport(averageLevels, artifacts);

            shopManager.FindCursedArtifacts(legendaryArtifact);
            shopManager.GroupByRarity(artifacts);
            shopManager.TopByPower(10, artifacts);

        }
    }
}
