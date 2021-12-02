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

    private Vector3 originalPosition;
    float teleportDelay = 4f;
    float _teleportDelay = 0f;

    void Start()
    {
        yellowHazmatRigidBody2D = GetComponent<Rigidbody2D>();
        target = GameObject.FindWithTag("Player");
        animator = GetComponent<Animator>();
        enemyScript = GetComponent<EnemyScript>();
        originalPosition = transform.position;
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
            //------sheri xd----------
            //make enemy walk back to its original position so it doesnt stand near a wall or som
            if (Mathf.Approximately((originalPosition - transform.position).magnitude, 0))
            {
                yellowHazmatRigidBody2D.velocity = Vector2.zero;
                transform.GetChild(0).gameObject.SetActive(false);
                SetAnimatorToIdle();
            }
            else
            {
                //walk back to original spot
                transform.position = Vector3.MoveTowards(transform.position, originalPosition, followSpeed * 0.33f * Time.deltaTime);
                if (yellowHazmatRigidBody2D.IsSleeping())//if enemy is stuck somewhere, teleport after 4 seconds:
                {
                    _teleportDelay += Time.deltaTime;
                    if (_teleportDelay >= teleportDelay)
                        transform.position = originalPosition;  //teleport if stuck 
                }
                else //if enemy is still moving, means not stuck, so no need to teleport xd
                {
                    _teleportDelay = 0f;
                }
            }
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

