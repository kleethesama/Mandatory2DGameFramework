using Mandatory2DGameFramework.Model.Attack;
using Mandatory2DGameFramework.Model.CreatureBehavior;
using Mandatory2DGameFramework.Model.Defence;
using Mandatory2DGameFramework.Worlds;

namespace Mandatory2DGameFramework.Model.Creatures;

public class Bird(string name, WorldPosition position, IBehavior behavior) : Creature(name, position, behavior)
{
    public override int HitPoint { get; set; } = 10;
    public override int MoveRange { get; set; } = 5;
    public override List<AttackItem> AttackItems { get; set; } = [];
    public override List<DefenceItem> DefenceItems { get; set; } = [];
}
