using Mandatory2DGameFramework.Logging;

namespace Mandatory2DGameFramework.Worlds;

public sealed class WorldManager
{
    private static readonly Lazy<WorldManager> _instance = new(() => new WorldManager());

    public static WorldManager Instance { get => _instance.Value; }

    public World CurrentWorld { get; private set; }

    private WorldManager() { }

    public static void SetWorld(World world)
    {
        MyLogger.Instance.GetTraceSource(nameof(WorldManager)).TraceEvent(
            System.Diagnostics.TraceEventType.Information, 3,
            $"Setting game world to: {world}");
        Instance.CurrentWorld = world;
    }
}
