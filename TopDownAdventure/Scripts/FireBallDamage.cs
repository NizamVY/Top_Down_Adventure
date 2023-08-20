using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallDamage : MonoBehaviour
{
    public PlayerLive pLive;
    public Transform player;
    public SpriteRenderer sprite;

    private HealthTextController hTextCont;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        pLive =GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerLive>();
        sprite=GetComponent<SpriteRenderer>();
        StartCoroutine(DestroyAfterDelay(5.5f));
    }

    // Update is called once per frame
    void Update()
    {

        if (transform.position.x < player.position.x)
        {
            sprite.flipX = false;
        }
        else
        {
            sprite.flipX = true;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            pLive.TakeDamage(45);
        }
    }

    IEnumerator DestroyAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(gameObject);
    }
}
