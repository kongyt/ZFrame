using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 单例基类，继承自MonoBehaviour
public class ZSingletonComp<T> : ZComponentBase where T:ZSingletonComp<T>{

    private static T instance;

    public static T Instance {
        get {
            if (instance == null) {
                GameObject go = new GameObject();
                go.name = typeof(T).ToString();
                instance = go.AddComponent<T>();                
            }
            return instance;
        }
    }

    protected ZSingletonComp() : base() {
        if (instance != null) {
            Debug.LogError(typeof(T).ToString() + " instance already created, check your code.");
        } else {
            instance = (T)this;
        }
    }

    protected virtual void OnDestroy() {
        if (instance == this) {
            instance = null;
        }
    }

}
