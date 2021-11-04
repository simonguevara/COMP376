using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowHazmat : MonoBehaviour
{
    [SerializeField] private int followSpeed;
    [SerializeField] private float followRange;

    private Rigidbody2D yellowHazmatRigidBody2D;
    private GameObject target;

    void Start()
    {
        yellowHazmatRigidBody2D = GetComponent<Rigidbody2D>();
        target = GameObject.FindWithTag("Player");
    }

    void Update()
    {
        float distance = (transform.position - target.transform.position).magnitude;
        if (distance < followRange)
        {
            yellowHazmatRigidBody2D.velocity = (target.transform.position - transform.position).normalized * followSpeed;
            transform.GetChild(0).gameObject.SetActive(true);
        }
        else
        {
            yellowHazmatRigidBody2D.velocity = new Vector2(0, 0);
            transform.GetChild(0).gameObject.SetActive(false);
        }

    }

     void OnTriggerStay2D(Collider2D col)
    {
        if(col.tag == "Player")
        {
            Player p = col.GetComponent<Player>();
            p.TakeDamage(10);
        }
    }
}
