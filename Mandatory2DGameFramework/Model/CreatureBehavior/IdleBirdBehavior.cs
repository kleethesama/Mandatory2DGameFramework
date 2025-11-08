using Mandatory2DGameFramework.Model.Creatures;
using Mandatory2DGameFramework.Worlds;

namespace Mandatory2DGameFramework.Model.CreatureBehavior;

public class IdleBirdBehavior(AiCreature aiCreature) : AiBehaviorState(aiCreature)
{
    public override string Description => "Behavior for when a bird is idle.";

    public override void ExecuteBehavior()
    {
        throw new NotImplementedException();
    }

    public void Idle(Creature creature)
    {
        throw new NotImplementedException();
    }

    // This can probably be optimized by keeping the positions stored in
    // in an array as relative positions to the bird.
    public bool TryScanDetectRange(out Creature? detectedCreature)
    {
        for (int i = 1; i < _aiCreature.DetectRange; i++)
        {
            for (int j = 1; j < _aiCreature.DetectRange; j++)
            {
                WorldPosition detectPosition1 = _aiCreature.Position + new WorldPosition(i, j);
                WorldPosition detectPosition2 = _aiCreature.Position + new WorldPosition(j, i);
                //aiCreature.World.TryIsPositionOccupied(detectPosition1, detectPosition2);
            }
        }
        detectedCreature = null;
        return false;
    }
}
