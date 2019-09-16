using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

// 音量設定クラス
public class AudioSetting : MonoBehaviour {
    public AudioMixer audioMixer;

    // BGM音量設定
    public void SetBGM(float bgmVolume)
    {
        SetVolume("BGMVolume", bgmVolume);
    }

    // 足音音量設定
    public void SetFootstep(float fsVolume)
    {
        SetVolume("FootstepVolume", fsVolume);
    }

    // 波の音音量設定
    public void SetWaveSound(float wsVolume)
    {
        SetVolume("WaveSoundVolume", wsVolume);
    }

    // 鳥の鳴き声の音量設定
    public void SetBird(float birdVolume)
    {
        SetVolume("BirdVolume", birdVolume);
    }

    // 受け取ったラベルに紐づくオブジェクトの音量を設定する
    private void SetVolume(string exp, float db) {
        audioMixer.SetFloat(exp, db);
    }
}
