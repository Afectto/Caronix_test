using System;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using Image = UnityEngine.UI.Image;
using Random = UnityEngine.Random;

public class Enemy : MonoBehaviour
{
    [FormerlySerializedAs("HealthBar")] [SerializeField] private Image _healthBar;
    public float health = 100;
    private float _maxHealth = 100;
    public float Health { get => health; set => health = value; }
    public float MaxHealth { get => _maxHealth; set => _maxHealth = value; }
    private int CoinRewardCount;

    public Text Name;

    private void Awake()
    {
        Health = MaxHealth = Random.Range(50, 100);
        CoinRewardCount = Random.Range(100, 1000);
        
        Name.text = PlayerPrefs.GetString("EnemyName");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            TakeDamage(Random.Range(5,10));
        }
    }

    public void TakeDamage(float damage)
    {
        if (damage < 0 && Health >= MaxHealth)
        {
            Health = MaxHealth;
        }
        else if (Health <= 0 && damage > 0)
        {
            Health = 0;
        }
        else
        {	
            Health -= damage;
        }

        if (_healthBar != null) _healthBar.fillAmount = Health / MaxHealth;

        if (Health <= 0)
        {
            PlayerPrefs.SetInt("CoinRewardCount", CoinRewardCount);
            PlayerPrefs.Save();
            SceneController.Instance.LoadNextScene("Result"); 
        }
    }
}
