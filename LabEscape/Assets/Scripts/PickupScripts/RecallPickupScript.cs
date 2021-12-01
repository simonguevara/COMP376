using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecallPickupScript : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            Debug.Log("Recall Pickup");
            GameObject.FindWithTag("Player").GetComponent<PlayerSam>().hasRecall = true;
            GameObject.FindWithTag("GameManager").GetComponent<GameManager>().isGadgetFound = true;
            //Do events
            //Destroy(gameObject);
        }
    }
}
