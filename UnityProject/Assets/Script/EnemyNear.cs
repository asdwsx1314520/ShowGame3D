﻿using UnityEngine;
using System.Collections;

public class EnemyNear : Enemy
{
    /// <summary>
    /// 繪製圖示 : 在場景面板內繪製圖示方便編輯
    /// </summary>
    private void OnDrawGizmos()
    {
        // 圖示.顏色 = 顏色
        Gizmos.color = Color.red;

        // 圖片.繪製射線(中心點 , 方向)

        // 前方 transfrom.forward
        // 右方 transfrom.right
        // 上方 transfrom.up

        Gizmos.DrawRay(transform.position + data.nearAttackPos, transform.forward * data.nearAttackLength);
    }

    /// <summary>
    /// 近距離攻擊: 複寫父類別,添加攻擊延遲
    /// </summary>
    protected override void Attack()
    {
        base.Attack();

        StartCoroutine(DelayAttack());
    }

    /// <summary>
    /// 延遲攻擊: 利用射線攻擊玩家
    /// </summary>
    /// <returns></returns>
    private IEnumerator DelayAttack()
    {
        yield return new WaitForSeconds(data.nearAttackDelay);

        RaycastHit hit; //區域變數 接收射線碰到的資訊

        if(Physics.Raycast(transform.position + data.nearAttackPos, transform.forward, out hit, data.nearAttackLength))
        {
            hit.collider.GetComponent<play>().Hit(data.attack);
        }
    }
}
