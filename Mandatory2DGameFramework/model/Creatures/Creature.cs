using Mandatory2DGameFramework.Model.Attack;
using Mandatory2DGameFramework.Model.Defence;
using Mandatory2DGameFramework.Worlds;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mandatory2DGameFramework.Model.Creatures;

public class Creature : WorldEntityBase
{
    public int HitPoint { get; set; }


    // Todo consider how many attack / defence weapons are allowed
    public AttackItem? Attack { get; set; }
    public DefenceItem? Defence { get; set; }

    public Creature()
    {
        Name = string.Empty;
        HitPoint = 100;

        Attack = null;
        Defence = null;
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
        return $"{{{nameof(Name)}={Name}, {nameof(HitPoint)}={HitPoint}, {nameof(Attack)}={Attack}, {nameof(Defence)}={Defence}}}";
    }
}
