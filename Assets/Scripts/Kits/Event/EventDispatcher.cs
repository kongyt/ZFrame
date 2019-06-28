using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZFrame {
    public class EventDispatcher{
        private Dictionary<System.Type, object> eventHandlers = new Dictionary<System.Type, object>();

        public void AddListener<T>(EventListener<T> listener) where T : BaseEvent, new(){
            if(listener == null) return;
            System.Type type = typeof(T);
            object obj;
            EventHandler<T> handler;
            if (eventHandlers.TryGetValue(type, out obj)) {
                handler = (EventHandler<T>)obj;            
            } else {
                handler = new EventHandler<T>();
                eventHandlers[type] = handler;
            }
            handler.AddListener(listener);
        }

        public void RemoveListener<T>(EventListener<T> listener) where T : BaseEvent, new(){
            if(listener == null) return;
            System.Type type = typeof(T);
            object obj;
            EventHandler<T> handler;
            if (eventHandlers.TryGetValue(type, out obj)) {
                handler = (EventHandler<T>)obj;
                handler.RemoveListener(listener);
            }
        }

        public void Dispatch<T>(T evt) where T : BaseEvent, new(){
            System.Type type = typeof(T);
            object obj;
            EventHandler<T> handler;
            if (eventHandlers.TryGetValue(type, out obj)) {
                handler = (EventHandler<T>)obj;
                handler.SafeHandle(evt);
            }
        }
    }
    public class PropertyEventDispatcher{

        private Dictionary<System.Type, object> eventHandlers = new Dictionary<System.Type, object>();

        public void AddProperty<T>(System.Func<T> propertyGetter) where T : BaseEvent, new(){
            if(propertyGetter == null) return;
            System.Type type = typeof(T);
            if (!eventHandlers.ContainsKey(type)) {
                PropertyEventHandler<T> handler = new PropertyEventHandler<T>(propertyGetter);
                eventHandlers.Add(type, handler);       
            }
        }

        public void RemoveProperty<T>(System.Func<T> propertyGetter) where T : BaseEvent, new(){
            if(propertyGetter == null) return;
            System.Type type = typeof(T);
            if (eventHandlers.ContainsKey(type)) {
                eventHandlers.Remove(type);       
            }
        }
        
        public void AddPropertyListener<T>(EventListener<T> listener) where T : BaseEvent, new(){
            if(listener == null) return;
            System.Type type = typeof(T);
            object obj;
            PropertyEventHandler<T> handler;
            if (eventHandlers.TryGetValue(type, out obj)) {
                handler = (PropertyEventHandler<T>)obj;
                handler.AddListener(listener);             
                listener(handler.getter());
            }
        }

        public void RemovePropertyListener<T>(EventListener<T> listener) where T : BaseEvent, new(){
            if(listener == null) return;
            System.Type type = typeof(T);
            object obj;
            PropertyEventHandler<T> handler;
            if (eventHandlers.TryGetValue(type, out obj)) {
                handler = (PropertyEventHandler<T>)obj;
                handler.RemoveListener(listener);
            }
        }

        public void Dispatch<T>() where T : BaseEvent, new(){
            System.Type type = typeof(T);
            object obj;
            PropertyEventHandler<T> handler;
            if (eventHandlers.TryGetValue(type, out obj)) {
                handler = (PropertyEventHandler<T>)obj;
                handler.OnPropertyEvent();
            }
        }
    }
}
