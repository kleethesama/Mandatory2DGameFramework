using Mandatory2DGameFramework.Model.Inventory;
using Mandatory2DGameFramework.Worlds;

namespace Mandatory2DGameFramework.Model.Defence;

public class DefenceItem : Loot
{
    public int ReduceHitPoint { get; set; }

    public DefenceItem(int reduceHitPoint, int id, string name) : base(id, name)
    {
        ReduceHitPoint = reduceHitPoint;
    }

    public DefenceItem(int reduceHitPoint, WorldObject worldObject, int id, string name) : base(worldObject, id, name)
    {
        ReduceHitPoint = reduceHitPoint;
    }

    public override string ToString()
    {
        return $"{{{nameof(Name)} = {Name}, {nameof(ReduceHitPoint)} = {ReduceHitPoint}}}";
    }
}
