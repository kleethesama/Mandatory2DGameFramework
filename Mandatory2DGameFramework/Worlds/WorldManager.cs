namespace Mandatory2DGameFramework.Worlds;

public sealed class WorldManager
{
    private static readonly Lazy<WorldManager> _instance = new(() => new WorldManager());

    public static WorldManager Instance { get => _instance.Value; }

    public World World { get; private set; }

    private WorldManager() { }

    public static void SetWorld(World world)
    {
        Instance.World = world;
    }
}
