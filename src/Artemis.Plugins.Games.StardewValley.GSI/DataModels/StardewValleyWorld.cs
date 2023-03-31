using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Artemis.Plugins.Games.StardewValley.GSI.DataModels
{
    public class StardewValleyWorld
    {
        public StardewValleyWeather Weather { get; set; }
        public StardewValleySeason Season { get; set; }
        public bool isOutdoors { get; set; }
        public int timeOfDay { get; set; }

    }
}
