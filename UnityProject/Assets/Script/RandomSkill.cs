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

        [Header("真的圖片")]
        public Sprite[] tSlotImage;

        [Header("轉動速度")]
        public float speed;
        

        private void Start()
        {
            StartCoroutine(onSpin());
        }

        private IEnumerator onSpin()
        {
            for (int i = fSlotImage.Length - 1 ; i > 0; i--)
            {
                imgSkill.sprite = fSlotImage[i];

                yield return new WaitForSeconds(speed);
            }

            StartCoroutine(onSpin());
        }

    }
}

