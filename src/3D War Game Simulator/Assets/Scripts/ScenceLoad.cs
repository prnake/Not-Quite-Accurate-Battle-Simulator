using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenceLoad : MonoBehaviour
{
    private AudioSource _audioSources;
    public GameObject stop;
    public GameObject Battle;
    public GameObject Win;
    public GameObject Lose;
    private GameObject[] EnemyArray;
    private GameObject[] PlayerArray;
    private GameObject Camera;
    public string unlock = "level1";
    private float time ,timescale;
    private bool flag, isBattle, once =true;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0;
        PlayerPrefs.SetInt(unlock, 1);
        Camera  = GameObject.Find("CameraControl");
        _audioSources = GetComponent<AudioSource>();
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
        if (flag == true)
        {
            if (time>0) time -= 1;
            else
            {
                Battle.SetActive(false);
                Time.timeScale = 1;
                flag = false;
                isBattle = true;
            }
        }
        if(isBattle == true)
        {
            EnemyArray = GameObject.FindGameObjectsWithTag("Enermy");
            PlayerArray = GameObject.FindGameObjectsWithTag("Player");
            if (EnemyArray.Length == 0)
            {
                Win.SetActive(true);
                if (once)
                {
                    _audioSources.clip = Resources.Load<AudioClip>("Win");
                    _audioSources.Play();
                    once = false;
                }
                Time.timeScale = 0;
            }
            else if (PlayerArray.Length == 0)
            {
                Lose.SetActive(true);
                if (once)
                {
                    _audioSources.clip = Resources.Load<AudioClip>("Lose");
                    _audioSources.Play();
                    once = false;
                }
                Time.timeScale = 0;
            }
        }
        if (Input.GetKey(KeyCode.Escape))
        {
            if (stop.activeSelf == false) LoadStop();
        }
    }
    public void Click(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
    public void LoadStop()
    {
        timescale = Time.timeScale;
        Time.timeScale = 0;
        stop.SetActive(true);
    }

    public void ReloadStop()
    {
        Time.timeScale = timescale;
        stop.SetActive(false);
    }
    public void Play()
    {
        Destroy(Camera.GetComponent<MousePlace>());
        Destroy(GameObject.Find("Canvas/ScrollRectPanel"));
        Destroy(GameObject.Find("Canvas/Go"));
        Battle.SetActive(true);
        flag = true;
        time = 24.0f;
    }
}
