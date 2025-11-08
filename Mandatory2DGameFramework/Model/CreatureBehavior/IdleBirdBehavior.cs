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

    public bool TryScanDetectRange(out Creature? detectedCreature)
    {
        for (int i = 1; i < _aiCreature.DetectRange; i++)
        {
            for (int j = 1; j < _aiCreature.DetectRange; j++)
            {
                WorldPosition detectPosition1 = _aiCreature.Position + new WorldPosition(i, j);
                WorldPosition detectPosition2 = _aiCreature.Position + new WorldPosition(j, i);
                // Check if a creature is in tile.
                throw new NotImplementedException();
            }
        }
        detectedCreature = null;
        return false;
    }
}
