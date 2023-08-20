using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SkoreController : MonoBehaviour
{
    public TextMeshProUGUI valueText; // TextMeshProUGUI elemaný
    public PlayerLive pLive;

    private int value = 0;

    private void Start()
    {
        pLive=GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerLive>();
        InvokeRepeating("UpdateValue", 1f, 1f); // Her saniye UpdateValue metodunu çaðýr
    }

    private void UpdateValue()
    {

        if (pLive.health > 0) 
        {
            value += 5; // Deðeri 5 artýr
        }
        if(value > 75)
        {
            valueText.text = (value-75).ToString(); // Deðeri TextMeshPro elemanýna yaz
        }
        
    }
}
