using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Artemis.Plugins.Games.StardewValley.DataModels
{
    public class StardewValleyInventory
    {
        public SelectedSlotNode SelectedSlot { get; set; }
    }

    public class SelectedSlotNode
    {
        public int Number { get; set; }
        public string ItemName { get; set; }
        public SelectedSlotColorNode CategoryColor { get; set; }
    }

    public class SelectedSlotColorNode
    {
        public float Red;
        public float Green;
        public float Blue;

    }
}
