using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZNotification {
    public int id;
    public int afterSeconds;
    public string title;
    public string content;

    public ZNotification Create(int id, int afterSeconds, string title, string content) {
        ZNotification noti = new ZNotification();
        noti.id = id;
        noti.afterSeconds = afterSeconds;
        noti.title = title;
        noti.content = content;
        return noti;
    }
}

public class ZNotificationLogicBase : ZLogicBase {

    private bool notificationEnabled = false;

    public override void RegisterEvents() {
        base.RegisterEvents();

        ZEventManager.ObserveProperty(OnNotification, () => {
            return ZSettingNotificationEvent.Create(ZGameSetting.Instance.NotificationEnabled);
        });

        ZEventManager.Instance.Listen<ZAppLaunchEvent>(OnAppLaunch);
        ZEventManager.Instance.Listen<ZAppPauseEvent>(OnAppPause);
        ZEventManager.Instance.Listen<ZAppResumeEvent>(OnAppResume);
    }

    private void OnNotification(ZSettingNotificationEvent evt) {
        notificationEnabled = evt.enabled;
    }

    private void OnAppLaunch(ZAppLaunchEvent evt) {
        CancelNotifications();
    }

    private void OnAppPause(ZAppPauseEvent evt) {
        if (ZGameSetting.Instance.NotificationEnabled) {
            ScheduleNotifications();
        }
    }

    private void OnAppResume(ZAppResumeEvent evt) {
        CancelNotifications();
    }

    protected virtual List<ZNotification> GenNotifications() {
        return null;
    }

    // 设置所有推送
    protected void ScheduleNotifications() {
        List<ZNotification> notifications = GenNotifications();
        if (notifications != null) {
            for (int i = 0; i < notifications.Count; i++) {
                ScheduleNotification(notifications[i]);
            }
        }
    }

    protected void ScheduleNotification(ZNotification noti) {
        // TODO
    }

    // 取消所有推送
    protected void CancelNotifications() {
        // TODO
    }

}
