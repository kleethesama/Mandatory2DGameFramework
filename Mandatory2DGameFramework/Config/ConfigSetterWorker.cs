namespace Mandatory2DGameFramework.Config;

public abstract class ConfigSetterWorker<T>
{
    public abstract T Get();
    public abstract void Set(T value);
}
