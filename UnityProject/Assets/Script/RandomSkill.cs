using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace pino
{
    public class RandomSkill : MonoBehaviour
    {
        [Header("控制的圖片")]
        public Image imgSkill;

        [Header("動態模糊圖片")]
        public Sprite[] fSlotImage;

        private string[] namesSkill = { "連續射擊", "正向箭", "背向箭", "側向箭", "血量增加", "攻擊增加", "攻速增加", "爆擊增加"  };

        [Header("真的圖片")]
        public Sprite[] tSlotImage;

        [Header("轉動速度")]
        public float speed;

        [Header("模糊圖片執行次數")]
        public int count = 3;

        [Header("按鈕主體")]
        public Button btn;
        [Header("文字")]
        public Text textName;
        [Header("技能面板")]
        public GameObject skillPanel;

        //隨機技能編號
        private int index;

        private void Start()
        {
            StartCoroutine(onSpin());

            //監聽按鈕點擊
            btn.onClick.AddListener(ChooseSkill);
        }

        private IEnumerator onSpin()
        {
            btn.interactable = false;

            for (int j = 0; j < count; j++)
            {
                for (int i = fSlotImage.Length - 1; i > 0; i--)
                {
                    imgSkill.sprite = fSlotImage[i];
                    yield return new WaitForSeconds(speed);
                }
            }

            btn.interactable = true;
            index = Random.Range(0, tSlotImage.Length);
            imgSkill.sprite = tSlotImage[index];
            textName.text = namesSkill[index];//文字等於技能名稱
            
        }

        private void ChooseSkill()
        {
            skillPanel.SetActive(false);
            print(namesSkill[index]);
        }

    }
}

