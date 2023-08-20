using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayerSlime : MonoBehaviour
{

    private Transform player;
    public Animator anim;
    public float speed = 4.0f;
    public float followDistance = 10.0f;
    public float attackDistance = 3.5f;
    private SpriteRenderer sprite;
    private CircleCollider2D circleCollider;
    public SlimeLive slimeLive;

    private float animationLength;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        sprite = GetComponent<SpriteRenderer>();
        circleCollider = GetComponent<CircleCollider2D>();
        anim = GetComponent<Animator>();
        animationLength = anim.GetCurrentAnimatorStateInfo(0).length;
        slimeLive = GetComponent<SlimeLive>();
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector2.Distance(transform.position, player.position);

        if (distance <= followDistance && distance > attackDistance)
        {
            circleCollider.isTrigger = false;
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }

        if (distance <= attackDistance)
        {
            circleCollider.isTrigger = true;
            anim.SetTrigger("Attack");
            animationLength -= Time.deltaTime;

            if (animationLength <= 0)
            {
                //Animasyon bittiðinde nesneyi yok et
                slimeLive.TakeDamage(1000);
            }
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
}
