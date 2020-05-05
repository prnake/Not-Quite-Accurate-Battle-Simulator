using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MousePlace : MonoBehaviour
{
    public GameObject target;
    private GameObject MoneyControl;
    public int money;
    private string Type = "Player", TargetType = "Enermy";
    // Start is called before the first frame update
    void Start()
    {
        MoneyControl = GameObject.Find("MoneyController");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)&&!EventSystem.current.IsPointerOverGameObject())
        {
            RaycastHit hitInfo;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (target!=null&&Physics.Raycast(ray, out hitInfo, 50))
            {
                if (hitInfo.collider.gameObject.tag == "Terrain")
                {
                    bool flag = MoneyControl.GetComponent<MoneyControl>().MoneyChange(money);
                    if (flag)
                    {
                        //GameObject obj = GameObject.CreatePrimitive(PrimitiveType.Cube);
                        //obj.transform.position = hitInfo.point;
                        GameObject obj = Instantiate(target, hitInfo.point, Quaternion.identity);
                        obj.tag = Type;
                        if(target.name == "LittleArcher")
                        {
                            obj.GetComponent<ArrowBattle>().TargetTag = TargetType;
                        }
                        else if(target.name == "MageRed" || target.name == "MageBlue" || target.name == "MageGreen")
                        {
                            obj.GetComponent<MagicBattle>().TargetTag = TargetType;
                        }
                        else
                        {
                            obj.GetComponent<AIBattle>().TargetTag = TargetType;
                        }
                        

                    }
                    
                    
                }
            }
        }
        if(PlayerPrefs.GetInt("cheat")==1)
        {
            if (Input.GetKey(KeyCode.U))
            {
                Type = "Player";
                TargetType = "Enermy";
            }
            else if (Input.GetKey(KeyCode.I))
            {
                Type = "Enermy";
                TargetType = "Player";
            }
        }
        
    }
}