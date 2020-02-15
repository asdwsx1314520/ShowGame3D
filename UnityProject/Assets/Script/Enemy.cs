using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [Header("敵人資料")]
    public EnemyData data;          //靜態 (所有使用此腳本參數的角色共用)

    private Animator ani;
    private NavMeshAgent agent;     // AI 系統

    private Transform targe;

    //血量死傷害系統控制器
    private HpDamage hpDamage;
    private float hp;               //每隻怪物獨立的血量

    //計時器
    private float timer;

    [Header("金幣")]
    public GameObject coin;

    private void Start()
    {
        ani = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();

        agent.speed = data.speed;
        agent.stoppingDistance = data.stopDistance;

        hp = data.hp;

        targe = GameObject.Find("Hero").transform;
        hpDamage = GetComponentInChildren<HpDamage>(); //取得子物件的元件 (僅限於子物件只有一個)
    }

    private void Update()
    {
        Move();
    }

    public void Move()
    {
        if (ani.GetBool("Dead")) return;

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

    /// <summary>
    /// 受傷
    /// </summary>
    /// <param name="damage"></param>
    public void Hit(float damage)
    {
        hp -= damage;
        hpDamage.UpdataeHpBar(hp, data.hpMax);

        StartCoroutine(hpDamage.ShowValue(damage, "-", Vector3.one, Color.white));
        if (hp <= 0)
        {
            Dead();
        }
    }

    public void Dead()
    {
        ani.SetBool("Dead", true);
        agent.isStopped = true;

        Destroy(this);              //刪除此腳本

        Destroy(this.gameObject, 1.5f);

        Prop();
    }

    /// <summary>
    /// 道具
    /// </summary>
    public void Prop()
    {
        int r = (int)Random.Range(data.coinRandom.x, data.coinRandom.y);

        for (int i = 0; i < r; i++)
        {
            Instantiate(coin, transform.position + new Vector3(1, coin.transform.position.y, 1), Quaternion.identity);
        }
    }

}
