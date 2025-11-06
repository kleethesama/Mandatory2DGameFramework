using Mandatory2DGameFramework.Model.Attack;
using Mandatory2DGameFramework.Model.Defence;
using Mandatory2DGameFramework.Worlds;

namespace Mandatory2DGameFramework.Model.Creatures;

public class Creature : WorldEntityBase
{
    public int HitPoint { get; set; }

    // Todo consider how many attack / defence weapons are allowed
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

    public int Hit()
    {
        throw new NotImplementedException();
    }

    public void ReceiveHit(int hit)
    {
        throw new NotImplementedException();
    }

    public void Loot(WorldObject obj)
    {
        throw new NotImplementedException();
    }

    public override string ToString()
    {
        return base.ToString() +
            $", {nameof(HitPoint)} = {HitPoint}, " +
            $"{nameof(Attack)} = {Attack}, " +
            $"{nameof(Defence)} = {Defence}}}";
    }
}
