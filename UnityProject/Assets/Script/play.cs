﻿using UnityEngine;

public class play : MonoBehaviour
{
    public Rigidbody rig;
    public Joystick joysitck;
    public float speed;

    [Header("玩家資料")]
    public PlayerData data;
    [Header("武器")]
    public GameObject bullet;

    public Animator anim;
    public Transform aims;

    public LevelManager gm;

    private HpDamage hpDamage;

    private float timer;        //計時器

    public void Start()
    {
        //抓取有此物件的物件
        gm = FindObjectOfType<LevelManager>();

        hpDamage = GetComponentInChildren<HpDamage>(); //取得子物件的元件 (僅限於子物件只有一個)
    }

    private void FixedUpdate()
    {
        Move();
    }

    /// <summary>
    /// 進入下個關卡
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "TIRGGER")
        {
            gm.StartCoroutine("nextLevel");
        }
    }

    public void Move()
    {
        float h = joysitck.Horizontal;
        float v = joysitck.Vertical;

        rig.AddForce(-h * speed, 0, -v * speed);

        anim.SetBool("Run", v != 0 || h != 0);

        Vector3 posPlayer = transform.position;//簡易版抓取座標
        //計算目標位置
        Vector3 posAims = new Vector3(posPlayer.x - h, 1.5f, posPlayer.z - v);

        //讓目標座標等於上方計算的座標
        aims.position = posAims;
        //固定目標座標的y
        posAims.y = posPlayer.y;
        //讓腳色看相目標
        transform.LookAt(posAims);

        if(v == 0 && h == 0)
        {
            Attack();
        }

    }

    /// <summary>
    /// 受傷
    /// </summary>
    /// <param name="damage">接收傷害值</param>
    public void Hit(float damage)
    {
        data.hp -= damage;
        hpDamage.UpdataeHpBar(data.hp, data.hpMax);

        StartCoroutine(hpDamage.ShowValue(damage, "-", Vector3.one, Color.white));
        if(data.hp <= 0)
        {
            Dead();
        }
    }

    private void Dead() 
    {
        anim.SetBool("Dead", true);

        enabled = false;                //取消此類別運作

        StartCoroutine(gm.ShowRevival());
    }

    /// <summary>
    /// 玩家復活
    /// </summary>
    public void Revival()
    {
        enabled = true;
        anim.SetBool("Dead", false);
        data.hp = data.hpMax;
        hpDamage.UpdataeHpBar(data.hp, data.hpMax);
        gm.CloseRevival();
    }

    public void Attack()
    {
        if (timer < data.cd)
        {
            timer += Time.deltaTime;
        }
        else
        {
            timer = 0;

            Vector3 pos = transform.position + transform.up * 1 + transform.forward * 1.5f;

            Quaternion qua = Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y + 180, transform.eulerAngles.z);

            Instantiate(bullet, pos, qua);
        }
    }
    
}
