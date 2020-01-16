using System.Collections;
using UnityEngine.SceneManagement;// 引用場景管理
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
        //非同步載入場景,等待場景載入完畢(預載)
        AsyncOperation async = SceneManager.LoadSceneAsync("Level_two");

        async.allowSceneActivation = false;

        for (int i = 0; i < 100; i++)
        {
            returnScene.color += new Color(0, 0, 0, 0.01f);
            yield return new WaitForSeconds(0.001f);
        }

        //允許載入
        async.allowSceneActivation = true;
    }
}
