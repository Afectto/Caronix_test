using UnityEngine;
using UnityEngine.Serialization;

[System.Serializable]
public class SaveData
{
    [FormerlySerializedAs("_playerData")] public PlayerData playerData;

    public void SavePlayerData(string name, int coin)
    {
        playerData = new PlayerData(name, coin);
    }
    
}
