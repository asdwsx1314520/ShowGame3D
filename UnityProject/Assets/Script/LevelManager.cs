using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public Animator dool;
    public GameObject randomSkill;
    public Image returnScene;

    public bool isOpen;
    public bool isDisplaySkill;

    private void Start()
    {
        if (isOpen)
        {
            showSkill();
        }

        if (isDisplaySkill)
        {
            Invoke("openDool", 1);
        }
    }

    public void openDool()
    {
        dool.SetTrigger("OpenDool");
    }

    public void showSkill()
    {
        randomSkill.SetActive(isOpen);
    }

    public IEnumerator nextLevel()
    {

        for (int i = 0; i < 100; i++)
        {
            returnScene.color += new Color(0, 0, 0, 0.01f);
            yield return new WaitForSeconds(0.001f);
        }
    }
}
