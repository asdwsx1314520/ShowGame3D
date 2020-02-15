using UnityEngine;

public class Item : MonoBehaviour
{
    /// <summary>
    /// 過關
    /// </summary>
    public bool pass;

    private Transform player;

    void Start()
    {
        Physics.IgnoreLayerCollision(10, 10, false);

        HandleCollision();

        player = GameObject.Find("Hero").transform;
    }

    private void Update()
    {
        GoToPlayer();
    }

    /// <summary>
    /// 處理碰撞問題 : 設定碰撞圖層，避免與敵人跟玩家產生碰撞
    /// </summary>
    private void HandleCollision()
    {
        Physics.IgnoreLayerCollision(10, 8);
        Physics.IgnoreLayerCollision(10, 9);
    }

    private void GoToPlayer()
    {
        if (pass)
        {
            Physics.IgnoreLayerCollision(10, 10);
            transform.position = Vector3.Lerp(transform.position, player.position, 1.0f * Time.deltaTime * 4.5f);
            if(Vector3.Distance(transform.position, player.position) < 1)
            {
                Destroy(gameObject, 0.5f);
            }
        }
    }
}
