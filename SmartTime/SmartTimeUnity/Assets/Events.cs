using System;
using System.Collections.Generic;

public class Events
{
    private Dictionary<Type, List<Delegate>> _handlers = new Dictionary<Type, List<Delegate>>();

    public void Register<T>(Action<T> eventHandler)
        where T : IEvent
    {
        if(!_handlers.ContainsKey(typeof(T)))
            _handlers.Add(typeof(T), new List<Delegate>());
        _handlers[typeof(T)].Add(eventHandler);
    }

    public void Raise<T>(T domainEvent)
        where T : IEvent
    {
        foreach (var handler in _handlers[domainEvent.GetType()])
        {
            var action = (Action<T>)handler;
            action(domainEvent);
        }
    }
}