using Mandatory2DGameFramework.Model.CreatureBehavior;
using Mandatory2DGameFramework.Worlds;

namespace Mandatory2DGameFramework.Model.Creatures;

public abstract class AiCreature(string name, WorldPosition position, World world) : Creature(name, position, world)
{
    public abstract AiBehaviorState BehaviorState { protected get; set; }

    public virtual void AiRoutine()
    {
        if (TryScanDetectRange(out Creature? creature))
        {
            if (creature == null || creature.IsDead()) { return; }
            if (creature.IsPlayer)
            {
                BehaviorState.PlayerReaction(creature);
            }
            else
            {
                BehaviorState.NpcReaction(creature);
            }
        }
    }

    // This can probably be optimized by keeping the positions stored in
    // in an array as relative positions to the bird.
    public bool TryScanDetectRange(out Creature? detectedCreature)
    {
        for (int i = 1; i < DetectRange; i++)
        {
            for (int j = 1; j < DetectRange; j++)
            {
                WorldPosition detectPosition1 = Position + new WorldPosition(i, j);
                WorldPosition detectPosition2 = Position + new WorldPosition(j, i);
                throw new NotImplementedException();
                //World.TryIsPositionOccupied(detectPosition1, detectPosition2);
            }
        }
        detectedCreature = null;
        return false;
    }
}
