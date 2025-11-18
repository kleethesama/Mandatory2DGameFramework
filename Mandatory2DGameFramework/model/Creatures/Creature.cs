using Mandatory2DGameFramework.Logging;
using Mandatory2DGameFramework.Model.Inventory;
using Mandatory2DGameFramework.Model.Items;
using Mandatory2DGameFramework.Model.Items.Attack;
using Mandatory2DGameFramework.Model.Items.Defence;
using Mandatory2DGameFramework.Worlds;

namespace Mandatory2DGameFramework.Model.Creatures;

/// <summary>
/// Base class for a creature living in a <see cref="World"/>.
/// It serves as the basis for all players and NPCs in the game.
/// </summary>
/// <param name="name">Name of the creature.</param>
/// <param name="position">The creatures initial position in world.</param>
/// <param name="world">The world the creature is in.</param>
public abstract class Creature(string name, WorldPosition position, World world) : WorldEntityBase(name, position, world), IHitSubject, IHitObserver
{
    private readonly List<IHitObserver> _observers = [];

    public abstract bool IsPlayer { get; }
    public virtual int MaxHitPoint { get; protected set; } // Needs range validation for setter
    public abstract int HitPoint { get; protected set; }
    public virtual int MoveRange { get; set; } // Needs range validation for setter
    public virtual int DetectRange { get; set; } // Needs range validation for setter
    public abstract List<AttackItem> AttackItems { get; set; }
    public abstract List<DefenceItem> DefenceItems { get; set; }
    public abstract ItemHandler ItemHandler { protected get; set; } // Strategy pattern

    /// <summary>
    /// Calculates the distance for when a creature needs to move.
    /// </summary>
    /// <param name="vector">
    /// The given vector for which the length is needed from.
    /// </param>
    /// <returns>
    /// The rounded down length of the vector.
    /// </returns>
    private static int CalculateDistance(WorldPosition vector)
    {
        double distance = Math.Sqrt(Math.Pow(vector.X, 2) + Math.Pow(vector.Y, 2));
        return (int)Math.Floor(distance);
    }

    /// <summary>
    /// Moves this <see cref="Creature"/> to a new position in the <see cref="World"/> 
    /// based on their movement range.
    /// </summary>
    /// <param name="directionVector">
    /// The direction of movement using this <see cref="Creature"/>'s current position.
    /// </param>
    /// <exception cref="ArgumentException">
    /// Movement vector must be less- or equal to the creature's movement range.
    /// </exception>
    public void Move(WorldPosition directionVector)
    {
        if (MoveRange == 0) { return; }
        WorldPosition newPosition = Position + directionVector;
        if (!World.IsWithinWorld(newPosition)) { return; } // Could make this into an exception too.
        int moveDistance = CalculateDistance(directionVector);
        if (moveDistance > MoveRange)
        {
            throw new ArgumentException(
                "Movement vector must be less- or equal to the creature's movement range.",
                nameof(directionVector));
        }
        Position = newPosition;
    }

    /// <summary>
    /// Moves this <see cref="Creature"/> to a new position in the <see cref="World"/> 
    /// without regard for their movement range.
    /// </summary>
    /// <param name="newPosition">
    /// The new position to move to in the <see cref="World"/>.
    /// </param>
    public void MoveTo(WorldPosition newPosition)
    {
        if (!World.IsWithinWorld(newPosition)) { return; }
        Position = newPosition;
    }

    public void AddAttackItem(AttackItem attackItem)
    {
        ItemHandler.AddAttackItem(attackItem, AttackItems); // Uses strategy to handle items
    }

    public void AddDefenceItem(DefenceItem defenceItem)
    {
        ItemHandler.AddDefenceItem(defenceItem, DefenceItems);
    }

    public int Hit(Creature creature)
    {
        if (AttackItems.Count == 0) { return 0; }
        int totalDamage = 0;
        foreach (var attackItem in AttackItems)
        {
            if (CalculateDistance(Position - creature.Position) > attackItem.Range) { continue; }
            creature.ReceiveHit(attackItem.HitDamage);
            totalDamage += attackItem.HitDamage;
        }
        return totalDamage;
    }

    public void ReceiveHit(int hit)
    {
        if (DefenceItems.Count == 0)
        {
            HitPoint -= hit;
            NotfiyHit($"{Name} received attack with sum of {hit}. " +
                $"({Name} has no defence items)");
            return;
        }
        int totalDefence = 0;
        foreach (var defenceItem in DefenceItems)
        {
            totalDefence += defenceItem.ReduceHitPoint;
        }
        int totalDamage = hit - totalDefence;
        if (totalDamage <= 0)
        {
            NotfiyHit($"{Name} received attack of {hit} but negated all damage.");
            return;
        }
        HitPoint -= totalDamage;
        NotfiyHit($"{Name} received attack of {hit} but reduced it to {totalDamage}.");
    }

    private bool IsPlaceDistanceSufficient(WorldPosition position)
    {
        // Probably shouldn't hard code the place distance, but oh well.
        if (CalculateDistance(position - Position) > 1) { return false; }
        return true;
    }

    public void PlaceItemInWorld(WorldPosition position, WorldObject obj)
    {
        if (!IsPlaceDistanceSufficient(position)) { return; }
        throw new NotImplementedException();
    }

    public void Loot(Loot obj)
    {
        if (obj.WorldObject != null && !obj.WorldObject.Lootable) { return; }
        Type objType = obj.GetType();
        if (objType == typeof(AttackItem))
        {
            AddAttackItem(obj as AttackItem);
        }
        else if (objType == typeof(DefenceItem))
        {
            AddDefenceItem(obj as DefenceItem);
        }
    }

    public bool CanLootPosition(WorldPosition position, out WorldObject? foundObject)
    {
        if (!World.TryIsPositionOccupied(position, out WorldObject? worldObject))
        {
            foundObject = null;
            return false;
        }
        foundObject = worldObject;
        return true;
    }

    public WorldObject? GetLootObject(WorldPosition position)
    {
        throw new NotImplementedException();
    }

    public bool IsDead()
    {
        return HitPoint <= 0;
    }

    public override string ToString()
    {
        return base.ToString() +
            $", {nameof(IsPlayer)} = {IsPlayer}, " +
            $"{nameof(MaxHitPoint)} = {MaxHitPoint}, " +
            $"{nameof(HitPoint)} = {HitPoint}, " +
            $"{nameof(MoveRange)} = {MoveRange}, " +
            $"{nameof(DetectRange)} = {DetectRange}}}";
    }

    public void Attach(IHitObserver observer)
    {
        _observers.Add(observer);
    }

    public bool Detach(IHitObserver observer)
    {
        return _observers.Remove(observer);
    }

    public void NotfiyHit(string message)
    {
        foreach (var observer in _observers)
        {
            observer.Update(this, message);
        }
    }

    public void Update(IHitSubject subject, string message)
    {
        Creature creature = subject as Creature;
        MyLogger.Instance.GetTraceSource(nameof(Creature)).TraceEvent(
            System.Diagnostics.TraceEventType.Information, 0, message);
    }
}
