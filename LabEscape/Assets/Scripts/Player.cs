using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private int playerSpeed;

    private Rigidbody2D playerRigidBody2D;
    private Animator myAnimator;

    void Start()
    {
        playerRigidBody2D = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
    }

    void Update()
    {
        Vector2 direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        playerRigidBody2D.velocity = direction.normalized * playerSpeed;


        SetAnimatorToIdle();
        if (direction.x > 0)
        {
            SetAnimatorToIdle();
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
            myAnimator.SetBool("isMovingLeft", true);
        }
        else if (direction.x < 0)
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
            SetAnimatorToIdle();
            myAnimator.SetBool("isMovingLeft", true);
        }
        if (direction.y > 0)
        {
            SetAnimatorToIdle();
            myAnimator.SetBool("isMovingUp", true);
        }
        else if (direction.y < 0)
        {
            SetAnimatorToIdle();
            myAnimator.SetBool("isMovingDown", true);
        }
    }

    private void SetAnimatorToIdle()
    {
        myAnimator.SetBool("isMovingLeft", false);
        myAnimator.SetBool("isMovingUp", false);
        myAnimator.SetBool("isMovingDown", false);
    }
}
