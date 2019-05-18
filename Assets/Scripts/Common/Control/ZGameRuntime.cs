using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class ZGameRuntime : ZSingletonComp<ZGameRuntime> {

    private List<ZLogicBase> allLogic = new List<ZLogicBase>();

    void Awake() {
        // 初始所有Logic
        InitAllLogic();

        LaunchApp();
    }

    void Start() {
        StartAllLogic();
    }

    void Update() {
        UpdateAllLogic(Time.deltaTime);
    }

    void OnApplicationPause(bool pause) {
        if (pause) {
            PauseApp();
        } else {
            ResumeApp();
        }
    }

    protected virtual void InitAllLogic() {
       
    }

    protected T AddLogic<T>() where T : ZLogicBase {
        T logic = gameObject.AddComponent<T>();
        allLogic.Add(logic);
        return logic;
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

    public void LaunchApp() {
        // 发送游戏启动消息
        SendEvent<ZAppLaunchEvent>(ZAppLaunchEvent.Create());
    }

    public void PauseApp() {
        // 发送游戏暂停消息
        SendEvent<ZAppPauseEvent>(ZAppPauseEvent.Create());
    }

    public void ResumeApp() {
        // 发送游戏恢复消息
        SendEvent<ZAppResumeEvent>(ZAppResumeEvent.Create());
    }

    public void ExitApp() {
        // 发送游戏退出消息
        SendEvent<ZAppExitEvent>(ZAppExitEvent.Create());

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
