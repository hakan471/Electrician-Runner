using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Timers;
using System;

//SUBSCRIBE TO VIN CODES FOR MORE FREE SCRIPTS IN FUTURE VIDEOS :)

public class Coin : MonoBehaviour
{
    public Transform playerTransform;
    public static float moveSpeed;
    CoinMove coinMoveScript;
    CoinMoveBusbar coinMoveScriptBusbar;

    // Start is called before the first frame update
    void Start()
    {
        moveSpeed = 17;
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        coinMoveScript = gameObject.GetComponent<CoinMove>();
        coinMoveScript.enabled = false;
    }

    void Update()
    {
        ////Mýknatýs----Eðer hareket var ise miknatis kodu calissin-?
        ////z eksen kontrolu
        //if (Math.Abs(playerTransform.position.z - transform.position.z) < 10)
        //{
        //    //x alan kontrol
        //    //if (Math.Abs(playerTransform.position.x - transform.position.x) < 1.5) coinMoveScript.enabled = true;
        //    //else coinMoveScript.enabled = false;
        //    coinMoveScript.enabled = true;
        //}
        //else coinMoveScript.enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(Magnet.magnetFlag && other.gameObject.tag == "Coin Detector")
        {
            coinMoveScript.enabled = true;
        }
    }
}


