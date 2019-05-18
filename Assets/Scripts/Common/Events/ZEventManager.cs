using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZEventManager : ZSingleton<ZEventManager> {

    private ZEventDispatcher dispatcher = new ZEventDispatcher();

    public void SendEvent(ZEventBase evt) {
        dispatcher.Dispatch(evt);
    }

    public void Listen(System.Type type, ZEventListener listener) {
        dispatcher.AddListener(type, listener);
    }

    public void UnListen(System.Type type, ZEventListener listener) {
        dispatcher.RemoveListener(type, listener);
    }
}
