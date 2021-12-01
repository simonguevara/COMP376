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

    private EnemyScript enemyScript;

    void Start()
    {
        yellowHazmatRigidBody2D = GetComponent<Rigidbody2D>();
        target = GameObject.FindWithTag("Player");
        animator = GetComponent<Animator>();
        enemyScript = GetComponent<EnemyScript>();
    }

    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, (target.transform.position - transform.position).normalized, followRange, LayerMask.GetMask("Player", "Wall"));
        if (hit && hit.collider.tag == "Player" && !enemyScript.isStunned)
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
        }
        else
        {
            yellowHazmatRigidBody2D.velocity = Vector2.zero;
            transform.GetChild(0).gameObject.SetActive(false);
            SetAnimatorToIdle();
        }

    }

    void OnCollisionStay2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            PlayerSam player = col.gameObject.GetComponent<PlayerSam>();
            player.TakeDamage((target.transform.position - transform.position).normalized, 1);
        }
    }

    private void SetAnimatorToIdle()
    {
        animator.SetBool("isMovingLeft", false);
        animator.SetBool("isMovingUp", false);
        animator.SetBool("isMovingDown", false);
    }
}

