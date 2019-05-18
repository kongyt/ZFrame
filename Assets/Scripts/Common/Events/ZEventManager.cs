using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZEventManager : ZSingleton<ZEventManager> {

    private ZEventDispatcher dispatcher = new ZEventDispatcher();

    public void SendEvent(ZEventBase evt){
        dispatcher.Dispatch(evt);
    }

    public void Listen<T>(ZEventListener<T> listener, System.Func<T> propertyGetter = null) {
        if (listener != null) {
            if (propertyGetter != null) {
                listener(propertyGetter());
            }
            dispatcher.AddListener(listener);
        }        
    }

    public void UnListen<T>(ZEventListener<T> listener) {
        if (listener != null) {
            dispatcher.RemoveListener(listener);
        }        
    }

    public static void ObserveProperty<T>(ZEventListener<T> listener, System.Func<T> propertyGetter) {
        Instance.Listen<T>(listener, propertyGetter);
    }
}
