using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FollowPlayerSkull : MonoBehaviour
{
    public Animator anim;
    public SpriteRenderer sprite;

    public float attackRange = 9f;
    public float speed = 2.75f;
    public float lockDuration = 1f;
    public float followDistance = 32.0f;
    public float forwardSpeed = 20f;
    public Transform attackPoint;

    private Transform player;
    private float timeLocked = 0f;
    private bool locked = false;
    private bool isFreeze = false;
    private Vector3 lockedDirection;

    public SkullLive skLive;
    private bool isDeath = false;

    private CircleCollider2D circleCollider;

    private PlayerLive pLive;

    public GameObject buzPrefab;


    void Start()
    {
        anim=GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        circleCollider = GetComponent<CircleCollider2D>();
        sprite= GetComponent<SpriteRenderer>();
        skLive=GetComponent<SkullLive>();

    }

    void Update()
    {

        // check if player is in attack range
        float distance = Vector3.Distance(transform.position, player.position);

        if (distance <= followDistance && distance > attackRange)
        {
            speed = 2.75f;
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }

        if (distance <= attackRange&& !isDeath)
        {
            speed = 0f;
            // lock onto player direction for lockDuration seconds
            if (!locked)
            {
                circleCollider.isTrigger = false;
                lockedDirection = (player.position - transform.position).normalized;
                timeLocked = 0f;
                locked = true;
            }
            else if (timeLocked < lockDuration)
            {
                circleCollider.isTrigger = false;
                timeLocked += Time.deltaTime;
            }
            else
            {
                // attack in locked direction
                circleCollider.isTrigger = true;
                transform.position += lockedDirection * forwardSpeed * Time.deltaTime;
                speed = 2.75f;
            }
        }
        else
        {
            // not in range, unlock
            locked = false;
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

    void OnDrawGizmosSelected()
    {
        // draw attack range in scene view
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            pLive = collision.gameObject.GetComponent<PlayerLive>();
            pLive.TakeDamage(30);
            if (!isFreeze)
            {
                isFreeze = true;
                Vector3 position = player.transform.position;
                Instantiate(buzPrefab, position, Quaternion.identity);
            }
            else
            { 
                isFreeze= false;
            }
            
        }
    }
}