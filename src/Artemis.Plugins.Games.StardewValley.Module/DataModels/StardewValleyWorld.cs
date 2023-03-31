using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Artemis.Plugins.Games.StardewValley.DataModels
{
    public class StardewValleyWorld
    {
        public StardewValleyTime Time { get; set; }
        public StardewValleyWeather Weather { get; set; }
        public StardewValleySeason Season { get; set; }

    }
}
