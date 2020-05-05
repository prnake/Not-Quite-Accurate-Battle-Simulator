using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour
{
    public GameObject Player;  //声明需要跟随的玩家
    private Vector3 offset;   //差值
    private Transform playerTransform;  //声明玩家的Transform组件 
    private Transform cameraTransform;  //声明相机的Transform组件 
    public float distance = 0;
    public float scrollSpeed = 10;


    // Use this for initialization
    void Start()
    {
        playerTransform = Player.GetComponent<Transform>(); //得到玩家的Transform组件
        cameraTransform = this.GetComponent<Transform>();   //得到相机的Transform组件
        offset = cameraTransform.position - playerTransform.position;  //得到相机和玩家位置的差值
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = playerTransform.position + offset;  //玩家的位置加上差值赋值给相机的位置
        ScrollView();
    }
    void ScrollView()
    {
        //print (Input.GetAxis ("Mouse ScrollWheel"));
        distance = offset.magnitude;
        distance -= Input.GetAxis("Mouse ScrollWheel") * scrollSpeed;  //往前滑动是正值
        if (distance > 26)
        {   //如果距离大于26，就返回26
            distance = 26;
        }
        if (distance < 5)
        {    //如果距离小于5，就返回5
            distance = 5;
        }
        offset = offset.normalized * distance;


    }
}
