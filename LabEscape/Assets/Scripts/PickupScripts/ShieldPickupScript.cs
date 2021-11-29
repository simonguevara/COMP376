using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldPickupScript : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            Debug.Log("Shield Pickup");
            GameObject.FindWithTag("Player").GetComponent<PlayerSam>().hasShield = true;
            GameObject.FindWithTag("GameManager").GetComponent<GameManager>().isGadgetFound = true;
            //Do events
            Destroy(gameObject);

        }
    }
}
