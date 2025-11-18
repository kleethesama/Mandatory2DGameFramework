using ExampleGame.Items;
using Mandatory2DGameFramework.Model.CreatureBehavior;
using Mandatory2DGameFramework.Model.Creatures;
using Mandatory2DGameFramework.Model.Items;
using Mandatory2DGameFramework.Model.Items.Attack;
using Mandatory2DGameFramework.Model.Items.Defence;
using Mandatory2DGameFramework.Worlds;

namespace ExampleGame.AI;

internal class Bird : AiCreature
{
    public override AiBehaviorState BehaviorState { protected get; set; }
    public override bool IsPlayer => false;
    public override int MaxHitPoint { get; protected set; } = 10;
    public override int HitPoint { get; protected set; } = 10;
    public override int MoveRange { get; set; } = 5;
    public override int DetectRange { get; set; } = 3;
    public override List<AttackItem> AttackItems { get; set; } = [];
    public override List<DefenceItem> DefenceItems { get; set; } = [];
    public override ItemHandler ItemHandler { protected get; set; } = new BirdItemHandler();

    public Bird(string name, WorldPosition position, World world) : base(name, position, world)
    {
        BehaviorState = new IdleBirdBehavior(this);
    }

    public Bird(string name, WorldPosition position, World world, int maxHitPoint, int hitPoint, int moveRange, int detectRange, List<AttackItem> attackItems, List<DefenceItem> defenceItems, ItemHandler itemHandler) : this(name, position, world)
    {
        MaxHitPoint = maxHitPoint;
        HitPoint = hitPoint;
        MoveRange = moveRange;
        DetectRange = detectRange;
        AttackItems = attackItems;
        DefenceItems = defenceItems;
        ItemHandler = itemHandler;
    }
}
