using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedPortalScript : MonoBehaviour
{
    private PlayerSam.Color color = PlayerSam.Color.Red;


    void OnTriggerEnter2D(Collider2D col)
    {


        if (col.gameObject.tag == "Player" && GameObject.FindWithTag("BluePortal") != null)
        {
            Debug.Log("Red portal tp");
            GameObject.FindWithTag("Player").GetComponent<PlayerSam>().teleport(color);
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            Debug.Log("Red portal exitZone");
            GameObject.FindWithTag("Player").GetComponent<PlayerSam>().exitTeleporterZone(color);
        }
    }
}
