using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DaralmaScript : MonoBehaviour
{
    GameObject player;
    bool flag = false;
    // Start is called before the first frame update
    void Start()
    {
        flag = false;
        player = GetComponent<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        if (flag)
        {
            Move.xMin = -1.168f;
            Move.xMax = 1.168f;

            if (Move.yPointCamera > -0.2f)
            {
                Move.yPointCamera -= Time.deltaTime;
                Move.zPointCamera += Time.deltaTime +0.05f;
                Debug.Log(Move.zPointCamera);
                
            }
            else
            {
                flag = false;
            }
        }
        else
        {
            Move.yPointCamera = 0;
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            flag = true;
        }
    }
}
