using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldScript : MonoBehaviour
{
    private GameObject player;

    private Vector3 offset = new Vector3(0f, 0.01f, 0f);

    // Start is called before the first frame update
    private void Awake()
    {
        player = GameObject.FindWithTag("Player");
    }

    private void FixedUpdate()
    {
        transform.position = player.transform.position;
    }

    public void setTimer(float time)
    {
        Destroy(gameObject, time);
    }

}
