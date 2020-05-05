using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class MagicBattle : MonoBehaviour
{
    private GameObject[] EnemyArray,FriendArray;
    private GameObject Nearest;
    private Transform target;
    public float findDistance = 1000.0f;
    private float chaseDistance = 5.0f;
    private float attackDistance = 20.0f;
    public float CD = 30.0f,Range = 5.0f;
    public int type;
    public string TargetTag = "Player";
    private float MDistance;
    private Animator ani;
    private NavMeshAgent ai;
    private float time,CDtime;
    public ParticleSystem Bomb;
    private ParticleSystem hello;
    private int[] list;

    private void FindPlayer()
    {
        findDistance = 10000.0f;
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
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        ai = gameObject.GetComponent<NavMeshAgent>();
        ani = this.gameObject.transform.Find("Body").gameObject.GetComponent<Animator>();
        CDtime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(this.tag =="Player"|| this.tag == "Enermy")
        {
            FindPlayer();
            if (target != null && Time.timeScale > 0)
            {

                if (MDistance <= chaseDistance)
                {
                    gameObject.transform.LookAt(target);
                    ai.SetDestination(2*this.transform.position - target.position);
                    ai.speed = 3 * GetComponent<Statement>().speedmult;
                    ani.SetBool("isRun", true);
                }

                else if (MDistance <= attackDistance)
                {
                    gameObject.transform.LookAt(target);
                    ai.SetDestination(2 * this.transform.position - target.position);
                    ai.speed = 2 * GetComponent<Statement>().speedmult;
                    ani.SetBool("isRun", false);
                    ani.SetBool("isWalk", true);
                }

                else
                {
                    LookAt();
                    ai.enabled = false;
                    ai.enabled = true;
                    ani.SetBool("isRun", false);
                    ani.SetBool("isWalk", false);
                }
                if (CDtime > 0)
                {
                    CDtime -= Time.timeScale;
                    if (CDtime < CD * 2/3)
                    {
                        ani.SetBool("isAttack", false);
                    }
                }
                else
                {
                    CDtime = CD;
                    if (type == 1 || type == 2)
                    {
                        hello = (ParticleSystem)Instantiate(Bomb, target.position, Quaternion.identity);
                        hello.GetComponent<Destroy>().flag = true;
                        hello.Play();
                        ani.SetBool("isAttack", true);
                        for (int i = 0; i < EnemyArray.Length; i++)
                        {
                            float Distance = Vector3.Distance(hello.transform.position, EnemyArray[i].transform.position);
                            if (Distance < Range)
                            {
                                if (type == 1) EnemyArray[i].GetComponentInChildren<HPBar>().HealthPoint -= 5;
                                else if (type == 2)
                                {
                                    EnemyArray[i].GetComponentInChildren<HPBar>().HealthPoint -= 0.5f;
                                    if (EnemyArray[i].GetComponent<Statement>().speedmult >= 0.1f) EnemyArray[i].GetComponent<Statement>().speedmult *= 0.5f;
                                }
                            }
                        }
                    }
                    else if (type == 3)
                    {
                        if (TargetTag == "Player") FriendArray = GameObject.FindGameObjectsWithTag("Enermy");
                        else if (TargetTag == "Enermy") FriendArray = GameObject.FindGameObjectsWithTag("Player");
                        Nearest = null;
                        MDistance = 0.0f;
                        float CDistance;
                        for (int i = 0; i < FriendArray.Length; i++)
                        {
                            CDistance = Vector3.Distance(this.transform.position, FriendArray[i].transform.position);
                            if (CDistance > MDistance)
                            {
                                MDistance = CDistance;
                                Nearest = FriendArray[i];
                            }
                        }
                        if (Nearest != null)
                        {
                            target = Nearest.transform;
                            hello = (ParticleSystem)Instantiate(Bomb, target.position, Quaternion.identity);
                            hello.GetComponent<Destroy>().flag = true;
                            hello.Play();
                            ani.SetBool("isAttack", true);
                            for (int i = 0; i < FriendArray.Length; i++)
                            {
                                float Distance = Vector3.Distance(hello.transform.position, FriendArray[i].transform.position);
                                if (Distance < Range)
                                {
                                    FriendArray[i].GetComponentInChildren<HPBar>().HealthPoint += FriendArray[i].GetComponentInChildren<HPBar>().MaxHealthPoint*0.5f;
                                }
                            }
                        }

                    }
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
