using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    void Start()
    {

    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Coin" || other.tag == "Engel")
        {
            Destroy(other.gameObject);
        }
    }
}