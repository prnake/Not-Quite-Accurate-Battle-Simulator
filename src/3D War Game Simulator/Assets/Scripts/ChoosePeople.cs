using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoosePeople : MonoBehaviour
{
    private GameObject Control;
    private float time;
    public GameObject[] choice;
    public GameObject[] preferb;
    // Start is called before the first frame update
    void Start()
    {
        Control = GameObject.Find("CameraControl");
    }

    // Update is called once per frame
    void Update()
    {
        if (time > 0) time -= 1.0f;
        else
        {
            for(int i = 0; i < preferb.Length; i++)
            {
                preferb[i].GetComponent<Animator>().SetBool("isAttack", false);
            }
        }
    }
    public void RandomChoose()
    {
        Choose(Random.Range(1, 8));
    }
    public void Choose(int n)
    {
        switch (n)
        {
            case 1:
                Control.GetComponent<MousePlace>().target = choice[0];
                Control.GetComponent<MousePlace>().money = -100;
                preferb[0].GetComponent<Animator>().SetBool("isAttack", true);
                time = 0.1f;
                break;
            case 2:
                Control.GetComponent<MousePlace>().target = choice[1];
                Control.GetComponent<MousePlace>().money = -400;
                preferb[1].GetComponent<Animator>().SetBool("isAttack", true);
                time = 0.1f;
                break;
            case 3:
                Control.GetComponent<MousePlace>().target = choice[2];
                Control.GetComponent<MousePlace>().money = -20;
                preferb[2].GetComponent<Animator>().SetBool("isAttack", true);
                time = 0.1f;
                break;
            case 4:
                Control.GetComponent<MousePlace>().target = choice[3];
                Control.GetComponent<MousePlace>().money = -200;
                preferb[3].GetComponent<Animator>().SetBool("isAttack", true);
                time = 0.1f;
                break;
            case 5:
                Control.GetComponent<MousePlace>().target = choice[4];
                Control.GetComponent<MousePlace>().money = -500;
                preferb[4].GetComponent<Animator>().SetBool("isAttack", true);
                time = 0.1f;
                break;
            case 6:
                Control.GetComponent<MousePlace>().target = choice[5];
                Control.GetComponent<MousePlace>().money = -500;
                preferb[5].GetComponent<Animator>().SetBool("isAttack", true);
                time = 0.1f;
                break;
            case 7:
                Control.GetComponent<MousePlace>().target = choice[6];
                Control.GetComponent<MousePlace>().money = -500;
                preferb[6].GetComponent<Animator>().SetBool("isAttack", true);
                time = 0.1f;
                break;
        }
    }
}
