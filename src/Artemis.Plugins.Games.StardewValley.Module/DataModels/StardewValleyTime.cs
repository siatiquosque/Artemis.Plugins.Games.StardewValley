using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Artemis.Plugins.Games.StardewValley.DataModels
{
    public enum TimeRange
    {
        Sunrise, //< 750
        Morning, //< 900
        Daytime, //< 1200
        Evening, //< 1600
        Twilight,//< 1750
        Night,   //< 2100
        Midnight//>= 2100
    }
    public class StardewValleyTime
    {
        public bool Paused { get; set; }
        public bool isFestivalDay { get; set; }
        public bool isWeddingToday { get; set; }
        public int Hour { get; set; }
        public int Minute { get; set; }
        public TimeRange Range { get; set; }
    }
}
