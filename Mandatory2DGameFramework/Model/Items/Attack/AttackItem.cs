using Mandatory2DGameFramework.Model.Inventory;
using Mandatory2DGameFramework.Worlds;

namespace Mandatory2DGameFramework.Model.Items.Attack;

public class AttackItem : Loot
{
    public int HitDamage { get; set; }
    public int Range { get; set; }

    public AttackItem(int hitDamage, int range, int id, string name) : base(id, name)
    {
        HitDamage = hitDamage;
        Range = range;
    }

    public AttackItem(int hitDamage, int range, WorldObject worldObject, int id, string name) : base(worldObject, id, name)
    {
        HitDamage = hitDamage;
        Range = range;
    }

    public override string ToString()
    {
        return $"{{{nameof(Name)}={Name}, {nameof(HitDamage)}={HitDamage}, {nameof(Range)}={Range}}}";
    }
}
