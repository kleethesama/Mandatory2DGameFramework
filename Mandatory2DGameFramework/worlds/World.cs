using Mandatory2DGameFramework.Model.Creatures;
using System.Collections.Generic;
using System.Linq;

namespace Mandatory2DGameFramework.Worlds;

/// <summary>
/// The object that all <see cref="WorldObject"/>s and <see cref="Creature"/>s inhabit.
/// </summary>
public class World
{
    //private readonly List<WorldEntityBase> _worldEntities; // This is better for checking them in the world.
    private readonly List<WorldObject> _worldObjects;
    private readonly List<Creature> _creatures;

    public int MaxX { get; set; }
    public int MaxY { get; set; }

    public World()
    {
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

    /// <summary>
    /// Check if a position is valid for this <see cref="Creature"/>'s <see cref="World"/>.
    /// </summary>
    /// <param name="position">
    /// The coordinate position to check for.
    /// </param>
    /// <returns>
    /// <see langword="true"/> if within world boundaries, otherwise <see langword="false"/>.
    /// </returns>
    public bool IsWithinWorld(WorldPosition position)
    {
        if (position.X > MaxX || position.X < 0 || position.Y > MaxY || position.Y < 0)
        {
            return false;
        }
        return true;
    }

    /// <summary>
    /// Check if a world position is occupied by a <see cref="Creature"/>.
    /// </summary>
    /// <param name="position">
    /// The world position to check.
    /// </param>
    /// <param name="creature">
    /// The <see cref="Creature"/> in that world position. 
    /// Will be <see langword="null"/> if method returns <see langword="false"/>.
    /// </param>
    /// <returns>
    /// <see langword="true"/> if a <see cref="Creature"/> is found, otherwise <see langword="false"/>. 
    /// </returns>
    /// <exception cref="ArgumentException">Invalid world position to check.</exception>
    public bool TryIsPositionOccupied(WorldPosition position, out Creature? creature)
    {
        if (!IsWithinWorld(position))
        {
            throw new ArgumentException("Invalid world position to check.", nameof(position));
        }
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

    /// <summary>
    /// Check if a world position is occupied by a <see cref="WorldObject"/>.
    /// </summary>
    /// <param name="position">
    /// The world position to check.
    /// </param>
    /// <param name="worldObject">
    /// The <see cref="WorldObject"/> in that world position. 
    /// Will be <see langword="null"/> if method returns <see langword="false"/>.
    /// </param>
    /// <returns>
    /// <see langword="true"/> if a <see cref="WorldObject"/> is found, otherwise <see langword="false"/>. 
    /// </returns>
    /// <exception cref="ArgumentException">Invalid world position to check.</exception>
    public bool TryIsPositionOccupied(WorldPosition position, out WorldObject? worldObject)
    {
        if (!IsWithinWorld(position))
        {
            throw new ArgumentException("Invalid world position to check.", nameof(position));
        }
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

    /// <summary>
    /// Adds a <see cref="Creature"/> to this world.
    /// </summary>
    /// <param name="creature">
    /// The <see cref="Creature"/> to be added.
    /// </param>
    public void AddCreature(Creature creature)
    {
        _creatures.Add(creature);
    }

    /// <summary>
    /// Removes a <see cref="Creature"/> from this world.
    /// </summary>
    /// <param name="creature">
    /// The <see cref="Creature"/> to be removed.
    /// </param>
    public bool RemoveCreature(Creature creature)
    {
        return _creatures.Remove(creature);
    }

    /// <summary>
    /// Option for adding several <see cref="Creature"/>s to this world at once.
    /// </summary>
    /// <param name="creatures">
    /// The <see cref="Creature"/>s to be added.
    /// </param>
    public void PopulateWorld(IEnumerable<Creature> creatures)
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
