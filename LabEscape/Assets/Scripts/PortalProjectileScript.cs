using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalProjectileScript : MonoBehaviour
{
    public Vector2 direction = new Vector2(0.0f, 0.0f);
    public float speed = 5.0f;
    public bool isRed = true;
    private Rigidbody2D bulletRigidBody2D;

    public GameObject redPortalPrefab;
    public GameObject bluePortalPrefab;


    // Start is called before the first frame update
    void Awake()
    {
        Invoke("despawn", 5.0f);
        bulletRigidBody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        bulletRigidBody2D.velocity = speed * direction.normalized;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Walls")
        {
            Debug.Log("Hit wall");
            SpawnPortal();
            Destroy(gameObject);
        }
    }

    private void SpawnPortal()
    {
        if (isRed)
        {
            GameObject previousPortal = GameObject.FindWithTag("RedPortal");
            if (previousPortal != null)
                Destroy(previousPortal);
            Instantiate(redPortalPrefab,transform.position,Quaternion.identity);
        }
        else
        {
            GameObject previousPortal = GameObject.FindWithTag("BluePortal");
            if (previousPortal != null)
                Destroy(previousPortal);
            Instantiate(bluePortalPrefab,transform.position,Quaternion.identity);
        }
    }

    public void setDirection(Vector2 newDirection)
    {
        direction = newDirection;
    }

    private void despawn()
    {
        Destroy(gameObject);
    }
}
