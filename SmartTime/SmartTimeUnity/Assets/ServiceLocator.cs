using System;
using System.Collections.Generic;

public static class ServiceLocator
{
    private static readonly Dictionary<Type, object>
        Services = new Dictionary<Type, object>();
 
    public static void Register<T>(T service)
    {
        Services[typeof(T)] = service;
    }
 
    public static T Resolve<T>()
    {
        return (T)Services[typeof(T)];
    }
 
    public static void Reset()
    {
        Services.Clear();
    }
}