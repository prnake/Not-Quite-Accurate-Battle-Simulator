using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowBattle : MonoBehaviour
{
    private float dTime;
    public float CD = 3.0f;
    private GameObject[] EnemyArray;
    private GameObject Nearest;
    private Transform target;
    public float findDistance = 100.0f;
    public float chaseDistance = 5.0f;
    public float attackDistance = 2.0f;
    public string TargetTag = "";

    private float MDistance;

    public GameObject Arrow;

    void Start()
    {
        dTime = CD;
        findDistance = 10000.0f;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        dTime += Time.fixedDeltaTime;

        if (dTime > CD)
        {
            dTime = 0;
            Creat();
        }
        else if(dTime>0.1)
        {
            this.GetComponentInChildren<Animator>().SetBool("isAttack", false);
        }
    }
    void Creat()
    {

        EnemyArray = GameObject.FindGameObjectsWithTag(TargetTag);
        Nearest = null;
        MDistance = findDistance;
        float CDistance;
        for (int i = 0; i < EnemyArray.Length; i++)
        {
            CDistance = Vector3.Distance(this.transform.position, EnemyArray[i].transform.position);
            if (CDistance < MDistance)
            {
                MDistance = CDistance;
                Nearest = EnemyArray[i];
            }
        }
        if (Nearest != null)
        {
            target = Nearest.transform;
            this.transform.LookAt(target);
            GameObject obj = Instantiate(Arrow,(transform.position+Vector3.up),Quaternion.identity);
            if (TargetTag == "Player") obj.tag = "EnermyArrow";
            else if (TargetTag == "Enermy") obj.tag = "PlayerArrow";
            obj.transform.LookAt(target);
            obj.GetComponent<Rader>().target = Nearest;
            this.GetComponentInChildren<Animator>().SetBool("isAttack", true);
            obj.GetComponent<Rader>().flag = true;
        }
    }
}