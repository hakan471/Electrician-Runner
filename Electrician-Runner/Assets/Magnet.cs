using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magnet : MonoBehaviour
{
    public GameObject coinDetectorObj;
    public static bool magnetFlag = false;
    GameObject player;
    public float time;
    // Start is called before the first frame update
    void Start()
    {
        //coinDetectorObj = GameObject.FindGameObjectWithTag("Coin Detector");
        //coinDetectorObj.SetActive(false);
        player = GameObject.FindGameObjectWithTag("Player");
    }
    private void Update()
    {
        if(!magnetFlag) transform.Rotate(Vector3.up, Time.deltaTime * 30);
        else
        {
            time -= Time.deltaTime;
            if (time > 0)
            {
                transform.rotation = Quaternion.identity;
                transform.position = new Vector3(player.transform.position.x, player.transform.position.y + 3.5f, player.transform.position.z);
            }
            else
            {
                magnetFlag = false;
                time = 5;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            magnetFlag = true;
            //daha sonra kapanacak
            //player.radius = 1;
            //Destroy(gameObject);
            //Destroy(transform.GetChild(0).gameObject);
        }
    }
}
