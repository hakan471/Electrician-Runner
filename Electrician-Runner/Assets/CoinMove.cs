using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//SUBSCRIBE TO VIN CODES FOR MORE FREE SCRIPTS IN FUTURE VIDEOS :)

public class CoinMove : MonoBehaviour
{

    Coin coinScript;
    BoxCollider collider;
    // Start is called before the first frame update
    void Start()
    {
        coinScript = gameObject.GetComponent<Coin>();
        collider = gameObject.GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        //if busbar ise bunu deðilse diðerleri. CoinMoveBusbar.cs yaz
        //if (gameObject.name.Contains("busbar"))
        //{

        //    transform.position = Vector3.MoveTowards(transform.position, new Vector3(coinScript.playerTransform.position.x /*+ 1.2f*/, coinScript.playerTransform.position.y + 1, coinScript.playerTransform.position.z),
        //    coinScript.moveSpeed * Time.deltaTime);
        //}
        //else
        //{
        //    transform.position = Vector3.MoveTowards(transform.position, new Vector3(coinScript.playerTransform.position.x, coinScript.playerTransform.position.y + 1, coinScript.playerTransform.position.z),
        //    coinScript.moveSpeed * Time.deltaTime);
        //}
        transform.position = Vector3.MoveTowards(collider.transform.position, new Vector3(coinScript.playerTransform.position.x, coinScript.playerTransform.position.y + 0.5f, coinScript.playerTransform.position.z+0.5f),
            Coin.moveSpeed * Time.deltaTime);
    }
}
