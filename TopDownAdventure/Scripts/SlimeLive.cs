using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeLive : MonoBehaviour
{
    public float health = 60;
    public GameObject poisonPrefab;
    public Animator anim;
    public bool isPoision = false;
    private float animationLength;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        animationLength = anim.GetCurrentAnimatorStateInfo(0).length;
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0|| isPoision)
        {
            animationLength -= Time.deltaTime;

            if (animationLength <= 0)
            {
                //Animasyon bittiðinde nesneyi yok et
                Destroy(gameObject);
                GameObject position = Instantiate(poisonPrefab, transform.position, Quaternion.identity);
            }

            
        }
    }

    public void TakeDamage(float amount)
    {
        health -= amount;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            isPoision= true;
        }
    }
}
