using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZFrame;

public class Notification {
    public int id;
    public int afterSeconds;
    public string title;
    public string content;

    public Notification Create(int id, int afterSeconds, string title, string content) {
        Notification noti = new Notification();
        noti.id = id;
        noti.afterSeconds = afterSeconds;
        noti.title = title;
        noti.content = content;
        return noti;
    }
}

public class NotificationLogic : BaseLogic {

    private bool notificationEnabled = false;

    public override void RegisterEvents() {
        base.RegisterEvents();

        EventManager.Instance.ObserveProperty<SettingNotificationEvent>(OnNotification);

        EventManager.Instance.Listen<AppLaunchEvent>(OnAppLaunch);
        EventManager.Instance.Listen<AppPauseEvent>(OnAppPause);
        EventManager.Instance.Listen<AppResumeEvent>(OnAppResume);
    }

    private void OnNotification(SettingNotificationEvent evt) {
        notificationEnabled = evt.value;
        Debug.Log("OnNotification:" + evt.value);
    }

    private void OnAppLaunch(AppLaunchEvent evt) {
        CancelNotifications();
    }

    private void OnAppPause(AppPauseEvent evt) {
        if (GameSetting.Instance.NotificationEnabled) {
            ScheduleNotifications();
        }
    }

    private void OnAppResume(AppResumeEvent evt) {
        CancelNotifications();
    }

    protected virtual List<Notification> GenNotifications() {
        return null;
    }

    // 设置所有推送
    protected void ScheduleNotifications() {
        List<Notification> notifications = GenNotifications();
        if (notifications != null) {
            for (int i = 0; i < notifications.Count; i++) {
                ScheduleNotification(notifications[i]);
            }
        }
    }

    protected void ScheduleNotification(Notification noti) {
        // TODO
    }

    // 取消所有推送
    protected void CancelNotifications() {
        // TODO
    }

}
