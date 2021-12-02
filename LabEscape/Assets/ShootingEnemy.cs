using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingEnemy : MonoBehaviour
{
    public float fireRate = 1.0f;
    private GameObject player;
    public int dmg = 1;
    bool seesPlayer = false;
    public float followRange = 20.0f;
    public float fireRange = 10.0f;
    private float distance;
    public float speed = 3.0f;

    private Animator animator;
    private Rigidbody2D rigidbody;


    public GameObject bulletPrefab;

    private EnemyScript enemyScript;

    private Vector3 originalPosition;
    float teleportDelay = 4f;
    float _teleportDelay = 0f;
    void Start()
    {
        InvokeRepeating("Fire", 0.0f, fireRate);
        player = GameObject.FindWithTag("Player");
        enemyScript = GetComponent<EnemyScript>();
        animator = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody2D>();
        originalPosition = transform.position;
    }


    private void Update()
    {
        distance = (transform.position - player.transform.position).magnitude;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, (player.transform.position - transform.position).normalized, followRange, LayerMask.GetMask("Player", "Wall"));

        rigidbody.velocity = Vector2.zero;
        SetAnimatorToIdle();


        if (hit && hit.collider.tag == "Player")
        {
            seesPlayer = true;
            if ((player.transform.position - transform.position).x < 0)
            {
                gameObject.GetComponent<SpriteRenderer>().flipX = true;
            }
            else
            {
                gameObject.GetComponent<SpriteRenderer>().flipX = false;
            }

            if (distance >= fireRange && !enemyScript.isStunned)
            {
                rigidbody.velocity = (player.transform.position - transform.position).normalized * speed;


                if (Mathf.Abs(rigidbody.velocity.x) > Mathf.Abs(rigidbody.velocity.y))
                {
                    if (rigidbody.velocity.x < 0)
                    {
                        gameObject.GetComponent<SpriteRenderer>().flipX = true;
                        SetAnimatorToIdle();
                        animator.SetBool("isRunning", true);
                    }
                    else
                    {
                        gameObject.GetComponent<SpriteRenderer>().flipX = false;
                        SetAnimatorToIdle();
                        animator.SetBool("isRunning", true);
                    }
                }
                else
                {
                    if (rigidbody.velocity.y < 0)
                    {
                        SetAnimatorToIdle();
                        animator.SetBool("isRunning", true);
                    }
                    else
                    {
                        SetAnimatorToIdle();
                        animator.SetBool("isRunning", true);
                    }
                }
            }
        }
        else
        {
            seesPlayer = false;
            //------sheri xd----------
            //make enemy walk back to its original position so it doesnt stand near a wall or som
            if (Mathf.Approximately((originalPosition - transform.position).magnitude, 0))
            {
                rigidbody.velocity = Vector2.zero;
                transform.GetChild(0).gameObject.SetActive(false);
                //SetAnimatorToIdle();
            }
            else
            {
                //walk back to original spot
                transform.position = Vector3.MoveTowards(transform.position, originalPosition, speed * 0.33f * Time.deltaTime);
                if (rigidbody.IsSleeping())//if enemy is stuck somewhere, teleport after 4 seconds:
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


        transform.GetChild(0).gameObject.SetActive(seesPlayer);
    }

    private void Fire()
    {
        if (!enemyScript.isStunned && distance <= fireRange && seesPlayer)
        {
            animator.SetTrigger("isShooting");
            GameObject newBullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            newBullet.GetComponent<EnemyBullet>().setDamage(dmg);
            newBullet.GetComponent<EnemyBullet>().setDirection(player.transform.position - transform.position);
        }
    }

    private void SetAnimatorToIdle()
    {
        animator.SetBool("isRunning", false);
    }
}

