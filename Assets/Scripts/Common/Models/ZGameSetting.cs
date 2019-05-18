using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZGameSetting : ZSingleton<ZGameSetting> {

    private bool musicEnabled = true;
    private bool soundEnabled = true;
    private bool notificationEnabled = true;

    public void Load() {
        MusicEnabled = ZPlayerPrefs.GetBool("ZMusicEnabled", musicEnabled);
        SoundEnabled = ZPlayerPrefs.GetBool("ZSoundEnabled", soundEnabled);
        NotificationEnabled = ZPlayerPrefs.GetBool("ZNotificationEnabled", notificationEnabled);
    }

    public bool MusicEnabled {
        get {
            return musicEnabled;
        }

        set {
            if (musicEnabled != value) {
                musicEnabled = value;
                ZPlayerPrefs.SetBool("ZMusicEnabled", musicEnabled);
                ZEventManager.Instance.SendEvent(ZSettingMusicEvent.Create(musicEnabled));
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
                ZPlayerPrefs.SetBool("ZSoundEnabled", soundEnabled);
                ZEventManager.Instance.SendEvent(ZSettingSoundEvent.Create(soundEnabled));
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
                ZPlayerPrefs.SetBool("ZNotificationEnabled", notificationEnabled);
                ZEventManager.Instance.SendEvent(ZSettingNotificationEvent.Create(notificationEnabled));
            }            
        }
    }
}
