using Mandatory2DGameFramework.Model.Creatures;
using Mandatory2DGameFramework.Worlds;

namespace Mandatory2DGameFramework.Model.CreatureBehavior;

public abstract class AiBehaviorState(AiCreature aiCreature)
{
    protected AiCreature _aiCreature = aiCreature;

    public abstract string Description { get; }

    public abstract void ExecuteBehavior();

    public override string ToString()
    {
        return Description;
    }
}
