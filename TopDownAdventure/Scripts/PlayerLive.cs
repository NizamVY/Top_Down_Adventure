using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerLive : MonoBehaviour
{
    public float health = 150;
    HealthTextController hTextCont;

    void Start()
    {
        hTextCont= GetComponent<HealthTextController>();
        UpdateHealthText(health);
    }

    void Update()
    {
        
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void TakeDamage(float amount)
    {
        health -= amount;
        UpdateHealthText(health);
    }

    public void TakeHeal(float amount)
    {
        health += amount;
        UpdateHealthText(health);
    }

    private void UpdateHealthText(float healthNew)
    {
        
    }

    
}
