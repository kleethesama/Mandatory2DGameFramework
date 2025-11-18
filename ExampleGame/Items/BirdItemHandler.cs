using Mandatory2DGameFramework.Model.Items;
using Mandatory2DGameFramework.Model.Items.Attack;
using Mandatory2DGameFramework.Model.Items.Defence;

namespace ExampleGame.Items;

internal class BirdItemHandler : ItemHandler // Implemented strategy pattern
{
    public override int MaxItems { get; } = 1;

    public override void AddAttackItem(AttackItem attackItem, List<AttackItem> attackItems)
    {
        base.AddAttackItem(attackItem, attackItems);
        // Add more logic
    }

    public override bool IsAllowedAttackItem(AttackItem attackItem)
    {
        throw new NotImplementedException();
    }

    public override bool IsAllowedDefenceItem(DefenceItem defenceItem)
    {
        throw new NotImplementedException();
    }

    public override void AddDefenceItem(DefenceItem defenceItem, List<DefenceItem> defenceItems)
    {
        base.AddDefenceItem(defenceItem, defenceItems);
        // Add more logic
    }

    public override void GetAttackItem(string name, List<AttackItem> attackItems)
    {
        throw new NotImplementedException();
    }

    public override void GetAttackItem(int id, List<AttackItem> attackItems)
    {
        throw new NotImplementedException();
    }

    public override void GetDefenceItem(string name, List<DefenceItem> defenceItems)
    {
        throw new NotImplementedException();
    }

    public override void GetDefenceItem(int id, List<DefenceItem> defenceItems)
    {
        throw new NotImplementedException();
    }

    public override void RemoveAttackItem(string name, List<AttackItem> attackItems)
    {
        throw new NotImplementedException();
    }

    public override void RemoveAttackItem(int id, List<AttackItem> attackItems)
    {
        throw new NotImplementedException();
    }

    public override void RemoveDefenceItem(string name, List<DefenceItem> defenceItems)
    {
        throw new NotImplementedException();
    }

    public override void RemoveDefenceItem(int id, List<DefenceItem> defenceItems)
    {
        throw new NotImplementedException();
    }
}
