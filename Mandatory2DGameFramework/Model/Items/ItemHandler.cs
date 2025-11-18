using Mandatory2DGameFramework.Model.Items.Attack;
using Mandatory2DGameFramework.Model.Items.Defence;

namespace Mandatory2DGameFramework.Model.Items;

public abstract class ItemHandler
{
    public abstract int MaxItems { get; }

    public abstract bool IsAllowedAttackItem(AttackItem attackItem);
    public abstract bool IsAllowedDefenceItem(DefenceItem defenceItem);
    public virtual void GetAttackItem(string name, List<AttackItem> attackItems)
    {
        throw new NotImplementedException();
    }
    public virtual void GetDefenceItem(string name, List<DefenceItem> defenceItems)
    {
        throw new NotImplementedException();
    }
    public virtual void GetAttackItem(int id, List<AttackItem> attackItems)
    {
        throw new NotImplementedException();
    }
    public virtual void GetDefenceItem(int id, List<DefenceItem> defenceItems)
    {
        throw new NotImplementedException();
    }
    public virtual void AddAttackItem(AttackItem attackItem, List<AttackItem> attackItems)
    {
        if (!IsAllowedAttackItem(attackItem))
        {
            throw new Exception("Attack item not allowed.");
        }
        if (attackItems.Count < MaxItems)
        {
            attackItems.Add(attackItem);
        }
        throw new NotImplementedException();
    }
    public virtual void AddDefenceItem(DefenceItem defenceItem, List<DefenceItem> defenceItems)
    {
        if (!IsAllowedDefenceItem(defenceItem))
        {
            throw new Exception("Defence item not allowed.");
        }
        if (defenceItems.Count < MaxItems)
        {
            defenceItems.Add(defenceItem);
        }
    }
    public virtual void RemoveAttackItem(string name, List<AttackItem> attackItems)
    {
        throw new NotImplementedException();
    }
    public virtual void RemoveDefenceItem(string name, List<DefenceItem> defenceItems)
    {
        throw new NotImplementedException();
    }
    public virtual void RemoveAttackItem(int id, List<AttackItem> attackItems)
    {
        throw new NotImplementedException();
    }
    public virtual void RemoveDefenceItem(int id, List<DefenceItem> defenceItems)
    {
        throw new NotImplementedException();
    }
}
