using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZEventDispatcher{
    private Dictionary<System.Type, object> eventHandlers = new Dictionary<System.Type, object>();

    public void AddListener<T>(ZEventListener<T> listener) where T : ZEventBase<T>, new(){
        System.Type type = typeof(T);
        object obj;
        ZEventHandler<T> handler;
        if (eventHandlers.TryGetValue(type, out obj) == false) {
            handler = (ZEventHandler<T>)obj;            
        } else {
            handler = new ZEventHandler<T>();
            eventHandlers[type] = handler;
        }
        handler.AddListener(listener);
    }

    public void RemoveListener<T>(ZEventListener<T> listener) where T : ZEventBase<T>, new(){
        System.Type type = typeof(T);
        object obj;
        ZEventHandler<T> handler;
        if (eventHandlers.TryGetValue(type, out obj)) {
            handler = (ZEventHandler<T>)obj;
            handler.RemoveListener(listener);
        }
    }

    public void Dispatch<T>(T evt) where T : ZEventBase<T>, new(){
        System.Type type = typeof(T);
        object obj;
        ZEventHandler<T> handler;
        if (eventHandlers.TryGetValue(type, out obj)) {
            handler = (ZEventHandler<T>)obj;
            handler.SafeHandle(evt);
        }
    }
}
public class ZPropertyEventDispatcher{

    private Dictionary<System.Type, object> eventHandlers = new Dictionary<System.Type, object>();

    public void AddProperty<T>(System.Func<T> propertyGetter) where T : ZEventBase<T>, new(){

    }

    public void RemoveProperty<T>(System.Func<T> propertyGetter) where T : ZEventBase<T>, new(){

    }
    
    public void AddPropertyListener<T>(ZEventListener<T> listener) where T : ZEventBase<T>, new(){
        System.Type type = typeof(T);
        object obj;
        ZPropertyEventHandler<T> handler;
        if (eventHandlers.TryGetValue(type, out obj) == false) {
            handler = (ZPropertyEventHandler<T>)obj;
            handler.AddListener(listener);          
        }
    }

    public void RemovePropertyListener<T>(ZEventListener<T> listener) where T : ZEventBase<T>, new(){
        System.Type type = typeof(T);
        object obj;
        ZPropertyEventHandler<T> handler;
        if (eventHandlers.TryGetValue(type, out obj)) {
            handler = (ZPropertyEventHandler<T>)obj;
            handler.RemoveListener(listener);
        }
    }

    public void Dispatch<T>() where T : ZEventBase<T>, new(){
        System.Type type = typeof(T);
        object obj;
        ZPropertyEventHandler<T> handler;
        if (eventHandlers.TryGetValue(type, out obj)) {
            handler = (ZPropertyEventHandler<T>)obj;
            handler.OnPropertyEvent();
        }
    }
}