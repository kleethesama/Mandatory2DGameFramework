using Mandatory2DGameFramework.Model.Creatures;

namespace Mandatory2DGameFramework.Worlds;

public class World
{
    private readonly List<WorldObject> _worldObjects;
    private readonly List<Creature> _creatures;

    public int MaxX { get; set; }
    public int MaxY { get; set; }

    public World(int maxX, int maxY)
    {
        MaxX = maxX;
        MaxY = maxY;
        _worldObjects = [];
        _creatures = [];
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
}
