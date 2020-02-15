using UnityEngine;

public class Buttle : MonoBehaviour
{
    public float damage;

    /// <summary>
    /// true 玩家的子彈, false 敵人的子彈
    /// </summary>
    public bool playerBuller;

    private void OnTriggerEnter(Collider other)
    {
        if (!playerBuller)
        {
            if(other.name == "Hero")
            {
                other.GetComponent<play>().Hit(damage);
            }
        }
        else
        {
            if (other.GetComponent<Enemy>() && other.tag == "enemy")
            {
                other.GetComponent<Enemy>().Hit(damage);
                Destroy(gameObject);
            }
        }

    }
}
