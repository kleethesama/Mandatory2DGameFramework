using Mandatory2DGameFramework.Config;
using Mandatory2DGameFramework.Worlds;

namespace Mandatory2DGameFramework.GameManagement;

public static class GameManager
{
    public static uint TurnCount { get; private set; } = 0;

    public static void DefaultSetup()
    {
        var world = new World();
        var diff = GameDifficulty.Instance;

        var configs = new IConfigurator[2];
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
