using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;
    SpriteRenderer rb_sprite;

    float horizontal;
    float vertical;

    public float runSpeed = 6.0f;

    private Animator anim;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb_sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        if (horizontal == -1)
        {
            rb_sprite.flipX = true;
        }
        else if (horizontal == 1)
        { rb_sprite.flipX = false;}

        AnimationOynat();
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * runSpeed, vertical * runSpeed);
    }

    private void AnimationOynat() 
    {
        if (horizontal!=0)
        {
            anim.SetInteger("hareket", 0);
        }
        else if (vertical==-1) 
        {
            anim.SetInteger("hareket", 1);
        }
        else if(vertical == 1)
        {
            anim.SetInteger("hareket", 2);
        }

        if (horizontal == 0 && vertical == 0)
        {
            anim.SetInteger("hareket", -1);
        }
        
    }
}
