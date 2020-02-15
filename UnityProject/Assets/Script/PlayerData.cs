using UnityEngine;

[CreateAssetMenu(fileName = "PlayData", menuName = "Data/player")]
public class PlayerData : ScriptableObject
{
    [Header("血量與最大血量")]
    [Range(200, 3000)]
    public float hp = 200;

    public float hpMax;

    [Header("攻擊速度"), Range(200, 3000)]
    public float cd = 0.8f;

    [Header("武器速度"), Range(200, 3000)]
    public float power = 500.0f;

    [Header("攻擊力"), Range(1, 500)]
    public float attack = 200.0f;
}
