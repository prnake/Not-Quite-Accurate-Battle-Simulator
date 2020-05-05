using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cleanup : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("level2", 0);
        PlayerPrefs.SetInt("level3", 0);
        PlayerPrefs.SetInt("level4", 0);
        PlayerPrefs.SetInt("level5", 0);
        PlayerPrefs.SetInt("level6", 0);
        PlayerPrefs.SetInt("level7", 0);
        PlayerPrefs.SetInt("level8", 0);
        PlayerPrefs.SetInt("cheat", 0);
    }

    // Update is called once per frame
    void Update()
    {
    }
}
