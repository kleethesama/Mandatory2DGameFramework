using Mandatory2DGameFramework.Model.Creatures;

namespace Mandatory2DGameFramework.Model.CreatureBehavior;

public class IdleBirdBehavior(AiCreature aiCreature) : AiBehaviorState(aiCreature)
{
    public override string Description => "";

    public override void ExecuteBehavior()
    {
        throw new NotImplementedException();
    }

    public void NpcReaction(Creature creature)
    {
        throw new NotImplementedException();
    }

    public void PlayerReaction(Creature creature)
    {
        throw new NotImplementedException();
    }
}
