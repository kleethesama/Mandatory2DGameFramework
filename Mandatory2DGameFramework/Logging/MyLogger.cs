namespace Mandatory2DGameFramework.Logging;

public sealed class MyLogger
{
    private static readonly Lazy<MyLogger> _instance = new(() => new MyLogger());

    public static MyLogger Instance { get => _instance.Value; }

    private MyLogger() { }
}
