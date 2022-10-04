using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//SUBSCRIBE TO VIN CODES FOR MORE FREE SCRIPTS IN FUTURE VIDEOS :)

public class CoinMoveing : MonoBehaviour
{
    Coin coinScript;

    private void Start()
    {
        coinScript = GetComponent<Coin>();
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, coinScript.playerTransform.position,
            Coin.moveSpeed * Time.deltaTime);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag== "Player Buble")
        {
            Destroy(gameObject);
        }
    }
}
