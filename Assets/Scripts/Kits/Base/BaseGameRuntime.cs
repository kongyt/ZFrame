using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace ZFrame {
    public class BaseGameRuntime : SingletonComp<BaseGameRuntime> {

        private List<BaseLogic> allLogic = new List<BaseLogic>();

        void Awake() {
            PreloadData();
            // 初始所有Logic
            InitAllLogic();
            RegisterAllEvents();
            OnGameStart();
        }

        void Start() {
            StartAllLogic();
        }

        void Update() {
            UpdateAllLogic(Time.deltaTime);
        }

        protected virtual void PreloadData(){

        }

        protected virtual void InitAllLogic() {
        
        }

        protected virtual void OnGameStart(){
            
        }

        protected T AddLogic<T>() where T : BaseLogic {
            T logic = gameObject.AddComponent<T>();
            allLogic.Add(logic);
            return logic;
        }

        protected void RegisterAllEvents() {
            for (int i = 0; i < allLogic.Count; i++) {
                allLogic[i].RegisterEvents();
            }
        }

        protected void StartAllLogic() {
            for (int i = 0; i < allLogic.Count; i++) {
                allLogic[i].StartLogic();
            }
        }

        protected void UpdateAllLogic(float delta) {
            for (int i = 0; i < allLogic.Count; i++) {
                allLogic[i].UpdateLogic(delta);
            }
        }
    }

}

