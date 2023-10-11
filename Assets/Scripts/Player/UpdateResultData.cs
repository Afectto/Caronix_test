using System;
using UnityEngine;
using UnityEngine.UI;

public class UpdateResultData : MonoBehaviour
{
    public Text Name;
    public Text CoinCount;

    private void Awake()
    {
        var coinReward = PlayerPrefs.GetInt("CoinRewardCount");
        
        SaveLoadSystem.Instance.PlayerData.CoinCount += coinReward;
        
        Name.text = "Бой с: " + PlayerPrefs.GetString("EnemyName");
        CoinCount.text = coinReward.ToString();
    }
}
