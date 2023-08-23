using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffController : MonoBehaviour
{
    public GameObject eleman1;
    public GameObject eleman2;
    public GameObject eleman3;
    public GameObject eleman4;

    public FollowPlayerMouse fpMouseSpeed;
    public FollowPlayerSkull fpSkullSpeed;
    public Position posionScale;
    public FollowPlayerCerberus fpCerbeusSpeed;

    private int aktifEleman = -1;
    private float sonrakiAktifZaman = 0f;

    // Start is called before the first frame update
    void Start()
    {
        sonrakiAktifZaman = Time.time + 210f; // 210 saniye sonraya ayarlandý zaman 

        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= sonrakiAktifZaman)
        {
            if (aktifEleman == -1)
            {
                eleman1.SetActive(true);
                aktifEleman = 0;
                sonrakiAktifZaman = Time.time + 60f;
                fpMouseSpeed.Buff();
            }
            else if (aktifEleman == 0)
            {
                eleman2.SetActive(true);
                aktifEleman = 1;
                sonrakiAktifZaman = Time.time + 60f;
                fpSkullSpeed.Buff();
            }
            else if (aktifEleman == 1)
            {
                eleman3.SetActive(true);
                aktifEleman = 2;
                sonrakiAktifZaman = Time.time + 60f;
                posionScale.Buff();
            }
            else if (aktifEleman == 2)
            {
                eleman4.SetActive(true);
                aktifEleman = 3;
                fpCerbeusSpeed.Buff();
            }
        }
    }
}
