using Artemis.Core.Modules;

namespace Artemis.Plugins.Games.StardewValley.DataModels;

public class StardewValleyDataModel : DataModel
{
    public StardewValleyStatus Status { get; set; }
    public StardewValleyPlayer Player { get; set; }

    public StardewValleyWorld World { get; set; }

}