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

        //玩家的位置
        Vector3 targetPos = targe.position; // 區域變數 目標座標 = 玩家座標
        targetPos.y = transform.position.y; // 目標座標.y = 自己的y
        transform.LookAt(targetPos);        // 看向(目標座標)


        // remainingDistance 跟目標物的距離
        // 如果進入停止距離範圍內 就等待 否則跑步
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
