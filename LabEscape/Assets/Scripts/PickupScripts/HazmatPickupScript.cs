using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazmatPickupScript : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            Debug.Log("Hazmat Pickup");
            GameObject.FindWithTag("Player").GetComponent<PlayerSam>().hasHazmat = true;
            GameObject.FindWithTag("GameManager").GetComponent<GameManager>().isGadgetFound = true;
            //Do events
            Destroy(gameObject);
        }
    }
}
