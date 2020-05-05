using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ScenceChange : MonoBehaviour
{
    public GameObject unset2;
    public GameObject unset3;
    public GameObject unset4;
    public GameObject unset5;
    public GameObject unset6;
    public GameObject unset7;
    public GameObject unset8;
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("level2") == false) PlayerPrefs.SetInt("level2", 0);
        if (PlayerPrefs.HasKey("level3") == false) PlayerPrefs.SetInt("level3", 0);
        if (PlayerPrefs.HasKey("level4") == false) PlayerPrefs.SetInt("level4", 0);
        if (PlayerPrefs.HasKey("level5") == false) PlayerPrefs.SetInt("level5", 0);
        if (PlayerPrefs.HasKey("level6") == false) PlayerPrefs.SetInt("level6", 0);
        if (PlayerPrefs.HasKey("level7") == false) PlayerPrefs.SetInt("level7", 0);
        if (PlayerPrefs.HasKey("level8") == false) PlayerPrefs.SetInt("level8", 0);
        if (PlayerPrefs.GetInt("level2") == 1) Destroy(unset2);
        if (PlayerPrefs.GetInt("level3") == 1) Destroy(unset3);
        if (PlayerPrefs.GetInt("level4") == 1) Destroy(unset4);
        if (PlayerPrefs.GetInt("level5") == 1) Destroy(unset5);
        if (PlayerPrefs.GetInt("level6") == 1) Destroy(unset6);
        if (PlayerPrefs.GetInt("level7") == 1) Destroy(unset7);
        if (PlayerPrefs.GetInt("level8") == 1) Destroy(unset8);
    }

    // Update is called once per frame
    void Update()
    {
    }
    public void Click(string sceneName)
    {
		if (PlayerPrefs.HasKey(sceneName.ToLower()) && PlayerPrefs.GetInt(sceneName.ToLower()) == 0) ;
		else SceneManager.LoadScene(sceneName);

    }
    public void unlock(string level)
    {
        PlayerPrefs.SetInt(level, 1);
    }
}
