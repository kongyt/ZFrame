using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 普通单例基类
public class ZSingleton<T> where T : ZSingleton<T>, new() {

    private static T instance;

    public static T Instance {
        get {
            if (instance == null) {
                instance = new T();
            }
            return instance;
        }
    }

    protected ZSingleton() {
        if (instance != null) {
            Debug.LogError(typeof(T).ToString() + " instance already created, check your code.");
        } else {
            instance = (T)this;
        }
    }

    protected virtual void OnDestroy() {

    }

    public static void Destroy() {
        if (instance != null) {
            instance.OnDestroy();
            instance = null;
        }
    }
}
