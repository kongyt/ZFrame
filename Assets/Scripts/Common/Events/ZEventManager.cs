using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZEventManager : ZSingleton<ZEventManager> {

    private ZEventDispatcher dispatcher = new ZEventDispatcher();

    public void SendEvent<T>(T evt) {
        dispatcher.Dispatch(evt);
    }

    public void Listen<T>(ZEventListener<T> listener) {
        dispatcher.AddListener(listener);
    }

    public void UnListen<T>(ZEventListener<T> listener) {
        dispatcher.RemoveListener(listener);
    }
}
