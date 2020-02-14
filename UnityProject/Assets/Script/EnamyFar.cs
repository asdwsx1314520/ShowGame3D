using UnityEngine;
using System.Collections;

public class EnamyFar : Enemy
{
    [Header("子彈")]
    public GameObject bullet;

    protected override void Attack()
    {
        base.Attack();
        StartCoroutine(CreateBullet());
    }
        
    /// <summary>
    /// 生成子彈
    /// </summary>
    /// <returns></returns>
    private IEnumerator CreateBullet()
    {
        yield return new WaitForSeconds(data.nearAttackDelay + 0.7f);

        Vector3 pos = transform.position + new Vector3(0, data.nearAttackPos.y, 0);

        pos += transform.forward * data.nearAttackPos.z;

        GameObject temp = Instantiate(bullet, pos, transform.rotation);
        temp.GetComponent<Rigidbody>().AddForce(transform.forward * data.FarPower);

        Buttle buttle =  temp.AddComponent<Buttle>();
        buttle.damage = data.attack;
    }

}
