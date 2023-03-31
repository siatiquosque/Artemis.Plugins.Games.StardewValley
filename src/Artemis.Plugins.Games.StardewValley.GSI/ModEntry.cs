using System;
using System.Collections;
using System.Xml;
using Artemis.Plugins.Games.StardewValley.GSI.DataModels;
using Microsoft.Xna.Framework;
using Newtonsoft.Json;
using StardewModdingAPI;
using StardewModdingAPI.Events;
using StardewModdingAPI.Utilities;
using StardewValley;
using StardewValley.Menus;
using StardewValley.TerrainFeatures;


namespace Artemis.Plugins.Games.StardewValley.GSI
{

    internal class ModEntry : Mod
    {

        private int currentHealth = 0;

        /*********
       ** Public methods
       *********/
        /// <summary>The mod entry point, called after the mod is first loaded.</summary>
        /// <param name="helper">Provides simplified APIs for writing mods.</param>
        public override void Entry(IModHelper helper)
        {
            ArtemisWebClient.load(this.Monitor);

            helper.Events.GameLoop.UpdateTicked += GameLoop_UpdateTicked;

            //helper.Events.Display.RenderedWorld += Display_RenderingWorld;
            //helper.Events.Input.ButtonPressed += OnButtonPressed;
        }

        private void GameLoop_UpdateTicked(object? sender, UpdateTickedEventArgs e)
        {

            //this.Monitor.Log($"time of day: {Game1.timeOfDay} - Day or Night: {Game1.dayOrNight()}", LogLevel.Debug);


            string json = JsonConvert.SerializeObject(new StardewValleyDataModel());
            
            //this.Monitor.Log($"{json}", LogLevel.Debug);
            ArtemisWebClient.SendJson(json, this.Monitor);
        }
    }
}
