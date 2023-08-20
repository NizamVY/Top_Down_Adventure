using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkullLive : MonoBehaviour
{
    public float health = 150;
    public Animator anim;
    private float animationLength;

    public bool isDeath;

    void Start()
    {
        anim = GetComponent<Animator>();
        animationLength = anim.GetCurrentAnimatorStateInfo(0).length;
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0) 
        {
            isDeath = true;
            anim.SetTrigger("Dead");
            animationLength -= Time.deltaTime;
            if (animationLength <= 0)
            {
                //Animasyon bittiðinde nesneyi yok et
                Destroy(gameObject);
            }
        }
    }

    public void TakeDamage(float amount) 
    {
        health-= amount;
    }
}
