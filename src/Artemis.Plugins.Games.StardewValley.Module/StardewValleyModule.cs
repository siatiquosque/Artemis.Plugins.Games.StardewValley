using System;
using System.Collections.Generic;
using Artemis.Core;
using Artemis.Core.Modules;
using Artemis.Core.Services;
using Artemis.Plugins.Games.StardewValley.DataModels;
using Serilog;

namespace Artemis.Plugins.Games.StardewValley;

[PluginFeature(AlwaysEnabled = true, Name = "Stardew Valley")]
public class StardewValleyModule : Module<StardewValleyDataModel>
{

    private readonly IWebServerService _webServerService;

    private DataModelJsonPluginEndPoint<StardewValleyDataModel> _updateEndpoint;

    public override List<IModuleActivationRequirement> ActivationRequirements { get; } = new() { new ProcessActivationRequirement("Stardew Valley") };

    public StardewValleyModule(IWebServerService webServerService)
    {
        _webServerService = webServerService;
    }

    public override void ModuleActivated(bool isOverride)
    {

    }

    public override void ModuleDeactivated(bool isOverride)
    {

    }

    public override void Enable()
    {
        _updateEndpoint = _webServerService.AddDataModelJsonEndPoint(this, "update");

        AddDefaultProfile(DefaultCategoryName.Games, Plugin.ResolveRelativePath("StardewValley.json"));
    }

    public override void Disable()
    {
        _webServerService.RemovePluginEndPoint(_updateEndpoint);
    }

    public override void Update(double deltaTime)
    {

    }
}