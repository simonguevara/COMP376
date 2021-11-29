using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BluePortalScript : MonoBehaviour
{
    private PlayerSam.Color color = PlayerSam.Color.Blue;


    void OnTriggerEnter2D(Collider2D col)
    {


        if (col.gameObject.tag == "Player" && GameObject.FindWithTag("RedPortal") != null)
        {
            Debug.Log("Blue portal tp");
            GameObject.FindWithTag("Player").GetComponent<PlayerSam>().teleport(color);
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            Debug.Log("Blue portal exitZone");
            GameObject.FindWithTag("Player").GetComponent<PlayerSam>().exitTeleporterZone(color);
        }
    }
}
