using UnityEngine;

public class CameraControll : MonoBehaviour
{
    private Transform hero;
    
    [Header("攝影機移動速度")]
    public float cameraSpeed;

    [Header("限制高度"),Range(-16,-0)]
    public float top = -16;
    
    [Header("限制最底")]
    public float bottom = -9;

    public void Start()
    {
        //抓取玩家位置
        hero = GameObject.Find("Hero").transform;
    }

    public void LateUpdate()
    {
        Track();
    }

    /// <summary>
    /// 攝影機跟蹤玩家
    /// </summary>
    public void Track()
    {
        Vector3 posPlayer = hero.position;
        Vector3 posCamera = transform.position;

        posPlayer.x = 7.6f;

        posPlayer.z = Mathf.Clamp(posPlayer.z, top, bottom);

        transform.position = Vector3.Lerp(posPlayer, posCamera, 0.5f * Time.deltaTime * cameraSpeed);
    }
}
