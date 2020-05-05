using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public float m_speed = 2f;
    public float r_speed = 20f;
    private float timeslice;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.GetInt("cheat") == 1) timeslice = 0.1f;
        else timeslice = Time.deltaTime;
        if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.RightShift))
        {
            m_speed = 10f;
            r_speed = 100f;
        }
        else if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
        {
            m_speed = 5f;
            r_speed = 50f;
        }
        else
        {
            m_speed = 2f;
            r_speed = 20f;
        }
        if (Input.GetKey(KeyCode.W)) //前
		{
			this.transform.Translate(Vector3.forward * m_speed * timeslice);
		}
		if (Input.GetKey(KeyCode.S)) //后
		{
			this.transform.Translate(Vector3.forward * -m_speed * timeslice);
		}
		if (Input.GetKey(KeyCode.A)) //左
		{
			this.transform.Translate(Vector3.right * -m_speed * timeslice);
		}
		if (Input.GetKey(KeyCode.D)) //右
		{
			this.transform.Translate(Vector3.right * m_speed * timeslice);
		}
        if (Input.GetKey(KeyCode.UpArrow)) //前
        {
            this.transform.Rotate(Vector3.left * r_speed * timeslice);
        }
        if (Input.GetKey(KeyCode.DownArrow)) //后
        {
            this.transform.Rotate(Vector3.right * r_speed * timeslice);
        }
        if (Input.GetKey(KeyCode.LeftArrow)) //左
        {
            this.transform.Rotate(Vector3.down * r_speed * timeslice);
        }
        if (Input.GetKey(KeyCode.RightArrow)) //右
        {
            this.transform.Rotate(Vector3.up * r_speed * timeslice);
        }
    }
}
