﻿using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [Header("玩家資料")]
    public PlayerData data;

    public void BuyHp1000()
    {
        data.hpMax += 1000;
        data.hp = data.hpMax;
    }

    public void StartGame()
    {
        data.hp = data.hpMax;
        SceneManager.LoadScene(1);
    }
}
