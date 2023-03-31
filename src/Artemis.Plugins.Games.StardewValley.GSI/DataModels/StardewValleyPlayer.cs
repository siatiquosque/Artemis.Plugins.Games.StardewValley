using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Artemis.Plugins.Games.StardewValley.GSI.DataModels
{
    public class StardewValleyPlayer
    {
        public enum Locations
        {
            Unknown = -1,
            Farm,
            Beach,
            AnimalHouse,
            SlimeHutch,
            Shed,
            LibraryMuseum,
            AdventureGuild,
            Woods,
            Railroad,
            Summit,
            Forest,
            ShopLocation,
            SeedShop,
            FishShop,
            BathHousePool,
            FarmHouse,
            Cabin,
            Club,
            BusStop,
            CommunityCenter,
            Desert,
            FarmCave,
            JojaMart,
            MineShaft,
            Mountain,
            Sewer,
            WizardHouse,
            Town,
            Cellar,
            Submarine,
            MermaidHouse,
            BeachNightMarket,
            MovieTheater,
            ManorHouse,
            AbandonedJojaMart,
            Mine
        }

        public HealthNode Health { get; set; }
        public string LocationName { get; set; }
        public Locations Location { get; set; }
        public bool IsOutdoor { get; set; }
        public EnergyNode Energy { get; set; }

        public class EnergyNode
        {
            public int Current { get; set; }
            public int Max { get; set; }
        }

        public class HealthNode
        {
            public int Current { get; set; }
            public int Max { get; set; }
            public bool BarActive { get; set; }
        }



    }
}
