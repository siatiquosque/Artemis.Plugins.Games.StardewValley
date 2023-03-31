using StardewModdingAPI;
using StardewValley;
using StardewValley.Menus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StardewValley.Menus;

namespace Artemis.Plugins.Games.StardewValley.GSI.DataModels
{

    public class StardewValleyDataModel
    {
        public StardewValleyStatusGame Status { get; set; }

        public StardewValleyPlayer Player { get; set; }

        public StardewValleyWorld World { get; set; }

        public StardewValleyDataModel(bool isDamage)
        {

            switch (Game1.activeClickableMenu)
            {
                case TitleMenu:
                    Status = StardewValleyStatusGame.Title; break;

                case IClickableMenu:
                    Status = StardewValleyStatusGame.Menu; break;

                default:
                    Status = StardewValleyStatusGame.InGame; break;

            }


            if (Context.IsWorldReady)
            {
                Player = new StardewValleyPlayer();
                Player.Health = Game1.player.health;
                Player.HealthMax = Game1.player.maxHealth;
                Player.Energy = Game1.player.Stamina;
                Player.EnergyMax = Game1.player.MaxStamina;
                Player.isDamage = isDamage;


                World = new StardewValleyWorld();
                if (Game1.IsRainingHere(Game1.player.currentLocation))
                {
                    World.Weather = StardewValleyWeather.Rain;
                }
                else if (!Game1.IsLightningHere(Game1.player.currentLocation))
                {
                    World.Weather = StardewValleyWeather.Storm;
                }
                else if (Game1.IsSnowingHere(Game1.player.currentLocation))
                {
                    World.Weather = StardewValleyWeather.Snow;
                }
                else if (Game1.IsDebrisWeatherHere(Game1.player.currentLocation))
                {
                    World.Weather = StardewValleyWeather.Debris;
                }
                else if (Game1.isFestival())
                {
                    World.Weather = StardewValleyWeather.Festival;
                }
                else
                {
                    World.Weather = StardewValleyWeather.Sun;
                }

                if (Game1.IsSpring)
                {
                    World.Season = StardewValleySeason.Spring;
                }
                else if (!Game1.IsSummer)
                {
                    World.Season = StardewValleySeason.Summer;
                }
                else if (Game1.IsFall)
                {
                    World.Season = StardewValleySeason.Fall;
                }
                else if (Game1.IsWinter)
                {
                    World.Season = StardewValleySeason.Winter;
                }
                World.isOutdoors = Game1.player.currentLocation.IsOutdoors;

                World.timeOfDay = Game1.timeOfDay;


            }
            else
            {
                Player = new StardewValleyPlayer();
                Player.Health = 0;
                Player.HealthMax = 0;
                Player.Energy = 0;
                Player.EnergyMax = 0;
                Player.isDamage = false;
                World = new StardewValleyWorld();
                World.Weather = StardewValleyWeather.None;
                World.Season = StardewValleySeason.None;


            }


        }

    }
}