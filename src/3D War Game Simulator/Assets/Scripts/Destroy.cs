using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    private AudioSource _audioSources;
    public AudioClip[] audioClip;
    private float time=20.0f;
    public bool flag = false, once = true;
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
        _audioSources.minDistance = 1;      //设置最小开始衰减距离
        _audioSources.maxDistance = 100;    //设置最大能听到音量距离
        //设置音量衰减类型为线性衰减
        _audioSources.rolloffMode = AudioRolloffMode.Linear;
    }

    // Update is called once per frame
    void Update()
    {
        if (flag&&Time.timeScale>0)
        {
            if (once)
            {
                _audioSources.Play();
                once = false;
            }
            if (time > 0) time -= Time.timeScale;
            else
            {
                Destroy(gameObject);
            }
        }
    }
}
