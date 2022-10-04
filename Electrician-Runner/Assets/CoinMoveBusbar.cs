using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//SUBSCRIBE TO VIN CODES FOR MORE FREE SCRIPTS IN FUTURE VIDEOS :)

public class CoinMoveBusbar : MonoBehaviour
{

    Coin coinScript;

    // Start is called before the first frame update
    void Start()
    {
        coinScript = gameObject.GetComponent<Coin>();
    }

    // Update is called once per frame
    void Update()
    {
        //if busbar ise bunu deðilse diðerleri. CoinMoveBusbar.cs yaz
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(coinScript.playerTransform.position.x + 1.2f, coinScript.playerTransform.position.y + 1, coinScript.playerTransform.position.z),
            Coin.moveSpeed * Time.deltaTime);
    }
}
