namespace Mandatory2DGameFramework.Worlds;

public sealed class WorldManager
{
    private static Lazy<WorldManager> Instance => new(() => new WorldManager());

    public World World { get; private set; }

    private WorldManager() { }

    public static WorldManager GetInstance(World? world = null)
    {
        if (!Instance.IsValueCreated && world != null)
        {
            var worldManager = Instance.Value;
            worldManager.World = world;
        }
        return Instance.Value;
    }
}
