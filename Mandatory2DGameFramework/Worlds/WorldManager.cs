namespace Mandatory2DGameFramework.Worlds;

public sealed class WorldManager
{
    private static Lazy<WorldManager> Instance => new(() => new WorldManager());

    public World World { get; private set; }

    private WorldManager() { }

    public static WorldManager GetInstance(World world)
    {
        if (!Instance.IsValueCreated)
        {
            var manager = Instance.Value;
            manager.World = world;
        }
        return Instance.Value;
    }

    //public static bool TryCreateInstance(World world, out WorldManager? worldManager)
    //{
    //    if (!Instance.IsValueCreated)
    //    {
    //        Instance = new Lazy<WorldManager>(() => new WorldManager());
    //        Instance.Value.World = world;
    //        worldManager = Instance.Value;
    //        return true;
    //    }
    //    worldManager = null;
    //    return false;
    //}
}
