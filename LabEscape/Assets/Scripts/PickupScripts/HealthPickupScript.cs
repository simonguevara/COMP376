using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickupScript : MonoBehaviour
{

    public int healValue = 1;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            Debug.Log("Health Pickup");

            GameObject player = GameObject.FindGameObjectWithTag("Player");
            player.GetComponent<PlayerSam>().heal(healValue);
            if (player.GetComponent<PlayerSam>().health > player.GetComponent<PlayerSam>().maxHealth)
                player.GetComponent<PlayerSam>().health = player.GetComponent<PlayerSam>().maxHealth;


            Destroy(gameObject);
        }
    }
}
