using Mandatory2DGameFramework.Model.Creatures;

namespace Mandatory2DGameFramework.Model.CreatureBehavior;

public interface IBehavior
{
    public void PlayerReaction(Creature creature);
    public void NpcReaction(Creature creature);
}
