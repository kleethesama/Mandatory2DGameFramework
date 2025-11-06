using Mandatory2DGameFramework.Worlds;

namespace Mandatory2DGameFramework.Model.Defence;

public class DefenceItem : WorldObject
{
    public int ReduceHitPoint { get; set; }

    public DefenceItem() : base()
    {
        ReduceHitPoint = 0;
    }

    public override string ToString()
    {
        return $"{{{nameof(Name)} = {Name}, {nameof(ReduceHitPoint)} = {ReduceHitPoint}}}";
    }
}
