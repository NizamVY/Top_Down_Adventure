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
    }

    void Update()
    {

        Vector3 currentRotation = transform.eulerAngles;
        currentRotation.z = 0f;
        transform.eulerAngles = currentRotation;

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void TakeDamage(float amount)
    {
        health -= amount;
    }

    public void TakeHeal(float amount)
    {
        health += amount;
    }


    
}
