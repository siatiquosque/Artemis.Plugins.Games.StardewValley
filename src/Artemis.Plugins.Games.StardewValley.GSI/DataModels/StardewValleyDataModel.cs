using Newtonsoft.Json.Linq;
using StardewModdingAPI;
using StardewValley;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xTile.Dimensions;
using static Artemis.Plugins.Games.StardewValley.GSI.DataModels.StardewValleyPlayer;

namespace Artemis.Plugins.Games.StardewValley.GSI.DataModels
{

    public class StardewValleyDataModel
    {
        public StardewValleyInventory Inventory { get; set; }

        public StardewValleyPlayer Player { get; set; }

        public StardewValleyWorld World { get; set; }

        public StardewValleyJournal Journal { get; set; }

        public StardewValleyGameStatus Game { get; set; }

        public StardewValleyDataModel()
        {
            //Game
            Game = new StardewValleyGameStatus();
            Game.Status = (GameStatus)Game1.gameMode;
            Game.CurrentMenu = Game1.activeClickableMenu?.ToString();
            Game.CurrentMinigameCutscene = Game1.currentMinigame?.ToString();


            //    Inventory = new StardewValleyInventory();

            //    var selected = SelectedSlotNode();

            //    Inventory.SelectedSlot = 

            //Game1.player.CursorSlotItem.attachmentSlots

            if (Context.IsWorldReady)
            {
                Game.IsMultiplayer = Game1.IsMultiplayer;
                Game.IsChatOpened = Game1.IsChatting;

                //Player
                Player = new StardewValleyPlayer();
                Player.Health = new HealthNode();
                Player.Health.Current = Game1.player.health;
                Player.Health.Max = Game1.player.maxHealth;
                //Player.Health.BarActive = Game1.player.heal;

                Player.LocationName = Game1.player.currentLocation.name; 
                Locations result;
                Player.Location = Enum.TryParse<Locations>(Game1.player.currentLocation.name, true, out result) ? result : Locations.Unknown;
                Player.IsOutdoor = Game1.player.currentLocation.IsOutdoors;

                Player.Energy = new EnergyNode();
                Player.Energy.Current = (int)Game1.player.stamina;
                Player.Energy.Max = Game1.player.MaxStamina;

                //World
                World = new StardewValleyWorld();
                World.Time = new StardewValleyTime();
                World.Time.Paused = Game1.isTimePaused;
                World.Time.isFestivalDay = Game1.isFestival();
                World.Time.isWeddingToday = Game1.weddingToday;
                DateTime fromTimeDate = DateTime.ParseExact(Game1.timeOfDay.ToString().PadLeft(4, '0'), "HHmm", CultureInfo.InvariantCulture);

                World.Time.Hour = fromTimeDate.Hour;
                World.Time.Minute = fromTimeDate.Minute;
                //World.Time.Minute = int.Parse(Game1.timeOfDay.ToString().Substring(Game1.timeOfDay.ToString().Length - 2, Game1.timeOfDay.ToString().Length));
                World.Time.Range = getRange(Game1.timeOfDay);

                World.Weather = new StardewValleyWeather();
                World.Weather.IsSnowing = Game1.IsSnowingHere();
                World.Weather.IsRaining = Game1.IsRainingHere();
                World.Weather.IsDebrisWeather = Game1.IsDebrisWeatherHere();
                World.Weather.IsLightning = Game1.IsLightningHere();

                World.Season = getSeason();

                //Journal
                Journal = new StardewValleyJournal();
                Journal.QuestCount = Game1.player.visibleQuestCount;
                Journal.QuestAvailable = Game1.player.hasDailyQuest();
                Journal.NewQuestAvailable = Game1.player.hasNewQuestActivity();
            }

           

        }

        private TimeRange getRange(int time)
        {
            switch (time)
            {
                case < 750: return TimeRange.Sunrise;
                case < 900: return TimeRange.Morning;
                case < 1200: return TimeRange.Daytime;
                case < 1600: return TimeRange.Evening;
                case < 1750: return TimeRange.Twilight;
                case < 2100: return TimeRange.Night;
                case >= 2100: return TimeRange.Midnight;

            }

        }

        private StardewValleySeason getSeason()
        {
            if (Game1.IsSpring)
            {
                return StardewValleySeason.Spring;
            }
            else if (Game1.IsSummer)
            {
                return StardewValleySeason.Summer;
            }
            else if (Game1.IsFall)
            {
                return StardewValleySeason.Fall;
            }
            else if (Game1.IsWinter)
            {
                return StardewValleySeason.Winter;
            }
            else
            {
                return StardewValleySeason.Unknown;
            }

        }

    }
}