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
            PlayerSam player = GameObject.FindWithTag("Player").GetComponent<PlayerSam>();

            player.health += healValue;
            if (player.health > player.maxHealth)
                player.health = player.maxHealth;
            
            Destroy(gameObject);
        }
    }
}
