using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CerberusLive : MonoBehaviour
{
    public float health = 300;


    // Start is called before the first frame update
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
        health -= amount;
    }
}
