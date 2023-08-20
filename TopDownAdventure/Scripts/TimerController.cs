using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerController : MonoBehaviour
{
    public GameObject eleman0;
    public GameObject eleman1;
    public GameObject eleman2;
    public GameObject eleman3;

    private int aktifEleman = -1;
    private float sonrakiAktifZaman = 0f;

    private PlayerLive pLive;


    // Start is called before the first frame update
    void Start()
    {
        pLive=GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerLive>();
        // Sonraki elemanýn ne zaman aktif olacaðýný hesaplýyoruz
        sonrakiAktifZaman = Time.time + 15f; // 60 saniye sonra eleman 2 aktif olacak
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= sonrakiAktifZaman)
        {

            if (pLive.health < 150)
            {
                if(pLive.health+40<150)
                {
                    pLive.TakeHeal(40);
                }
                else 
                {
                    float heal = 150 - pLive.health;
                    pLive.TakeHeal(heal);
                }
            }

            if (aktifEleman == -1)
            {
                eleman0.SetActive(true);
                aktifEleman = 0;
                sonrakiAktifZaman = Time.time + 45f; 
            }else if (aktifEleman == 0)
            {
                eleman1.SetActive(true);
                aktifEleman = 1;
                sonrakiAktifZaman = Time.time + 45f; 
            }
            else if (aktifEleman == 1)
            {
                eleman2.SetActive(true);
                aktifEleman = 2;
                sonrakiAktifZaman = Time.time + 45f; 
            }
            else if (aktifEleman == 2)
            {
                eleman3.SetActive(true);
                aktifEleman = 3;
            }
        }
    }
}

