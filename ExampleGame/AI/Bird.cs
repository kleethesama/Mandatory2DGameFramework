using Mandatory2DGameFramework.Model.CreatureBehavior;
using Mandatory2DGameFramework.Model.Creatures;
using Mandatory2DGameFramework.Model.Items.Attack;
using Mandatory2DGameFramework.Model.Items.Defence;
using Mandatory2DGameFramework.Worlds;

namespace ExampleGame.AI;

public class Bird(AiBehaviorState behaviorState, string name, WorldPosition position, World world) : AiCreature(name, position, world)
{
    public override AiBehaviorState BehaviorState { protected get; set; } = behaviorState;
    public override bool IsPlayer => false;
    public override int HitPoint { get; set; } = 10;
    public override int MoveRange { get; set; } = 5;
    public override int DetectRange { get; set; } = 3;
    public override List<AttackItem> AttackItems { get; set; } = [];
    public override List<DefenceItem> DefenceItems { get; set; } = [];
}
