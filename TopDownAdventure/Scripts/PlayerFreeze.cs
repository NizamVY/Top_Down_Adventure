using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFreeze : MonoBehaviour
{
    public Rigidbody2D playerRb;
    public Animator anim;
    private bool isFreeze=true;

    public AudioSource iceAudio;
    private IceAudioScript iceSound;

    public GameObject guns;
        void Start()
        {
            playerRb = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
            iceAudio=GetComponent<AudioSource>();
            anim= GetComponent<Animator>();
            iceSound= GetComponent<IceAudioScript>();
        
            iceSound.audioSource1.Play();

            guns = GameObject.FindGameObjectWithTag("Guns");

            if (guns != null)
            {
                guns.SetActive(false);
            }

        }
        // Update is called once per frame
        void Update()
        {
        if (isFreeze)
        {
            playerRb.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY;
            playerRb.freezeRotation = true;
            StartCoroutine(WaitAndPlayAnimation());
            StartCoroutine(WaitAndDestroy());
            iceSound.audioSource2.Play();
        }
        else
        {
            playerRb.constraints = RigidbodyConstraints2D.None;
            playerRb.freezeRotation = false;
        }

            

    }

    IEnumerator WaitAndPlayAnimation()
    {
        yield return new WaitForSeconds(1.0f); // 1 saniye bekle
        anim.SetTrigger("iceBreak"); // "ice_break" animasyonunu oynat
        isFreeze= false;

        if (guns != null)
        {
            guns.SetActive(true);
        }
    }

    IEnumerator WaitAndDestroy()
    {
        yield return new WaitForSeconds(5.0f); // 5 saniye bekle
        Destroy(gameObject);
    }
}
