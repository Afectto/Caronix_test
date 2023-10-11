using UnityEngine;
using UnityEngine.UI;

public class UpdatePlayerData : MonoBehaviour
{
    public Text Name;
    public Text CoinCount;

    public void UpdateData()
    {
        var playerData =  SaveLoadSystem.Instance.PlayerData;

        Name.text = playerData.Name;
        CoinCount.text = playerData.CoinCount.ToString();
    }
}
