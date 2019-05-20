using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZEventManager : ZSingleton<ZEventManager> {

    private ZEventDispatcher eventDispathcher = new ZEventDispatcher();
    private ZPropertyEventDispatcher propertyEventDispatcher = new ZPropertyEventDispatcher();

    public void SendEvent<T>(T evt) where T : ZEventBase<T>, new(){
        eventDispathcher.Dispatch(evt);
    }

    public void Listen<T>(ZEventListener<T> listener) where T : ZEventBase<T>, new(){
        if (listener != null) {
            eventDispathcher.AddListener(listener);
        }        
    }

    public void UnListen<T>(ZEventListener<T> listener) where T : ZEventBase<T>, new(){
        if (listener != null) {
            eventDispathcher.RemoveListener(listener);
        }        
    }

    public void ObserveProperty<T>(ZEventListener<T> listener) where T : ZEventBase<T>, new(){
        if(listener != null){
            propertyEventDispatcher.AddPropertyListener(listener);
        }        
    }

    public void UnObserveProperty<T>(ZEventListener<T> listener) where T : ZEventBase<T>, new(){
        if(listener != null){
            propertyEventDispatcher.RemovePropertyListener(listener);
        }  
    }

    public void DefineProperty<T>(System.Func<T> getter) where T : ZEventBase<T>, new(){
        if(getter != null){
            propertyEventDispatcher.AddProperty(getter);
        }
    }

    public void UnDefineProperty<T>(System.Func<T> getter) where T : ZEventBase<T>, new(){
        if(getter != null){
            propertyEventDispatcher.RemoveProperty(getter);
        }
    }

    public void NotifyProperty<T>() where T : ZEventBase<T>, new(){
        propertyEventDispatcher.Dispatch<T>();
    }
}
