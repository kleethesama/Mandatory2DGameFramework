using Mandatory2DGameFramework.Model.Attack;
using Mandatory2DGameFramework.Model.Defence;
using Mandatory2DGameFramework.Worlds;

namespace Mandatory2DGameFramework.Model.Creatures;

public class Bird(string name, WorldPosition position) : AiCreature(name, position)
{
    public override int HitPoint { get; set; } = 10;
    public override int MoveRange { get; set; } = 5;
    public override int DetectRange { get; set; } = 3;
    public override List<AttackItem> AttackItems { get; set; } = [];
    public override List<DefenceItem> DefenceItems { get; set; } = [];
}
