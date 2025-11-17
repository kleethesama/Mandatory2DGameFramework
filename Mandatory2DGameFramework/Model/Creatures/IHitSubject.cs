namespace Mandatory2DGameFramework.Model.Creatures;

public interface IHitSubject
{
    public void Attach(IHitObserver observer);
    public bool Detach(IHitObserver observer);
    public void NotfiyHit(string message);
}
