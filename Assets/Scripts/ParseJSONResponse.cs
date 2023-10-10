using System;
using System.Collections;
using Leguar.TotalJSON;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class ParseJSONResponse : MonoBehaviour
{
    private const string APIUrl = "https://randomuser.me/api";

    private string _firstName;
    private string _secondName;
    private string _pathImg;
    
    public EnemyData EnemyData;
    
    public LoadImageFromURL LoadImageFromURL;
    public Text NameEnemy;

    private void Start()
    {
        NewEnemy();
    }

    public IEnemyData GETCurrentEnemyData()
    {
        if (_pathImg == null || _secondName == null || _firstName == null) return null;
        return EnemyData;
    }
    
    public void GETNewEnemyData(Action<IEnemyData> callback)
    {
        StartCoroutine(ParseResponse(callback));
    }

    public void NewEnemy()
    {
        GETNewEnemyData(enemyData =>
        {
            LoadImageFromURL.ReloadImage(enemyData.PathImg);
            NameEnemy.text = enemyData.FirstName + " " + enemyData.SecondName;
        });
    }

    IEnumerator ParseResponse(Action<IEnemyData> callback)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(APIUrl))
        {
            yield return webRequest.SendWebRequest();

            if (webRequest.result == UnityWebRequest.Result.Success)
            {
                string responseText = webRequest.downloadHandler.text;

                // Разбор JSON-ответа
                JSON data = JSON.ParseString(responseText).GetJArray("results")[0] as JSON;
                
                var nameData = data?.GetJSON("name");
                
                _firstName = nameData?.GetString("first");
                _secondName = nameData?.GetString("last");
                _pathImg = data?.GetJSON("picture").GetString("large");
                
                if (_pathImg == null || _secondName == null || _firstName == null)
                {
                    EnemyData = new EnemyData(_firstName, _secondName, _pathImg);
                }
                else 
                {
                    EnemyData.UpdateData(_firstName, _secondName, _pathImg);
                }

                // Вызываем обратный вызов с полученными данными
                callback?.Invoke(EnemyData);
            }
            else
            {
                Debug.LogError("Ошибка при выполнении GET-запроса: " + webRequest.error);
            }
        }
    }
}