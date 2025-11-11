using Mandatory2DGameFramework.Config;
using Mandatory2DGameFramework.Worlds;

namespace Mandatory2DGameFramework.GameManagement;

public static class GameManager
{
    public static uint TurnCount { get; private set; } = 0;

    public static void Start(Action customCode)
    {
        customCode();
    }

    public static void DefaultStart()
    {
        ConfigManager.Instance.StartConfiguring(
            "C:\\Users\\fck\\source\\repos\\Mandatory2DGameFramework\\Mandatory2DGameFramework\\Config\\WorldTestFile.xml");
        int[] worldSize = ConfigManager.Instance.WorldSizeReader.GetValue();
        var world = new World(worldSize[0], worldSize[1]);
        WorldManager.SetWorld(world);
    }

    public static void NextTurn()
    {
        TurnCount++;
    }
}
