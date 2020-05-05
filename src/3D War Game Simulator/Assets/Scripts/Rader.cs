using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rader : MonoBehaviour
{
    public GameObject target;
    public float Gravity = 5,time = 3.0f, timecount;
    private float v;
    public bool flag,once=true;
    private Vector3 TargetPosition,LookatPosition;

    private Vector3 currentAngle;
    // Use this for initialization
    void Start()
    {
        //通过一个公式计算出初速度向量
        //角度*力度
        timecount = 0;
        v = (Gravity * time) /2;
    }
    // Update is called once per frame
    void Update()
    {
       
        timecount += Time.deltaTime;
        if (flag)
        {
            //计算物体的重力速度
            //v = at ;
            if (once)
            {
                TargetPosition = target.transform.position - transform.position+new Vector3(Random.Range(0,0.5f),0,Random.Range(0,0.5f));
                LookatPosition = TargetPosition + transform.position;
                once = false;
            }
            
            //位移模拟轨迹
            transform.position += TargetPosition * Time.deltaTime / time ;
            if(timecount<time/2) transform.position += 3*Vector3.up * Time.deltaTime ;
            else transform.position -= 3*Vector3.up * Time.deltaTime / time;
            transform.LookAt(LookatPosition);

            if (this.transform.position.y < 0) Destroy(this.gameObject);
        }

    }
}