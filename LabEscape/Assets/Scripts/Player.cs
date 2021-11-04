using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private int playerSpeed;

    private Rigidbody2D playerRigidBody2D;

    void Start()
    {
        playerRigidBody2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        playerRigidBody2D.velocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized * playerSpeed;
    }
}
