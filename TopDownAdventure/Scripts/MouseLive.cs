using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLive : MonoBehaviour
{
    public float health = 100;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0) 
        {
            Destroy(gameObject);
        }
    }

    public void TakeDamage(float amount) 
    {
        health-= amount;
    }
}
