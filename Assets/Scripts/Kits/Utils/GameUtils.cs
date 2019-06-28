using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZFrame {
    public static class GameUtils {		
        public static T GetOrAddComponent<T>(this GameObject gameObject) where T : Component {
            T comp = gameObject.GetComponent<T>();
            if (comp == null) {
                comp = gameObject.AddComponent<T>();
            }
            return comp;
        }

        public static Component GetOrAddComponent(this GameObject gameObject, System.Type compType){
            Component comp = gameObject.GetComponent(compType);
            if (comp == null) {
                comp = gameObject.AddComponent(compType);
            }
            return comp;
        }

        public static string GetGameObjectPath(GameObject obj) {
            string path = "/" + obj.name;
            while (obj.transform.parent != null) {
                obj = obj.transform.parent.gameObject;
                path = "/" + obj.name + path;
            }
            return path;
        }
    }
}


