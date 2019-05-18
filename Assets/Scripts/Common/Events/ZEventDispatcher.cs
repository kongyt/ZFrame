using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void ZEventListener<T>(T evt);

public class ZEventDispatcher {

    private Dictionary<System.Type, object> eventHandlers = new Dictionary<System.Type, object>();

    public void AddListener<T>(ZEventListener<T> listener) {
        System.Type type = typeof(T);
        object obj;
        ZEventListener<T> listeners;
        if (eventHandlers.TryGetValue(type, out obj)) {
            listeners = (ZEventListener<T>)obj;
            listeners += listener;
        } else {
            eventHandlers[type] = listener;
        }
    }

    public void RemoveListener<T>(ZEventListener<T> listener) {
        System.Type type = typeof(T);
        object obj;
        ZEventListener<T> listeners;
        if (eventHandlers.TryGetValue(type, out obj)) {
            listeners = (ZEventListener<T>)obj;
            listeners -= listener;
        } else {
            eventHandlers.Remove(type);
        }
    }

    public void Dispatch<T>(T evt) {
        System.Type type = typeof(T);
        object obj;
        ZEventListener<T> listeners;
        if (eventHandlers.TryGetValue(type, out obj)) {
            listeners = (ZEventListener<T>)obj;
            listeners(evt);
        }
    }
}