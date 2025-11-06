using Mandatory2DGameFramework.Model.Attack;
using Mandatory2DGameFramework.Model.Defence;
using Mandatory2DGameFramework.Worlds;

namespace Mandatory2DGameFramework.Model.Creatures;

public abstract class Creature(string name, WorldPosition position) : WorldEntityBase(name, position)
{
    public abstract int HitPoint { get; set; }
    public abstract int MoveRange { get; set; }
    public abstract List<AttackItem> Attack { get; set; }
    public abstract List<DefenceItem> Defence { get; set; }

    public abstract void Move(WorldPosition directionVector);

    private void MoveTo(WorldPosition newPosition)
    {
        Position = newPosition;
    }

    public int Hit(Creature creature)
    {
        if (Attack.Count == 0) { return 0; }
        int totalDamage = 0;
        foreach (var attackItem in Attack)
        {
            creature.ReceiveHit(attackItem.Hit);
            totalDamage += attackItem.Hit;
        }
        return totalDamage;
    }

    public void ReceiveHit(int hit)
    {
        if (Defence.Count == 0)
        {
            HitPoint -= hit;
            return;
        }
        int totalDefence = 0;
        foreach (var defenceItem in Defence)
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
            $"{nameof(Attack)} = {Attack}, " +
            $"{nameof(Defence)} = {Defence}}}";
    }
}
