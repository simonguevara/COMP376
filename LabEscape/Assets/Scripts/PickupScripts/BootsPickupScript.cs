using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BootsPickupScript : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            Debug.Log("Boots Pickup");
            GameObject.FindWithTag("Player").GetComponent<PlayerSam>().hasBoots = true;
            GameObject.FindWithTag("GameManager").GetComponent<GameManager>().isGadgetFound = true;
            //Do events
            //Destroy(gameObject);
        }
    }
}
