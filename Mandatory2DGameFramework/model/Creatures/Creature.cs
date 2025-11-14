using Mandatory2DGameFramework.Model.Attack;
using Mandatory2DGameFramework.Model.Defence;
using Mandatory2DGameFramework.Worlds;

namespace Mandatory2DGameFramework.Model.Creatures;

public abstract class Creature(string name, WorldPosition position, World world) : WorldEntityBase(name, position, world), IHitSubject
{
    private readonly List<IHitObserver> _observers = [];

    public abstract bool IsPlayer { get; }
    public abstract int HitPoint { get; set; }
    public abstract int MoveRange { get; set; }
    public abstract int DetectRange { get; set; }
    public abstract List<AttackItem> AttackItems { get; set; }
    public abstract List<DefenceItem> DefenceItems { get; set; }

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
            throw new ArgumentException("New position exceeds world boundaries.", nameof(newPosition));
        }
        Position = newPosition;
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

    public void Loot(WorldObject obj)
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
