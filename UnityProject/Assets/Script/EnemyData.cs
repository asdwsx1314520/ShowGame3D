using UnityEngine;

//腳本化物件 ScriptableObject : 將此腳本的資料儲存為物件並存放在 Progect 內

[CreateAssetMenu(fileName = "怪物資料", menuName = "Data/Enemy")]
public class EnemyData : ScriptableObject
{
    [Header("血量"), Range(10, 300)]
    public float hp;
    [Header("攻擊"), Range(0, 1000)]
    public float attack;
    [Header("攻擊冷卻時間"), Range(0, 5)]
    public float cd;
    [Header("移動速度"), Range(0, 1000)]
    public float speed;
    [Header("停止距離"), Range(0, 1000)]
    public float stopDistance;

    // 近距離資料
    [Header("攻擊長度"), Range(0, 1000)]
    public float nearAttackLength;
    [Header("攻擊位置")]
    public Vector3 nearAttackPos;
    [Header("攻擊延遲"), Range(0, 3)]
    public float nearAttackDelay;
}
