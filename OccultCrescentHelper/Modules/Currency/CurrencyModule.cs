using Dalamud.Plugin.Services;
using Ocelot.Modules;

namespace BOCCHI.Modules.Currency;

[OcelotModule(5, 3)]
public class CurrencyModule : Module<Plugin, Config>
{
    public override CurrencyConfig config
    {
        get => _config.CurrencyConfig;
    }

    public override bool enabled
    {
        get => config.IsPropertyEnabled(nameof(config.Enabled));
    }

    public readonly CurrencyTracker tracker = new();

    private Panel panel = new();

    public CurrencyModule(Plugin plugin, Config config)
        : base(plugin, config)
    {
    }

    public override void Tick(IFramework framework)
    {
        tracker.Tick(framework);
    }

    public override void OnTerritoryChanged(ushort _)
    {
        tracker.Reset();
    }

    public override bool DrawMainUi()
    {
        panel.Draw(this);
        return true;
    }
}
