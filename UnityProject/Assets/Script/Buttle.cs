using UnityEngine;

public class Buttle : MonoBehaviour
{
    public float damage;

    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "Hero")
        {
            other.GetComponent<play>().Hit(damage);
        }
    }
}
