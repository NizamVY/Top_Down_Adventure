using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Position : MonoBehaviour
{
    public PlayerLive pLive;


    // Start is called before the first frame update
    void Start()
    {
        pLive=GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerLive>();
        StartCoroutine(DestroyAfterDelay(8f));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            pLive.TakeDamage(15);
        }
    }

    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            pLive.TakeDamage(0.55f);
        }
    }

    IEnumerator DestroyAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(gameObject);
    }
}
