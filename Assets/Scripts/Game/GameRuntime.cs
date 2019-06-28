using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using ZFrame;

public class GameRuntime : BaseGameRuntime {

    // 加载数据
    protected override void PreloadData(){

        // 初始化UI信息
        UIDefine.Init();

        // 读取游戏设置
        GameSetting.Instance.Load();
    }

    // 初始化逻辑
    protected override void InitAllLogic() {
        AddLogic<NotificationLogic>();
    }

    // 游戏启动完成
    protected override void OnGameStart(){
        LaunchApp();
    }

    public void LaunchApp() {
        // 发送游戏启动消息
        SendEvent(AppLaunchEvent.Create());
    }
    public void PauseApp() {
        // 发送游戏暂停消息
        SendEvent(AppPauseEvent.Create());
    }
    public void ResumeApp() {
        // 发送游戏恢复消息
        SendEvent(AppResumeEvent.Create());
    }
    public void ExitApp() {
        // 发送游戏退出消息
        SendEvent(AppExitEvent.Create());
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    void OnApplicationPause(bool pause) {
        if (pause) {
            PauseApp();
        } else {
            ResumeApp();
        }
    }
}
