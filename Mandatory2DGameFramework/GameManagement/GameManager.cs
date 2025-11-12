using Mandatory2DGameFramework.Config;
using Mandatory2DGameFramework.Worlds;

namespace Mandatory2DGameFramework.GameManagement;

public static class GameManager
{
    public static uint TurnCount { get; private set; } = 0;

    public static void DefaultSetup()
    {
        var configurables = new IConfigurable[2];
        var world = new World();
        configurables[0] = world;
        configurables[1] = GameDifficulty.Instance;

        ConfigManager manager = ConfigManager.Instance;
        manager.LoadConfigFile();
        manager.ConfigureAll(configurables);

        WorldManager.SetWorld(world);
    }

    public static void NextTurn()
    {
        TurnCount++;
    }
}
