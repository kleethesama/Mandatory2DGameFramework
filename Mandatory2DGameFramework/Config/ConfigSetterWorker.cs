namespace Mandatory2DGameFramework.Config;

public abstract class ConfigSetterWorker<T>(ConfigReaderWorker<T> reader)
{
    public ConfigReaderWorker<T> Reader { get; protected set; } = reader;

    public abstract void Set(ref T reference, T value);
}
