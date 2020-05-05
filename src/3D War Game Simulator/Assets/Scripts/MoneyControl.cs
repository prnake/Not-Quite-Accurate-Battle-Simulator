using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyControl : MonoBehaviour
{
    public int money = 1000;
    public GameObject MoneyText;
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("money", money);
        MoneyText.GetComponent<Text>().text = money.ToString();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public bool MoneyChange(int change)
    {
        money = PlayerPrefs.GetInt("money");
        money += change;
        if (money < 0)
        {
            return false;
        }
        else
        {
            PlayerPrefs.SetInt("money", money);
            MoneyText.GetComponent<Text>().text = money.ToString();
            return true;
        }
    }
    public void MoneyRandom(int n)
    {
        if (PlayerPrefs.GetInt("cheat") == 1)
        {
            money = PlayerPrefs.GetInt("money");
            money += Random.Range(0, n);
            PlayerPrefs.SetInt("money", money);
            MoneyText.GetComponent<Text>().text = money.ToString();
        }
    }
}
