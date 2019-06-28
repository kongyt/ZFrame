using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZFrame {
    // 普通单例基类
    public class Singleton<T> where T : Singleton<T>, new() {

        private static T instance;

        public static T Instance {
            get {
                if (instance == null) {
                    instance = new T();
                }
                return instance;
            }
        }

        protected Singleton() {
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
}
