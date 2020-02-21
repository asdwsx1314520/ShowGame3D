using UnityEngine;
using UnityEngine.Advertisements;   // 引用廣告 API

public class AdManager : MonoBehaviour, IUnityAdsListener
{
    private string googlePlay = "3468058";          //廣告ID Google Play
    private string placementRevival = "revival";    // 廣告名稱 復活

    private play player;

    private void Start()
    {
        //廣告，初始化(廣告服務 ID，啟動測試模式)
        Advertisement.Initialize(googlePlay, false);

        //廣告監聽
        Advertisement.AddListener(this);

        player = FindObjectOfType<play>();
    }

    public void ShowRevivalAd()
    {
        if (Advertisement.IsReady(placementRevival))
        {
            Advertisement.Show(placementRevival);
        }
    }

    /// <summary>
    /// 當廣告準備好
    /// </summary>
    /// <param name="placementId"></param>
    public void OnUnityAdsReady(string placementId)
    {
    }

    /// <summary>
    /// 廣告出錯時
    /// </summary>
    /// <param name="message"></param>
    public void OnUnityAdsDidError(string message)
    {
    }

    /// <summary>
    /// 廣告開始播放
    /// </summary>
    /// <param name="placementId"></param>
    public void OnUnityAdsDidStart(string placementId)
    {
    }

    /// <summary>
    /// 廣告完成
    /// </summary>
    /// <param name="placementId">廣告名稱</param>
    /// <param name="showResult">廣告結果</param>
    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        if(placementId == placementRevival)
        {
            switch (showResult)
            {
                //廣告失敗
                case ShowResult.Failed:
                    print("失敗");
                    break;
                //廣告略過
                case ShowResult.Skipped:
                    print("略過");
                    break;
                //廣告完成
                case ShowResult.Finished:
                    player.Revival();
                    break;
                default:
                    break;
            }
        }
    }
}
