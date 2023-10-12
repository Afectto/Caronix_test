using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class ParseJSONResponse : MonoBehaviour
{
    private const string APIUrl = "https://randomuser.me/api";

    private string _firstName;
    private string _lastName;
    private string _pathImg;
    
    public EnemyData EnemyData;

    public void GETNewEnemyData(Action<IEnemyData> callback)
    {
        StartCoroutine(ParseResponse(callback));
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
                RootObject data = JsonUtility.FromJson<RootObject>(responseText);

                _firstName = data.results[0].name.first;
                _lastName = data.results[0].name.last;
                _pathImg = data.results[0].picture.large;
                
                if (_pathImg == null || _lastName == null || _firstName == null)
                {
                    EnemyData = new EnemyData(_firstName, _lastName, _pathImg);
                }
                else 
                {
                    EnemyData.UpdateData(_firstName, _lastName, _pathImg);
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