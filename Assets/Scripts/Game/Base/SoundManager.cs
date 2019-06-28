using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZFrame;

public class SoundManager : SingletonComp<SoundManager> {

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

        EventManager.Instance.ObserveProperty<SettingMusicEvent>(OnMusic);

        EventManager.Instance.ObserveProperty<SettingSoundEvent>(OnSound);
    }

    private void OnMusic(SettingMusicEvent evt) {
        musicEnabled = evt.value;
        if (musicEnabled) {
            PlayBGM(BGM);
        } else {
            StopBGM();
        }
    }

    private void OnSound(SettingSoundEvent evt) {
        soundEnabled = evt.value;
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
