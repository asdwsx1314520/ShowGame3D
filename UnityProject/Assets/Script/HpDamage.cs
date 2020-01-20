using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HpDamage : MonoBehaviour
{
    private Image hpBar;
    private RectTransform rtValue;
    private Text textValue;

    private void Start()
    {
        hpBar = transform.GetChild(1).GetComponent<Image>();
        rtValue = transform.GetChild(2).GetComponent<RectTransform>();
        textValue = transform.GetChild(2).GetComponent<Text>();
    }

    private void Update()
    {
        FixedAngle();        
    }

    /// <summary>
    /// 固定角度: 不要讓血條旋轉
    /// </summary>
    private void FixedAngle() 
    {
        // 變形, 歐拉角度(世界角度) =  Vector3(61, -180, 0);
        transform.eulerAngles = new Vector3(61, -180, 0);
    }

    /// <summary>
    /// 血條更新
    /// </summary>
    /// <param name="hpCurrent">目前血量</param>
    /// <param name="hpMax">最大血量</param>
    public void UpdataeHpBar(float hpCurrent, float hpMax)
    {
        hpBar.fillAmount = hpCurrent / hpMax;
    }

    /// <summary>
    /// 顯示傷害
    /// </summary>
    /// <param name="value">受到的傷害</param>
    /// <param name="mark">正負</param>
    /// <param name="size">大小</param>
    /// <param name="valueColor">顏色</param>
    public IEnumerator ShowValue(float value, string mark, Vector3 size, Color valueColor)
    {
        textValue.text = mark + value;      //更新文字  : 符號 + 數值 (-90 or +90)
        valueColor.a = 0;                   //顏色.透明度 = 0
        textValue.color = valueColor;       //更新文字顏色
        rtValue.localScale = size;          //更新文字 大小

        for (int i = 0; i < 50; i++)
        {
            textValue.color += new Color(0, 0, 0, 0.1f);
            rtValue.anchoredPosition += Vector2.up * 1;
            yield return new WaitForSeconds(0.01f);
        }

        rtValue.anchoredPosition = new Vector2(0, 25);  //讓位子跑回原點
        textValue.color = new Color(0, 0, 0, 0);        //變透明
    }

}
