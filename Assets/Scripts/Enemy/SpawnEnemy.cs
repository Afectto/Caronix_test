using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class SpawnEnemy : MonoBehaviour
{
    public Text nameEnemy;
    public GameObject player;
    public GameObject overlay;

    public ParseJSONResponse JSON;
    public LoadImageFromURL LoadImageFromURL;

    private void Awake()
    {
        NewEnemy();
    }

    public void NewEnemy()
    {
        overlay.SetActive(true);
        
        JSON.GETNewEnemyData(enemyData =>
        {
            LoadImageFromURL.ReloadImage(enemyData.PathImg);
            var enemyDataName = enemyData.Name;
            nameEnemy.text = enemyDataName.first + " " + enemyDataName.last;
            overlay.SetActive(false);
            
            player.GetComponent<UpdatePlayerData>().UpdateData();
            
            PlayerPrefs.SetString("EnemyName", nameEnemy.text);
            PlayerPrefs.Save();
        });
    }

}
