using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [Header("敵人資料")]
    public EnemyData data;

    private Animator ani;
    private NavMeshAgent agent;

    private Transform targe;

    //計時器
    private float timer;

    private void Start()
    {
        ani = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();

        agent.speed = data.speed;
        agent.stoppingDistance = data.stopDistance;

        targe = GameObject.Find("Hero").transform;
    }

    private void Update()
    {
        Move();
    }

    public void Move()
    {
        agent.SetDestination(targe.position);

        if (agent.remainingDistance < agent.stoppingDistance)
        {
            Wait();
        }else
        {
            ani.SetBool("Run", true);
        }
    }

    public void Wait() 
    {
        ani.SetBool("Run", false);
        timer += Time.deltaTime;

        if(timer >= data.cd) 
        {
            Attack();
        }
    }

    protected virtual void Attack()
    {
        timer = 0;
        ani.SetTrigger("Attack");
    }

    public void Hit(float damage)
    {

    }

    public void Dead()
    {

    }

    /// <summary>
    /// 道具
    /// </summary>
    public void Prop()
    {

    }

}
