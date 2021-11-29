using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageScript : MonoBehaviour
{

    private float duration;
    public int hp;
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        duration = player.GetComponent<PlayerSam>().imageInterval * player.GetComponent<PlayerSam>().numberOfImages*3;
        Destroy(gameObject, duration);
    }
 
}
