using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZSoundManager : ZSingletonComp<ZSoundManager> {

    private static string BGM = "bgm";
    private static string BGM_PREFIX = "Sound/";
    private static string AUDIO_PREFIX = "Sound/";

    public AudioSource bgmSource;
    public AudioSource effectSource;

    private bool musicEnabled = true;
    private bool soundEnabled = true;

    void Awake() {
        bgmSource = gameObject.AddComponent<AudioSource>();
        effectSource = gameObject.AddComponent<AudioSource>();

        ZEventManager.ObserveProperty<ZSettingMusicEvent>(OnMusic, () => {
            return ZSettingMusicEvent.Create(ZGameSetting.Instance.MusicEnabled);
        });

        ZEventManager.ObserveProperty<ZSettingSoundEvent>(OnSound, () => {
            return ZSettingSoundEvent.Create(ZGameSetting.Instance.SoundEnabled);
        });
    }

    private void OnMusic(ZSettingMusicEvent evt) {
        musicEnabled = evt.enabled;
        if (musicEnabled) {
            PlayBGM(BGM);
        } else {
            StopBGM();
        }
    }

    private void OnSound(ZSettingSoundEvent evt) {
        soundEnabled = evt.enabled;
        if (soundEnabled == false) {
            StopAllSound();
        }
    }

    public void PlayBGM(string name) {
        AudioClip clip = Resources.Load<AudioClip>(BGM_PREFIX + name);
        if (musicEnabled && bgmSource != null && clip != null) {
            bgmSource.Stop();
            bgmSource.clip = clip;
            bgmSource.Play();
        }               
    }


    public void StopBGM() {
        if (bgmSource != null) {
            bgmSource.Stop();
        }
    }

    public void PlaySound(string name) {
        AudioClip clip = Resources.Load<AudioClip>(AUDIO_PREFIX + name);
        if (soundEnabled && effectSource != null && clip != null) {
            effectSource.PlayOneShot(clip);
        }
    }

    public void StopAllSound() {
        if (effectSource != null) {
            effectSource.Stop();
        }
    }

}
