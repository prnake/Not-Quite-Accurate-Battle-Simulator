using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float MoveSpeed = 10.0f;
    public float RotateSpeed = 100.0f;
    public float margin = 0.1f;
    public bool fly = false;
    private float h, v;

    private Transform tr;
    private Animator ani;
    Vector3 MoveDir;
    // Start is called before the first frame update
    void Start()
    {
        tr = GetComponent<Transform>();
        ani = GameObject.Find("Player/PlayerBody").GetComponent<Animator>();
    }

    bool IsGrounded()
    {
        return Physics.Raycast(tr.position, -Vector3.up, margin);
    }

    // Update is called once per frame
    void Update()
    {
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");

        if (Input.GetButton("Jump"))
        {
            tr.Translate(Vector3.up * MoveSpeed * Time.deltaTime, Space.Self);
            ani.SetBool("isJump", true);
        }
        else ani.SetBool("isJump", false);
        if(Input.GetKey(KeyCode.E))
        {
            ani.SetBool("isA", true);
        }
        else ani.SetBool("isA", false);
        if (h * h + v * v >= 1)
        {
            tr.Translate(Vector3.forward * v * MoveSpeed * Time.deltaTime, Space.Self);
            tr.Rotate(Vector3.up * h * RotateSpeed * Time.deltaTime);
            ani.SetBool("isRun", true);
            ani.SetBool("isWalk", false);
        }
        else if(h * h + v * v != 0)
        {
            tr.Translate(Vector3.forward * v * MoveSpeed * Time.deltaTime, Space.Self);
            tr.Rotate(Vector3.up * h * RotateSpeed * Time.deltaTime);
            ani.SetBool("isRun", false);
            ani.SetBool("isWalk", true);
        }
        else
        {
            ani.SetBool("isRun", false);
            ani.SetBool("isWalk", false);
        }
    }
}
