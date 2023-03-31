using Artemis.Core.Modules;

namespace Artemis.Plugins.Games.StardewValley.DataModels;

public class StardewValleyDataModel : DataModel
{
    public StardewValleyInventory Inventory { get; set; }

    public StardewValleyPlayer Player { get; set; }

    public StardewValleyWorld World { get; set; }

    public StardewValleyJournal Journal { get; set; }

    public StardewValleyGameStatus Game { get; set; }

}