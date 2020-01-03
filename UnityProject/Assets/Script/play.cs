using UnityEngine;

public class play : MonoBehaviour
{
    public Rigidbody rig;
    public Joystick joysitck;
    public float speed;

    public Animator anim;
    public Transform aims;

    public LevelManager gm;

    public void Start()
    {
        //抓取有此物件的物件
        gm = FindObjectOfType<LevelManager>();
    }

    private void FixedUpdate()
    {
        Move();
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

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "TIRGGER")
        {
            gm.StartCoroutine("nextLevel");
        }
    }
}
