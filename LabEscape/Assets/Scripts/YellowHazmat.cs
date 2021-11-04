using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowHazmat : MonoBehaviour
{
    [SerializeField] private int followSpeed;
    [SerializeField] private float followRange;

    private Rigidbody2D yellowHazmatRigidBody2D;
    private GameObject target;
    private Animator animator;

    void Start()
    {
        yellowHazmatRigidBody2D = GetComponent<Rigidbody2D>();
        target = GameObject.FindWithTag("Player");
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        float distance = (transform.position - target.transform.position).magnitude;
        if (distance < followRange)
        {
            yellowHazmatRigidBody2D.velocity = (target.transform.position - transform.position).normalized * followSpeed;
            transform.GetChild(0).gameObject.SetActive(true);

            if (Mathf.Abs(yellowHazmatRigidBody2D.velocity.x) > Mathf.Abs(yellowHazmatRigidBody2D.velocity.y))
            {
                if (yellowHazmatRigidBody2D.velocity.x < 0)
                {
                    gameObject.GetComponent<SpriteRenderer>().flipX = false;
                    SetAnimatorToIdle();
                    animator.SetBool("isMovingLeft", true);
                }
                else
                {
                    gameObject.GetComponent<SpriteRenderer>().flipX = true;
                    SetAnimatorToIdle();
                    animator.SetBool("isMovingLeft", true);
                }
            }
            else
            {
                if (yellowHazmatRigidBody2D.velocity.y < 0)
                {
                    SetAnimatorToIdle();
                    animator.SetBool("isMovingDown", true);
                }
                else
                {
                    SetAnimatorToIdle();
                    animator.SetBool("isMovingUp", true);
                }
            }
            animator.speed = 1;
        }
        else
        {
            yellowHazmatRigidBody2D.velocity = new Vector2(0, 0);
            transform.GetChild(0).gameObject.SetActive(false);
            animator.speed = 0;
        }

    }

    private void SetAnimatorToIdle()
    {
        animator.SetBool("isMovingLeft", false);
        animator.SetBool("isMovingUp", false);
        animator.SetBool("isMovingDown", false);
    }
}
