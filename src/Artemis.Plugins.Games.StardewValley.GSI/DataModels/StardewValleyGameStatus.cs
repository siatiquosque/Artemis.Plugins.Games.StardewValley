using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Artemis.Plugins.Games.StardewValley.GSI.DataModels
{
    public enum GameStatus
    {
        Unknown = -1,
        TitleScreen = 0,
        PlayingGame = 3,
        //LogoScreen = 4,
        Loading = 6,
    }
    public class StardewValleyGameStatus
    {
        public GameStatus Status { get; set; }
        public string CurrentMenu { get; set; }
        public string CurrentMinigameCutscene { get; set; }
        public bool IsMultiplayer { get; set; }
        public bool IsChatOpened { get; set; }
    }
}
