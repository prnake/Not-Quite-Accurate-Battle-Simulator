using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    private AudioSource _audioSources;
    public AudioClip[] audioClip;
    // Start is called before the first frame update
    void Start()
    {
        _audioSources = GetComponent<AudioSource>();
        _audioSources.clip = audioClip[Random.Range(0, audioClip.Length - 1)];
        _audioSources.playOnAwake = false;   //运行开始立即播放
        _audioSources.loop = false;          //设置循环播放
        _audioSources.priority = 128;       //设置优先权
        _audioSources.volume = 1;           //设置音量大小为 1
        _audioSources.pitch = 1;            //设置音高为 1
        _audioSources.spatialBlend = 0;     //设置音效为 2D 音效
        _audioSources.Play();
    }

    // Update is called once per frame
    void Update()
    {
    }
}
