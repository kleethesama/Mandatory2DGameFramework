using Mandatory2DGameFramework.Config;
using Mandatory2DGameFramework.Worlds;

namespace Mandatory2DGameFramework;

public static class GameManager
{
    //private static GameManager Instance;
    private static ConfigManager ConfigManager;
    private static WorldManager WorldManager;

    //private GameManager() { }

    //public static GameManager GetInstance()
    //{
    //    Instance ??= new GameManager();
    //    ConfigManager ??= ConfigManager.GetInstance();
    //    WorldManager ??= WorldManager.GetInstance();
    //    return Instance;
    //}

    public static void Start()
    {
        ConfigManager ??= ConfigManager.Instance;
        WorldManager ??= WorldManager.Instance;
        Main();
    }

    private static void Main()
    {
        //ConfigManager.StartConfiguring()
    }
}
