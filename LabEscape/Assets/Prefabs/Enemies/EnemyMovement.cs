using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private int followSpeed;
    [SerializeField] private float followRange;
    private Rigidbody2D rb;
    GameObject target;

    private Vector3 originalPosition;
    float teleportDelay = 4f;
    float _teleportDelay = 0f;

    //how close does the enemy walk to the player. set to 0 if you want melee range
    public float stopAtDistance = 5f; 
    void Start()
    {
        originalPosition = transform.position;
        rb = gameObject.GetComponent<Rigidbody2D>();
        target = GameObject.FindWithTag("Player");
    }

    void Update()
    {
        float distance = (target.transform.position - transform.position).magnitude;
        if (distance < followRange)
        {
            if (Vector2.Distance(transform.position, target.transform.position) - stopAtDistance <= 0) {
                //can stop moving now, close enough to the player
                rb.velocity = Vector2.zero;
            }
            else 
                rb.velocity = (target.transform.position - transform.position).normalized * followSpeed;
            
            transform.GetChild(0).gameObject.SetActive(true);

            if (Mathf.Abs(rb.velocity.x) > Mathf.Abs(rb.velocity.y))
            {
                if (rb.velocity.x < 0)
                {
                    gameObject.GetComponent<SpriteRenderer>().flipX = false;
                    //SetAnimatorToIdle();
                    //animator.SetBool("isMovingLeft", true);
                }
                else
                {
                    gameObject.GetComponent<SpriteRenderer>().flipX = true;
                    //SetAnimatorToIdle();
                    //animator.SetBool("isMovingLeft", true);
                }
            }
            else
            {
                if (rb.velocity.y < 0)
                {
                    //SetAnimatorToIdle();
                    //animator.SetBool("isMovingDown", true);
                }
                else
                {
                    //SetAnimatorToIdle();
                    //animator.SetBool("isMovingUp", true);
                }
            }
        }
        else
        {
            if (Mathf.Approximately((originalPosition - transform.position).magnitude, 0))
            {
                rb.velocity = Vector2.zero;
                transform.GetChild(0).gameObject.SetActive(false);
                //SetAnimatorToIdle();
            }
            else {
                //walk back to original spot
                transform.position = Vector3.MoveTowards(transform.position, originalPosition, followSpeed * 2 * Time.deltaTime);
                //if enemy is stuck somewhere:
                if (rb.IsSleeping())
                {
                    _teleportDelay += Time.deltaTime;
                    if (_teleportDelay >= teleportDelay)
                        transform.position = originalPosition;
                }
                else
                {
                    _teleportDelay = 0f;
                }
            }
        }
    }
}
