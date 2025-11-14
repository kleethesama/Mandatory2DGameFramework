using Mandatory2DGameFramework.Model.CreatureBehavior;
using Mandatory2DGameFramework.Model.Creatures;

namespace ExampleGame.AI;

public class IdleBirdBehavior(AiCreature aiCreature) : AiBehaviorState(aiCreature)
{
    public override string Description => "Behavior for when a bird is idle.";

    public override void NpcReaction(Creature creature)
    {
        Idle();
    }

    public override void PlayerReaction(Creature creature)
    {
        Flee();
    }

    private void Idle()
    {
        throw new NotImplementedException();
    }

    private void Flee()
    {
        throw new NotImplementedException();
    }
}
