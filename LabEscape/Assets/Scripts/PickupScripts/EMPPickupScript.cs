using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EMPPickupScript : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            Debug.Log("EMP Pickup");
            GameObject.FindWithTag("Player").GetComponent<PlayerSam>().hasEMP = true;
            //Do events
            Destroy(gameObject);
        }
    }
}
