using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public float enemyHealth;
    public float maxHealth;

    public GameObject healthBarUI;
    public Slider slider;
    public GameObject enemy;
   
    public GameObject keyRegion;

    private void Start()
    {
        enemyHealth = maxHealth;
        slider.value = CalculateHealth();
    }

    void Update()
    {
        slider.value = CalculateHealth();
        if (enemyHealth < maxHealth)
        {
            healthBarUI.SetActive(true);
        }
        
    }

    float CalculateHealth()
    {
        return enemyHealth / maxHealth;
    }

    public void HurtEnemy(int damage)
    {
        enemyHealth -= damage;
        if (enemyHealth <= 0)
        {
            Destroy(enemy);
            if (enemy.name == "EnemyKey")
            {
                Instantiate(keyRegion, transform.position, transform.rotation);
            }

        }
    }

 }
