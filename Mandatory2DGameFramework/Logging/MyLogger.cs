using System.Diagnostics;

namespace Mandatory2DGameFramework.Logging;

public sealed class MyLogger
{
    private static readonly Lazy<MyLogger> _instance = new(() => new MyLogger());
    private TraceSource _traceSource;

    public static MyLogger Instance { get => _instance.Value; }
    public TraceSource TraceSource
    {
        get
        {
            if (_traceSource != null) { return _traceSource; }
            _traceSource = new TraceSource("FrameworkLog", SourceLevels.All)
            {
                Switch = new SourceSwitch("Log", SourceLevels.All.ToString())
            };
            return _traceSource;
        }
        private set { _traceSource = value; }
    }

    private MyLogger() { }

    public void AddListener(TraceListener listener, EventTypeFilter? optionalFilter = null)
    {
        if (optionalFilter != null)
        {
            listener.Filter = optionalFilter;
        }
        TraceSource.Listeners.Add(listener);
    }

    public void RemoveListener(TraceListener listener)
    {
        TraceSource.Listeners.Remove(listener);
    }
}
