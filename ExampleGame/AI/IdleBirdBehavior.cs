using Mandatory2DGameFramework.Model.CreatureBehavior;
using Mandatory2DGameFramework.Model.Creatures;

namespace ExampleGame.AI;

internal class IdleBirdBehavior(AiCreature aiCreature) : AiBehaviorState(aiCreature)
{
    public override string Description => "Behavior for when a bird is idle.";

    public override void NpcReaction(Creature creature)
    {
        if (_aiCreature.HitPoint <= _aiCreature.MaxHitPoint * 0.5)
        {
            Flee();
            return;
        }
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
