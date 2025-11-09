namespace Mandatory2DGameFramework.Config;

public abstract class ConfigReaderWorker<T>
{
    public abstract T DefaultValue { get; protected set; }

    public abstract void StartReadConfigFile();

    public virtual T GetValue()
    {
        return DefaultValue;
    }
}
