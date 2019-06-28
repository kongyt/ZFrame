using ZFrame;

// 游戏启动
public class AppLaunchEvent : SimpleEvent<AppLaunchEvent> {


}

// 游戏暂停
public class AppPauseEvent : SimpleEvent<AppPauseEvent> {

}

// 游戏恢复
public class AppResumeEvent : SimpleEvent<AppResumeEvent> {


}

// 游戏退出
public class AppExitEvent : SimpleEvent<AppExitEvent> {

}


// 音乐设置
public class SettingMusicEvent : BoolEvent<SettingMusicEvent> {

}

// 音效设置
public class SettingSoundEvent : BoolEvent<SettingSoundEvent> {

}

// 推送设置
public class SettingNotificationEvent : BoolEvent<SettingNotificationEvent> {

}