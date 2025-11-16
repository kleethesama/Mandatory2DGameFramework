using Mandatory2DGameFramework.Model.Creatures;
using System.Collections.Generic;
using System.Linq;

namespace Mandatory2DGameFramework.Worlds;

public class World
{
    //private readonly List<WorldEntityBase> _worldEntities; // This is better for checking them in the world.
    private readonly List<WorldObject> _worldObjects;
    private readonly List<Creature> _creatures;

    public int MaxX { get; set; }
    public int MaxY { get; set; }

    public World()
    {
        MaxX = 10;
        MaxY = 10;
        //_worldEntities = [];
        _worldObjects = [];
        _creatures = [];
    }

    public World(int maxX, int maxY)
    {
        MaxX = maxX;
        MaxY = maxY;
        //_worldEntities = [];
        _worldObjects = [];
        _creatures = [];
    }

    public World(int maxX, int maxY, List<WorldObject> worldObjects, List<Creature> creatures)
    {
        MaxX = maxX;
        MaxY = maxY;
        _worldObjects = worldObjects;
        _creatures = creatures;
        //List<WorldEntityBase> entityList = new(_worldObjects);
        //entityList.AddRange(_creatures.AsEnumerable<WorldEntityBase>());
        //_worldEntities = entityList;
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

    public void AddCreature(Creature creature)
    {
        _creatures.Add(creature);
    }

    public bool RemoveCreature(Creature creature)
    {
        return _creatures.Remove(creature);
    }

    public void PopulateWorld(List<Creature> creatures)
    {
        foreach (Creature creature in creatures)
        {
            AddCreature(creature);
        }
    }

    public override string ToString()
    {
        return $"{{{nameof(MaxX)} = {MaxX}, {nameof(MaxY)} = {MaxY}}}";
    }
}
