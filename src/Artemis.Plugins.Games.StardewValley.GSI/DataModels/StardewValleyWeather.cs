using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Artemis.Plugins.Games.StardewValley.GSI.DataModels
{
    public class StardewValleyWeather
    {
        public bool IsSnowing { get; set; }
        public bool IsRaining { get; set; }
        public bool IsDebrisWeather { get; set; }
        public bool IsLightning { get; set; }
    }
}
