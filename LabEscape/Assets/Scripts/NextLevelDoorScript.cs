using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextLevelDoorScript : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            Debug.Log("Next Level Door");
            GameObject.FindWithTag("GameManager").GetComponent<GameManager>().loadNextLevel();
            //Do events
        }
    }
}
