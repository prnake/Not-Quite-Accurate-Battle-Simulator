using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AttackKnife : MonoBehaviour
{
    private AudioSource _audioSources;
	public AudioClip[] audioClip;
	public float CD=0.1f;
    private float time;
    private HPBar HP;
    // Start is called before the first frame update
    void Start()
    {
        time = CD;
        _audioSources = GetComponent<AudioSource>();
        _audioSources.clip = audioClip[Random.Range(0, audioClip.Length-1)];
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


    private float currentSecond = 0; //记录当前播放到了第几秒

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;
        if (time < -1.0f) time = -1.0f;
    }
    void OnTriggerEnter(Collider other)
    {
        if ((this.transform.root.gameObject.tag=="Enermy" &&
            other.transform.root.gameObject.tag == "Player")||
            (this.transform.root.gameObject.tag == "Player"
            && other.transform.root.gameObject.tag == "Enermy"))
        {
            HP = other.transform.root.gameObject.GetComponentInChildren<HPBar>();
            _audioSources.time = 0;
            _audioSources.Play();
            if (time < 0)
            {
                HP.HealthPoint -= 2;
                time = CD;
            }
        }
    }
}