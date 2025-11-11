using Mandatory2DGameFramework.Config;
using Mandatory2DGameFramework.Worlds;

namespace Mandatory2DGameFramework.GameManagement;

public static class GameManager
{
    public static uint TurnCount { get; private set; } = 0;
    public static GameDifficulty GameDifficulty { get; } = new(); // Can be made into a lazy singleton.

    public static void DefaultStart()
    {
        var xmlDoc = ConfigManager.LoadConfigFile(
            "C:\\Users\\fck\\source\\repos\\Mandatory2DGameFramework\\Mandatory2DGameFramework\\Config\\WorldTestFile.xml");
        if (xmlDoc == null) { return; }
        ConfigManager.Instance.ConfigureAll(xmlDoc);

        int[] worldSize = ConfigManager.Instance.WorldSizeReader.GetValue();
        var world = new World(worldSize[0], worldSize[1]);
        WorldManager.SetWorld(world);

        int difficulty = ConfigManager.Instance.DifficultyReader.GetValue();
        GameDifficulty.SetDifficulty(difficulty);
    }

    public static void NextTurn()
    {
        TurnCount++;
    }
}
