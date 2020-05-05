using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManage : MonoBehaviour
{
    public AudioMixer audioMixer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetMasterVolume(float volume)    // 控制主音量的函数
    {
        audioMixer.SetFloat("Master", volume);
        // MasterVolume为我们暴露出来的Master的参数
    }
    public void SetMusicVolume(float volume)    // 控制背景音乐音量的函数
    {
        audioMixer.SetFloat("Music", volume);
        // MusicVolume为我们暴露出来的Music的参数
    }

    public void SetSoundEffectVolume(float volume)    // 控制音效音量的函数
    {
        audioMixer.SetFloat("Effect", volume);
        // SoundEffectVolume为我们暴露出来的SoundEffect的参数
    }
}
