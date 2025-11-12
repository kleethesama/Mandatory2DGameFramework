using Mandatory2DGameFramework.Config;
using Mandatory2DGameFramework.Model.Creatures;
using System.Xml;

namespace Mandatory2DGameFramework.Worlds;

public class World : IConfigurable
{
    private readonly List<WorldObject> _worldObjects;
    private readonly List<Creature> _creatures;

    public int MaxX { get; set; }
    public int MaxY { get; set; }
    public Configurator<World>? Configurator { get; set; } = new WorldSizeConfigurator();

    public World()
    {
        MaxX = 10;
        MaxY = 10;
        _worldObjects = [];
        _creatures = [];
    }

    public World(int maxX, int maxY)
    {
        MaxX = maxX;
        MaxY = maxY;
        _worldObjects = [];
        _creatures = [];
    }

    public World(int maxX, int maxY, List<WorldObject> worldObjects, List<Creature> creatures)
    {
        MaxX = maxX;
        MaxY = maxY;
        _worldObjects = worldObjects;
        _creatures = creatures;
    }

    public bool TryIsPositionOccupied(WorldPosition position, out Creature? creature)
    {
        foreach (var worldCreature in _creatures)
        {
            if (worldCreature.Position == position)
            {
                creature = worldCreature;
                return true;
            }
        }
        creature = null;
        return false;
    }

    public bool TryIsPositionOccupied(WorldPosition position, out WorldObject? worldObject)
    {
        foreach (var @object in _worldObjects)
        {
            if (@object.Position == position)
            {
                worldObject = @object;
                return true;
            }
        }
        worldObject = null;
        return false;
    }

    public override string ToString()
    {
        return $"{{{nameof(MaxX)} = {MaxX}, {nameof(MaxY)} = {MaxY}}}";
    }

    public bool TryConfigure(XmlDocument xmlDoc)
    {
        if (Configurator == null) { return false; }
        return Configurator.TryConfigure(xmlDoc, this);
    }
}
