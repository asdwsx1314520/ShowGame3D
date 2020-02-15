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

    [Header("復活介面")]
    public GameObject panelRevival;

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

    /// <summary>
    /// 顯示復活介面
    /// </summary>
    /// <returns></returns>
    public IEnumerator ShowRevival()
    {
        panelRevival.SetActive(true);

        for (int i = 3; i > 0; i--)
        {
            panelRevival.transform.GetChild(1).GetComponent<Text>().text = i.ToString();
            yield return new WaitForSeconds(1);
        }
    }

    /// <summary>
    /// 關閉復活介面
    /// </summary>
    public void CloseRevival()
    {
        StopCoroutine(ShowRevival());
        panelRevival.SetActive(false);
    }

    /// <summary>
    /// 過關
    /// </summary>
    public void Pass()
    {
        openDool();

        Item[] coins = FindObjectsOfType<Item>();

        for (int i = 0; i < coins.Length; i++)
        {
            coins[i].pass = true;
        }

    }
}


