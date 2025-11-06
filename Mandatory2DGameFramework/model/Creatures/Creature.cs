using Mandatory2DGameFramework.Model.Attack;
using Mandatory2DGameFramework.Model.Defence;
using Mandatory2DGameFramework.Worlds;

namespace Mandatory2DGameFramework.Model.Creatures;

public abstract class Creature : WorldEntityBase
{
    public int HitPoint { get; set; }

    //public abstract List<AttackItem> Attack { get; set; }
    //public abstract List<DefenceItem> Defence { get; set; }
    public AttackItem? Attack { get; set; }
    public DefenceItem? Defence { get; set; }


    public Creature() : base()
    {
        HitPoint = 100;
        Attack = null;
        Defence = null;
    }

    public Creature(string name, int hitPoint) : base(name)
    {
        HitPoint = hitPoint;
        Attack = null;
        Defence = null;
    }

    public Creature(string name, int hitPoint, AttackItem attackItem, DefenceItem defenceItem) : base(name)
    {
        HitPoint = hitPoint;
        Attack = attackItem;
        Defence = defenceItem;
    }

    public Creature(string name, WorldPosition position, int hitPoint) : base(name, position)
    {
        HitPoint = hitPoint;
        Attack = null;
        Defence = null;
    }

    public Creature(string name, WorldPosition position, int hitPoint, AttackItem attackItem, DefenceItem defenceItem) : base(name, position)
    {
        HitPoint = hitPoint;
        Attack = attackItem;
        Defence = defenceItem;
    }

    public int Hit(Creature creature)
    {
        if (Attack == null) { return 0; }
        var hit = Attack.Hit;
        creature.ReceiveHit(hit);
        return hit;
    }

    public void ReceiveHit(int hit)
    {
        if (Defence == null)
        {
            HitPoint -= hit;
            return;
        }
        HitPoint -= hit - Defence.ReduceHitPoint;
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
