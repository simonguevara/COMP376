using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLvlDoorScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collision with door: " + other.gameObject.tag);

        if (other.gameObject.CompareTag("Player")){
            Debug.Log("Entered door");
       }
    }
}
