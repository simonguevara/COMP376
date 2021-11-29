using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalPickupScript : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            Debug.Log("Portal Pickup");
            GameObject.FindWithTag("Player").GetComponent<PlayerSam>().hasPortalGun = true;
            GameObject.FindWithTag("GameManager").GetComponent<GameManager>().isGadgetFound = true;
            //Do events
            Destroy(gameObject);
        }
    }
}
