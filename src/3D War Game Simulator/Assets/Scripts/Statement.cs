using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Statement : MonoBehaviour
{
    private int m_health = 10;
    private int m_damage = 3;
    private int m_strength = 2;
    public float speedmult = 1.0f;
    private float deathtime = 1.2f;
    public float m_maxHealth = 20.0f;
    private int m_playerLevel = 1;
    private int m_experience = 0;
	public HPBar HP;
    // Start is called before the first frame update
    void Start()
    {
        HP = gameObject.GetComponentInChildren<HPBar>();
        //HP.MaxHealthPoint = m_maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerPrefs.GetInt("cheat")==1)
        {
            if (Input.GetKeyDown(KeyCode.K))
            {
                HP.HealthPoint -= 1;
            }
            else if (Input.GetKeyDown(KeyCode.J))
            {
                HP.HealthPoint += 1;
            }
        }
        if(this.tag == "Dead")
        {
            deathtime -= Time.deltaTime;
            this.GetComponentInChildren<Animator>().SetBool("isDead", true);
            this.GetComponentInChildren<Animator>().SetBool("isAttack", false);
        }
    }
    private void LateUpdate()
    {
        if (HP.HealthPoint <= 0)
        {
            this.tag = "Dead";
        }
        if (deathtime <= 0)
        {
            Destroy(gameObject);
        }
    }

}
