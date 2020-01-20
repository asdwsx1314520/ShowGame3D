using UnityEngine;

[CreateAssetMenu(fileName = "PlayData", menuName = "Data/player")]
public class PlayerData : ScriptableObject
{
    [Header("血量與最大血量")]
    [Range(200, 3000)]
    public float hp = 200;

    public float hpMax;
}
