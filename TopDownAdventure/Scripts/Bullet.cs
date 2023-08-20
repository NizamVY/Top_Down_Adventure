using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;
    private Rigidbody2D rb;

    public int damage=30;

    public MouseLive mouseLive;
    public SkullLive skullLive;
    public CerberusLive cerberLive;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * speed;

        StartCoroutine(DestroyAfterDelay(5f));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "mouse-enemy(Clone)")
        {
            mouseLive = collision.GetComponent<MouseLive>();
            mouseLive.TakeDamage(damage);
        }else if (collision.gameObject.name == "skull-enemy(Clone)")
        {
            skullLive = collision.GetComponent<SkullLive>();
            skullLive.TakeDamage(damage);
        }else if (collision.gameObject.name == "cerberus-red(Clone)")
        {
            cerberLive = collision.GetComponent<CerberusLive>();
            cerberLive.TakeDamage(damage);
        }
    }

    IEnumerator DestroyAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(gameObject);
    }
}
