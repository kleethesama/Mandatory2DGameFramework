using Mandatory2DGameFramework.Model.Creatures;

namespace Mandatory2DGameFramework.Model.CreatureBehavior;

public abstract class AiBehaviorState(AiCreature aiCreature)
{
    protected AiCreature _aiCreature = aiCreature;

    public abstract string Description { get; }

    public abstract void PlayerReaction(Creature creature);
    public abstract void NpcReaction(Creature creature);

    public override string ToString()
    {
        return Description;
    }
}
