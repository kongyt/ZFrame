using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZFrame {
    public class EventManager : Singleton<EventManager> {

        private EventDispatcher eventDispathcher = new EventDispatcher();
        private PropertyEventDispatcher propertyEventDispatcher = new PropertyEventDispatcher();

        public void SendEvent<T>(T evt) where T : BaseEvent, new(){
            eventDispathcher.Dispatch(evt);
        }

        public void Listen<T>(EventListener<T> listener) where T : BaseEvent, new(){
            if (listener != null) {
                eventDispathcher.AddListener(listener);
            }        
        }

        public void UnListen<T>(EventListener<T> listener) where T : BaseEvent, new(){
            if (listener != null) {
                eventDispathcher.RemoveListener(listener);
            }        
        }

        public void ObserveProperty<T>(EventListener<T> listener) where T : BaseEvent, new(){
            if(listener != null){
                propertyEventDispatcher.AddPropertyListener(listener);
            }        
        }

        public void UnObserveProperty<T>(EventListener<T> listener) where T : BaseEvent, new(){
            if(listener != null){
                propertyEventDispatcher.RemovePropertyListener(listener);
            }  
        }

        public void DefineProperty<T>(System.Func<T> getter) where T : BaseEvent, new(){
            if(getter != null){
                propertyEventDispatcher.AddProperty(getter);
            }
        }

        public void UnDefineProperty<T>(System.Func<T> getter) where T : BaseEvent, new(){
            if(getter != null){
                propertyEventDispatcher.RemoveProperty(getter);
            }
        }

        public void NotifyPropertyChanged<T>() where T : BaseEvent, new(){
            propertyEventDispatcher.Dispatch<T>();
        }
    }

}

