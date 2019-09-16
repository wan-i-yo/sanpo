using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioSetting : MonoBehaviour {
    public AudioMixer audioMixer;
 
    public void SetBGM(float bgmVolume)
    {
        SetVolume("BGMVolume", bgmVolume);
    }

    public void SetFootstep(float fsVolume)
    {
        SetVolume("FootstepVolume", fsVolume);
    }

    public void SetWaveSound(float wsVolume)
    {
        SetVolume("WaveSoundVolume", wsVolume);
    }

    public void SetBird(float birdVolume)
    {
        SetVolume("BirdVolume", birdVolume);
    }

    private void SetVolume(string exp, float db) {
        audioMixer.SetFloat(exp, db);
        /*        if (db == 4.0f)
                {
                    audioMixer.SetFloat(exp, 0);
                }
                else if (db == 3.0f)
                {
                    audioMixer.SetFloat(exp, -5.0f);
                }
                else if (db == 2.0f)
                {
                    audioMixer.SetFloat(exp, -10.0f);
                }
                else if (db == 1.0f)
                {
                    audioMixer.SetFloat(exp, -15.0f);
                }
                else if (db == 0.0f)
                {
                    audioMixer.SetFloat(exp, -80.0f);
                }
                else {
                    Debug.Log("設定失敗");
                }
                */
    }
}
