using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    private GameObject StartButton;
    private GameObject OptionButton;
    private GameObject ExitButton;
    private GameObject Voice;
    private GameObject VoiceSlider;
    private GameObject BackButton;
    // Start is called before the first frame update
    void Start()
    {
        StartButton = GameObject.Find("StartButton");
        OptionButton = GameObject.Find("OptionButton");
        ExitButton = GameObject.Find("ExitButton");
        Voice = GameObject.Find("Voice");
        VoiceSlider = GameObject.Find("VoiceSlider");
        BackButton = GameObject.Find("BackButton");

        StartButton.SetActive(true);
        OptionButton.SetActive(true);
        ExitButton.SetActive(true);
        Voice.SetActive(false);
        VoiceSlider.SetActive(false);
        BackButton.SetActive(false);

	}

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.F10) )
        {
            Debug.Log("Hello!");
            PlayerPrefs.SetInt("level2", 1);
            PlayerPrefs.SetInt("level3", 1);
            PlayerPrefs.SetInt("level4", 1);
            PlayerPrefs.SetInt("level5", 1);
            PlayerPrefs.SetInt("level6", 1);
            PlayerPrefs.SetInt("level7", 1);
            PlayerPrefs.SetInt("level8", 1);
            PlayerPrefs.SetInt("cheat", 1);
        }
    }

    public void Click(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Option()
    {
        StartButton.SetActive(false);
        OptionButton.SetActive(false);
        ExitButton.SetActive(false);
        Voice.SetActive(true);
        VoiceSlider.SetActive(true);
        BackButton.SetActive(true);
    }
    public void Back()
    {
        StartButton.SetActive(true);
        OptionButton.SetActive(true);
        ExitButton.SetActive(true);
        Voice.SetActive(false);
        VoiceSlider.SetActive(false);
        BackButton.SetActive(false);
    }
}
