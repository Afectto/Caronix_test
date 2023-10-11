using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class LoadImageFromURL : MonoBehaviour
{
    public RawImage rawImage;
    private string imageURL;

    public void ReloadImage(string image)
    {
        imageURL = image;
        StartCoroutine(LoadImage());
    }
    
    IEnumerator LoadImage()
    {
        if (imageURL == null) yield return null;
        
        UnityWebRequest www = UnityWebRequestTexture.GetTexture(imageURL);
        yield return www.SendWebRequest();

        if (www.result == UnityWebRequest.Result.Success)
        {
            Texture2D texture = DownloadHandlerTexture.GetContent(www);
            rawImage.texture = texture;
        }
        else
        {
            Debug.Log("Ошибка загрузки изображения: " + www.error);
        }
    }
}