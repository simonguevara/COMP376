using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pulse : MonoBehaviour
{
    [SerializeField] private int pulseSpeed;

    private Rigidbody2D pulseRigidBody2D;

    void Start()
    {
        float randomAngle = Random.Range(0, 2 * Mathf.PI);
        pulseRigidBody2D = GetComponent<Rigidbody2D>();
        pulseRigidBody2D.velocity = new Vector2(Mathf.Cos(randomAngle), Mathf.Sin(randomAngle)).normalized * pulseSpeed;
    }

    void Update()
    {
        pulseRigidBody2D.velocity = pulseRigidBody2D.velocity.normalized * pulseSpeed;
    }
}
