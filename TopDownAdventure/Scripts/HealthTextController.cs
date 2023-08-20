using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HealthTextController : MonoBehaviour
{
    public TextMeshProUGUI value; // TextMeshProUGUI elemaný
    private PlayerLive pLive;

    // Start is called before the first frame update
    void Start()
    {
        pLive = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerLive>();
    }

    void Update()
    {
        value.text=pLive.health.ToString();
    }
}
