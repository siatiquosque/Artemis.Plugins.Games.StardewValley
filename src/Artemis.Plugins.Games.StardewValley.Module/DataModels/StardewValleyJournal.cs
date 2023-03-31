using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Artemis.Plugins.Games.StardewValley.DataModels
{
    public class StardewValleyJournal
    {
        public bool QuestAvailable { get; set; }
        public bool NewQuestAvailable { get; set; } 
        public int QuestCount { get; set; }
    }
}
