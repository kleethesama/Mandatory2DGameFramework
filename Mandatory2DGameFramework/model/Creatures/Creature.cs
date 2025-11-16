using Mandatory2DGameFramework.Model.Inventory;
using Mandatory2DGameFramework.Model.Items;
using Mandatory2DGameFramework.Model.Items.Attack;
using Mandatory2DGameFramework.Model.Items.Defence;
using Mandatory2DGameFramework.Worlds;

namespace Mandatory2DGameFramework.Model.Creatures;

public abstract class Creature(string name, WorldPosition position, World world) : WorldEntityBase(name, position, world), IHitSubject
{
    private readonly List<IHitObserver> _observers = [];

    public abstract bool IsPlayer { get; }
    public abstract int MaxHitPoint { get; protected set; }
    public abstract int HitPoint { get; protected set; }
    public abstract int MoveRange { get; set; }
    public abstract int DetectRange { get; set; }
    public abstract List<AttackItem> AttackItems { protected get; set; }
    public abstract List<DefenceItem> DefenceItems { protected get; set; }
    public abstract IItemHandler ItemHandler { protected get; set; } // Strategy pattern

    private static int CalculateDistance(WorldPosition directionVector)
    {
        double distance = Math.Sqrt(Math.Pow(directionVector.X, 2) + Math.Pow(directionVector.Y, 2));
        return (int)Math.Floor(distance);
    }

    public void Move(WorldPosition directionVector)
    {
        if (MoveRange == 0) { return; }
        int moveDistance = CalculateDistance(directionVector);
        if (moveDistance > MoveRange)
        {
            throw new ArgumentException(
                "Movement vector must be less- or equal to the creature's movement range.",
                nameof(directionVector));
        }
        MoveTo(Position + directionVector);
    }

    private void MoveTo(WorldPosition newPosition)
    {
        if (newPosition.X > World.MaxX || newPosition.Y > World.MaxY)
        {
            throw new ArgumentException(
                $"New position {newPosition} exceeds world boundaries.",
                nameof(newPosition));
        }
        Position = newPosition;
    }

    public void AddAttackItem(AttackItem attackItem)
    {
        ItemHandler.AddAttackItem(attackItem, AttackItems);
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
            NotfiyHit();
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
            NotfiyHit();
            return;
        }
        HitPoint -= totalDamage;
        NotfiyHit();
    }

    private bool IsPlaceDistanceSufficient(WorldPosition position)
    {
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
            $", {nameof(HitPoint)} = {HitPoint}, " +
            $"{nameof(AttackItems)} = {AttackItems}, " +
            $"{nameof(DefenceItems)} = {DefenceItems}}}";
    }

    public void Attach(IHitObserver observer)
    {
        _observers.Add(observer);
    }

    public bool Detach(IHitObserver observer)
    {
        return _observers.Remove(observer);
    }

    public void NotfiyHit()
    {
        foreach (var observer in _observers)
        {
            observer.Update(this);
        }
    }
}
