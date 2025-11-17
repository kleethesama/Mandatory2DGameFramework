using System.Diagnostics;
using System.Reflection;

namespace Mandatory2DGameFramework.Logging;

public sealed class MyLogger
{
    private static readonly Lazy<MyLogger> _instance = new(() => new MyLogger());
    private readonly List<TraceSource> _traceSources = [];

    public static MyLogger Instance { get => _instance.Value; }

    private MyLogger()
    {
        AddDefaultTraceSources();
    }

    private void AddDefaultTraceSources()
    {
        foreach (Type type in Assembly.GetExecutingAssembly().GetTypes())
        {
            TraceSource traceSource = new(type.Name, SourceLevels.All)
            {
                Switch = new SourceSwitch("SourceSwitch", SourceLevels.All.ToString())
            };
            AddTraceSource(traceSource);
        }
    }

    public void AddGlobalListener(TraceListener listener)
    {
        foreach (TraceSource traceSource in _traceSources)
        {
            traceSource.Listeners.Add(listener);
        }
    }

    public void RemoveGlobalListener(TraceListener listener)
    {
        foreach (TraceSource traceSource in _traceSources)
        {
            RemoveListener(traceSource, listener);
        }
    }

    public void RemoveGlobalListener(string name)
    {
        foreach (TraceSource traceSource in _traceSources)
        {
            RemoveListener(traceSource, GetListener(traceSource, name));
        }
    }

    public TraceSource GetTraceSource(TraceSource traceSource)
    {
        TraceSource source = _traceSources.FirstOrDefault(e => e == traceSource)
            ?? throw new ArgumentException("Object does not exist in the list.", nameof(traceSource));
        return source;
    }

    public TraceSource GetTraceSource(string name)
    {
        TraceSource source = _traceSources.FirstOrDefault(e => e.Name == name)
            ?? throw new ArgumentException($"Object with name {name} does not exist in the list.", nameof(name));
        return source;
    }

    public void AddTraceSource(TraceSource traceSource)
    {
        if (traceSource.Name == null)
        {
            throw new ArgumentException("TraceSource must have a name.", nameof(traceSource));
        }
        _traceSources.Add(traceSource);
    }

    public bool RemoveTraceSource(TraceSource traceSource)
    {
        return _traceSources.Remove(traceSource);
    }

    public bool RemoveTraceSource(string name)
    {
        TraceSource? source = _traceSources.FirstOrDefault(e => e.Name == name);
        if (source == null) { return false; }
        return _traceSources.Remove(source);
    }

    public TraceListenerCollection GetAllListeners(TraceSource traceSource)
    {
        return GetTraceSource(traceSource).Listeners;
    }

    public TraceListener GetListener(TraceSource traceSource, string name)
    {
        TraceListener? listener = GetTraceSource(traceSource).Listeners[name]
            ?? throw new ArgumentException($"There are no listenser with the name: {name}", nameof(name));
        return listener;
    }

    public void AddListener(TraceSource traceSource, TraceListener listener)
    {
        if (listener.Name == null)
        {
            throw new ArgumentException("Listener must have a name.", nameof(listener));
        }
        GetTraceSource(traceSource).Listeners.Add(listener);
    }
    public void AddListener(string traceSourceName, TraceListener listener)
    {
        if (listener.Name == null)
        {
            throw new ArgumentException("Listener must have a name.", nameof(listener));
        }
        GetTraceSource(traceSourceName).Listeners.Add(listener);
    }

    public void RemoveListener(TraceSource traceSource, TraceListener listener)
    {
        GetTraceSource(traceSource).Listeners.Remove(listener);
        listener.Flush();
        listener.Close();
    }

    public void RemoveListener(TraceSource traceSource, string name)
    {
        TraceListener listener = GetListener(traceSource, name);
        Trace.Listeners.Remove(listener);
        listener.Flush();
        listener.Close();
    }
}
