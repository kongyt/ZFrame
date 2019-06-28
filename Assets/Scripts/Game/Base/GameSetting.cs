using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZFrame;


public class GameSetting : Singleton<GameSetting> {

    private bool musicEnabled = true;
    private bool soundEnabled = true;
    private bool notificationEnabled = true;

    public void Load() {
        MusicEnabled = LocalStorage.GetBool("MusicEnabled", musicEnabled);
        SoundEnabled = LocalStorage.GetBool("SoundEnabled", soundEnabled);
        NotificationEnabled = LocalStorage.GetBool("NotificationEnabled", notificationEnabled);

        EventManager.Instance.DefineProperty<SettingMusicEvent>(()=>{return SettingMusicEvent.Create(musicEnabled);});
        EventManager.Instance.DefineProperty<SettingSoundEvent>(()=>{return SettingSoundEvent.Create(soundEnabled);});
        EventManager.Instance.DefineProperty<SettingNotificationEvent>(()=>{return SettingNotificationEvent.Create(notificationEnabled);});
    }

    public bool MusicEnabled {
        get {
            return musicEnabled;
        }

        set {
            if (musicEnabled != value) {
                musicEnabled = value;
                LocalStorage.SetBool("MusicEnabled", musicEnabled);
                EventManager.Instance.NotifyPropertyChanged<SettingMusicEvent>();
            }
        }
    }

    public bool SoundEnabled {
        get {
            return soundEnabled;
        }

        set {
            if (soundEnabled != value) {
                soundEnabled = value;
                LocalStorage.SetBool("SoundEnabled", soundEnabled);
                EventManager.Instance.NotifyPropertyChanged<SettingSoundEvent>();
            }
        }
    }

    public bool NotificationEnabled {
        get {
            return notificationEnabled;
        }

        set {
            if (notificationEnabled != value) {
                notificationEnabled = value;
                LocalStorage.SetBool("NotificationEnabled", notificationEnabled);
                EventManager.Instance.NotifyPropertyChanged<SettingNotificationEvent>();
            }            
        }
    }
}
