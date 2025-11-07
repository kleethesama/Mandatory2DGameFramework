using Mandatory2DGameFramework.Model.Attack;
using Mandatory2DGameFramework.Model.Defence;
using Mandatory2DGameFramework.Worlds;

namespace Mandatory2DGameFramework.Model.Creatures;

public abstract class Creature(string name, WorldPosition position) : WorldEntityBase(name, position)
{
    private static readonly World s_world;

    public abstract int HitPoint { get; set; }
    public abstract int MoveRange { get; set; }
    public abstract int DetectRange { get; set; }
    public abstract List<AttackItem> AttackItems { get; set; }
    public abstract List<DefenceItem> DefenceItems { get; set; }

    private static int CalculateMoveDistance(WorldPosition directionVector)
    {
        double distance = Math.Sqrt(Math.Pow(directionVector.X, 2) + Math.Pow(directionVector.Y, 2));
        return (int)Math.Floor(distance);
    }

    public void Move(WorldPosition directionVector)
    {
        if (MoveRange == 0) { return; }
        int moveDistance = CalculateMoveDistance(directionVector);
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
        if (newPosition.X > s_world.MaxX || newPosition.Y > s_world.MaxY)
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
            return;
        }
        int totalDefence = 0;
        foreach (var defenceItem in DefenceItems)
        {
            totalDefence += defenceItem.ReduceHitPoint;
        }
        int totalDamage = hit - totalDefence;
        if (totalDamage <= 0) { return; }
        HitPoint -= totalDamage;
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
}
