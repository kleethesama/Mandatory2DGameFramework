namespace Mandatory2DGameFramework.Model.Creatures;

public interface IHitObserver
{
    public void Update(IHitSubject subject);
}
