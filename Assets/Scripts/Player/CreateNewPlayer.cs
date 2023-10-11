using UnityEngine;
using UnityEngine.UI;

public class CreateNewPlayer : MonoBehaviour
{
    public InputField InputField;
    
    public void NewPlayer()
    {
        SaveLoadSystem.Instance.PlayerData.Name = InputField.text;
        SaveLoadSystem.Instance.PlayerData.CoinCount = 0;
    }
}
