using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayerCerberus : MonoBehaviour
{
    private Transform player;
    public Animator anim;
    public float speed = 4.0f;
    public float followDistance = 32.0f;
    public float attackDistance = 10f;
    private SpriteRenderer sprite;
    private CircleCollider2D circleCollider;

    private PlayerLive pLive;

    public GameObject alevPrefab;
    public float atisHizi;
    private bool atisHazir = true;


    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        circleCollider = GetComponent<CircleCollider2D>();

        atisHizi = 10f;
    }


    void Update()
    {
        float distance = Vector2.Distance(transform.position, player.position);

        if (distance <= followDistance && distance > attackDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
            anim.SetInteger("Animations", 1);
        }

        if (distance <= attackDistance)
        {
            anim.SetInteger("Animations", 2);

            if (atisHazir)
            {
                // Hedefin yönüne doðru ateþ etmek için yön hesaplamasý yapýlýr
                Vector3 atesYonu = (player.position - transform.position).normalized;

                // Ateþ prefabý oluþturulur ve hareket yönü belirlenir
                GameObject ates = Instantiate(alevPrefab, transform.position, Quaternion.identity);
                ates.GetComponent<Rigidbody2D>().velocity = atesYonu * atisHizi;

                // Atýþ yapýldýðýnda atýþ hazýr deðil
                atisHazir = false;

                // Atýþ hýzýný yeniden ayarlamak için bir süre bekleyin (1 saniye varsayýlan)
                Invoke("ResetAtisHazir", 1f);
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            pLive = collision.gameObject.GetComponent<PlayerLive>();
            pLive.TakeDamage(40);
        }
    }

    
    void ResetAtisHazir()
    {
        atisHazir = true;
    }

    public void Buff()
    {
        atisHizi *= 1.5f;
    }
}
