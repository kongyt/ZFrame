// 通用消息在此定义

// 游戏启动
public class ZAppLaunchEvent : ZEventBase {

    public static ZAppLaunchEvent Create() {
        return new ZAppLaunchEvent();
    }

}

// 游戏暂停
public class ZAppPauseEvent : ZEventBase {

    public static ZAppPauseEvent Create() {
        return new ZAppPauseEvent();
    }

}

// 游戏恢复
public class ZAppResumeEvent : ZEventBase {

    public static ZAppResumeEvent Create() {
        return new ZAppResumeEvent();
    }

}

// 游戏退出
public class ZAppExitEvent : ZEventBase {

    public static ZAppExitEvent Create() {
        return new ZAppExitEvent();
    }

}

// 音乐设置
public class ZSettingMusicEvent : ZEventBase {

    public bool enabled;

    public static ZSettingMusicEvent Create(bool value) {
        return new ZSettingMusicEvent() { enabled = value };
    }
}

// 音效设置
public class ZSettingSoundEvent : ZEventBase {

    public bool enabled;

    public static ZSettingSoundEvent Create(bool value) {
        return new ZSettingSoundEvent() { enabled = value };
    }

}

// 推送设置
public class ZSettingNotificationEvent : ZEventBase {

    public bool enabled;

    public static ZSettingNotificationEvent Create(bool value) {
        return new ZSettingNotificationEvent() { enabled = value };
    }

}