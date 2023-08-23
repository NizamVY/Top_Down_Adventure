using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FollowPlayerMouse : MonoBehaviour
{
    private Transform player;
    public Animator anim;
    public float speed;
    public float followDistance = 10.0f;
    public float attackDistance = 1.5f;
    private SpriteRenderer sprite;
    private CircleCollider2D circleCollider;

    private PlayerLive pLive;


    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        circleCollider = GetComponent<CircleCollider2D>();

        speed = 12.66f;
    }


    void Update()
    {
        float distance = Vector2.Distance(transform.position, player.position);

            if (distance <= followDistance && distance>attackDistance)
            {
                circleCollider.isTrigger= false;
                transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
                anim.SetInteger("Animations", 1);
            }

            if (distance <= attackDistance)
            {
                circleCollider.isTrigger= true;
                anim.SetInteger("Animations", 2);
            }

            if (transform.position.x < player.position.x)
            {
                sprite.flipX = true;
            }
            else
            {
                sprite.flipX = false;
            }
    }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.tag == "Player")
            {
                pLive= collision.gameObject.GetComponent<PlayerLive>();
                pLive.TakeDamage(30);
            }
        }

        public void Buff() {
        speed *= 1.5f;
        }
}
