using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void ZEventListener(ZEventBase evt);

public class ZEventDispatcher {

    private Dictionary<System.Type, ZEventListener> eventHandlers = new Dictionary<System.Type, ZEventListener>();

    public void AddListener(System.Type type, ZEventListener listener) {
        ZEventListener listeners;
        if (eventHandlers.TryGetValue(type, out listeners)) {
            listeners += listener;
        } else {
            eventHandlers[type] = listener;
        }
    }

    public void RemoveListener(System.Type type, ZEventListener listener) {
        ZEventListener listeners;
        if (eventHandlers.TryGetValue(type, out listeners)) {
            listeners -= listener;
        } else {
            eventHandlers.Remove(type);
        }
    }

    public void Dispatch(ZEventBase evt) {
        System.Type type = evt.GetType();
        ZEventListener listeners;
        if (eventHandlers.TryGetValue(type, out listeners)) {
            listeners(evt);
        }
    }
}