using Mandatory2DGameFramework.Model.CreatureBehavior;
using Mandatory2DGameFramework.Worlds;

namespace Mandatory2DGameFramework.Model.Creatures;

public abstract class AiCreature(string name, WorldPosition position, World world) : Creature(name, position, world)
{
    public virtual void DoBehavior(IBehavior Behavior)
    {
        throw new NotImplementedException();
        Behavior.PlayerReaction(this);
        Behavior.NpcReaction(this);
    }
}
