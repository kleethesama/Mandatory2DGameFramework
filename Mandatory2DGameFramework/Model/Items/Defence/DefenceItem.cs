using Mandatory2DGameFramework.Model.Inventory;
using Mandatory2DGameFramework.Model.Items.Defence.Component;

namespace Mandatory2DGameFramework.Model.Items.Defence;

public class DefenceItem : Loot
{
    public int ReduceHitPoint { get; set; }

    public DefenceItem(int reduceHitPoint, int id, string name) : base(id, name)
    {
        ReduceHitPoint = reduceHitPoint;
    }

    public void ApplyBuff(BuffComponent component, int defencePoints)
    {
        component.ApplyBuff(this, defencePoints);
    }

    public override string ToString()
    {
        return $"{{{nameof(Name)} = {Name}, {nameof(ReduceHitPoint)} = {ReduceHitPoint}}}";
    }
}
