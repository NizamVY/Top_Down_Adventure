using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    public MouseLive mouseLive;
    public SkullLive skullLive;
    public SlimeLive slimeLive;
    public CerberusLive cerberLive;

    public float damage = 60;
    public float stayDamage = 0.15f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        mouseLive=collision.GetComponent<MouseLive>();
        if (collision.gameObject.name == "mouse-enemy(Clone)")
        {
            mouseLive.TakeDamage(damage);
        }

        if (collision.gameObject.name == "skull-enemy(Clone)")
        {
            skullLive = collision.GetComponent<SkullLive>();
            skullLive.TakeDamage(damage);
        }

        if (collision.gameObject.name == "slime-green(Clone)")
        {
            slimeLive = collision.GetComponent<SlimeLive>();
            slimeLive.TakeDamage(damage);
        }

        if (collision.gameObject.name == "cerberus-red(Clone)")
        {
            cerberLive = collision.GetComponent<CerberusLive>();
            cerberLive.TakeDamage(damage);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        
        if (collision.gameObject.name == "mouse-enemy(Clone)")
        {
            mouseLive = collision.GetComponent<MouseLive>();
            mouseLive.TakeDamage(stayDamage);
        }

        if (collision.gameObject.name == "skull-enemy(Clone)")
        {
            skullLive = collision.GetComponent<SkullLive>();
            skullLive.TakeDamage(stayDamage);
        }

        if (collision.gameObject.name == "slime-green(Clone)")
        {
            slimeLive = collision.GetComponent<SlimeLive>();
            slimeLive.TakeDamage(stayDamage);
        }

        if (collision.gameObject.name == "cerberus-red(Clone)")
        {
            cerberLive = collision.GetComponent<CerberusLive>();
            cerberLive.TakeDamage(stayDamage);
        }
    }
}
