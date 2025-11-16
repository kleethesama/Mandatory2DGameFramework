using Mandatory2DGameFramework.Config;
using Mandatory2DGameFramework.Logging;
using Mandatory2DGameFramework.Worlds;

namespace Mandatory2DGameFramework.GameManagement;

public static class GameManager
{
    public static uint TurnCount { get; private set; } = 0;

    public static void DefaultSetup()
    {
        MyLogger.Instance.GetTraceSource(nameof(GameManager)).TraceEvent(
            System.Diagnostics.TraceEventType.Information, 0,
            "Starting default setup using the GameManager.");

        var world = new World();
        var diff = GameDifficulty.Instance;

        var configs = new Configurator[2];
        configs[0] = new WorldSizeConfigurator(world);
        configs[1] = new DifficultyConfigurator(diff);

        ConfigManager manager = ConfigManager.Instance;
        manager.LoadConfigFile();
        manager.ConfigureAll(configs);

        WorldManager.SetWorld(world);
    }

    public static void NextTurn()
    {
        TurnCount++;
    }
}
