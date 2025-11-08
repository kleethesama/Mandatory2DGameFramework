using Mandatory2DGameFramework.Model.CreatureBehavior;
using Mandatory2DGameFramework.Worlds;

namespace Mandatory2DGameFramework.Model.Creatures;

public abstract class AiCreature(string name, WorldPosition position, World world) : Creature(name, position, world)
{
    public abstract IBehavior Behavior { get; set; }

    public virtual void ExecuteBehavior()
    {
        throw new NotImplementedException();
        Behavior.PlayerReaction(this);
        Behavior.NpcReaction(this);
    }
}
