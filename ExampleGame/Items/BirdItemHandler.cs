using Mandatory2DGameFramework.Model.Items;
using Mandatory2DGameFramework.Model.Items.Attack;
using Mandatory2DGameFramework.Model.Items.Defence;

namespace ExampleGame.Items;

internal class BirdItemHandler : IItemHandler // Implemented strategy pattern
{
    public int MaxItems { get; } = 1;

    public void AddAttackItem(AttackItem attackItem, List<AttackItem> attackItems)
    {
        //if (!IsAllowedAttackItem(attackItem)) { return; }
        if (attackItems.Count < MaxItems)
        {
            attackItems.Add(attackItem);
        }
    }

    public bool IsAllowedAttackItem(AttackItem attackItem)
    {
        throw new NotImplementedException();
    }

    public bool IsAllowedDefenceItem(DefenceItem defenceItem)
    {
        throw new NotImplementedException();
    }

    public void AddDefenceItem(DefenceItem defenceItem, List<DefenceItem> defenceItems)
    {
        //if (!IsAllowedDefenceItem(defenceItem)) { return; }
        if (defenceItems.Count < MaxItems)
        {
            defenceItems.Add(defenceItem);
        }
    }

    public void GetAttackItem(string name, List<AttackItem> attackItems)
    {
        throw new NotImplementedException();
    }

    public void GetAttackItem(int id, List<AttackItem> attackItems)
    {
        throw new NotImplementedException();
    }

    public void GetDefenceItem(string name, List<DefenceItem> defenceItems)
    {
        throw new NotImplementedException();
    }

    public void GetDefenceItem(int id, List<DefenceItem> defenceItems)
    {
        throw new NotImplementedException();
    }

    public void RemoveAttackItem(string name, List<AttackItem> attackItems)
    {
        throw new NotImplementedException();
    }

    public void RemoveAttackItem(int id, List<AttackItem> attackItems)
    {
        throw new NotImplementedException();
    }

    public void RemoveDefenceItem(string name, List<DefenceItem> defenceItems)
    {
        throw new NotImplementedException();
    }

    public void RemoveDefenceItem(int id, List<DefenceItem> defenceItems)
    {
        throw new NotImplementedException();
    }
}
