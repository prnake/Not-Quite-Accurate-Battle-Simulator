using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class AIBattle : MonoBehaviour
{
    private GameObject[] EnemyArray;
    private GameObject Nearest;
    private Transform target;
    public float findDistance = 100.0f;
    public float chaseDistance = 5.0f;
    public float attackDistance = 2.0f;
    public string TargetTag = "Player";
    private float MDistance;
    private Animator ani;
    private NavMeshAgent ai;
    private float time;
    private float speedmult;

    private void FindPlayer()
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
            ai.enabled = true;
        }
        else
        {
            ai.enabled = false;
            ani.SetBool("isRun", false);
            ani.SetBool("isWalk", false);
            ani.SetBool("isAttack", false); 
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        speedmult = GetComponent<Statement>().speedmult;
        ai = gameObject.GetComponent<NavMeshAgent>();
        ani = this.gameObject.transform.Find("Body").gameObject.GetComponent<Animator>();
        findDistance = 10000.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if(this.tag =="Player"|| this.tag == "Enermy")
        {
            FindPlayer();
            if (target != null && Time.timeScale > 0)
            {
                 if (MDistance >= 20.0f)
                {
                    gameObject.transform.LookAt(target);
                    ai.SetDestination(target.position);
                    ai.speed = 12 * speedmult;
                    ani.SetBool("isWalk", false);
                    ani.SetBool("isRun", true);
                    ani.SetBool("isAttack", false);
                }
                else if (MDistance >= chaseDistance)
                {
                    gameObject.transform.LookAt(target);
                    ai.SetDestination(target.position);
                    ai.speed = 3 * speedmult;
                    ani.SetBool("isWalk", true);
                    ani.SetBool("isRun", false);
                    ani.SetBool("isAttack", false);
                }

                else if (MDistance >= attackDistance)
                {
                    gameObject.transform.LookAt(target);
                    ai.SetDestination(target.position);
                    ai.speed = 6 * speedmult;
                    ani.SetBool("isRun", true);
                    ani.SetBool("isWalk", false);
                    ani.SetBool("isAttack", true);
                }

                else if (MDistance <= attackDistance / 2)
                {
                    LookAt();
                    ai.SetDestination(2 * this.transform.position - target.position);
                    ai.speed = 6 * speedmult;
                    ani.SetBool("isRun", true);
                    ani.SetBool("isWalk", false);
                    ani.SetBool("isAttack", true);
                }

                else
                {
                    LookAt();
                    ai.enabled = false;
                    ai.enabled = true;
                    ani.SetBool("isRun", false);
                    ani.SetBool("isWalk", false);
                    ani.SetBool("isAttack", true);
                }

            }
        }
    }
    private void LookAt()
    {
        if (time > 0) time -= 1;
        else
        {
            gameObject.transform.LookAt(target);
            time = 10.0f;
        }
        
    }
}
