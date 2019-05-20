// 通用消息在此定义

// 游戏启动
public class ZAppLaunchEvent : ZEventBase<ZAppLaunchEvent> {


}

// 游戏暂停
public class ZAppPauseEvent : ZEventBase<ZAppPauseEvent> {

}

// 游戏恢复
public class ZAppResumeEvent : ZEventBase<ZAppResumeEvent> {


}

// 游戏退出
public class ZAppExitEvent : ZEventBase<ZAppExitEvent> {

}

// 音乐设置
public class ZSettingMusicEvent : ZEventBase<ZSettingMusicEvent> {

    public bool enabled;

    public static ZSettingMusicEvent Create(bool value){
        return new ZSettingMusicEvent(){enabled = value};
    }

}

// 音效设置
public class ZSettingSoundEvent : ZEventBase<ZSettingSoundEvent> {

    public bool enabled;

    public static ZSettingSoundEvent Create(bool value){
        return new ZSettingSoundEvent(){enabled = value};
    }
}

// 推送设置
public class ZSettingNotificationEvent : ZEventBase<ZSettingNotificationEvent> {

    public bool enabled;

    public static ZSettingNotificationEvent Create(bool value){
        return new ZSettingNotificationEvent(){enabled = value};
    }
}