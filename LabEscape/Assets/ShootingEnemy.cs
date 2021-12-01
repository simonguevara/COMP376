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

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Fire", 0.0f, fireRate);
        player = GameObject.FindWithTag("Player");
        enemyScript = GetComponent<EnemyScript>();
        animator = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody2D>();
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

            if(distance >= fireRange && !enemyScript.isStunned)
            {
                rigidbody.velocity = (player.transform.position - transform.position).normalized * speed;
                

                if (Mathf.Abs(rigidbody.velocity.x) > Mathf.Abs(rigidbody.velocity.y))
                {
                    if (rigidbody.velocity.x < 0)
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
                    if (rigidbody.velocity.y < 0)
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
        }
        else
        {
            seesPlayer = false;
        }
    }

    private void Fire()
    {
        if (!enemyScript.isStunned && distance <= fireRange && seesPlayer)
        {
            GameObject newBullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            newBullet.GetComponent<EnemyBullet>().setDamage(dmg);
            newBullet.GetComponent<EnemyBullet>().setDirection(player.transform.position - transform.position);
        }
    }

    private void SetAnimatorToIdle()
    {
        animator.SetBool("isMovingLeft", false);
        animator.SetBool("isMovingUp", false);
        animator.SetBool("isMovingDown", false);
    }
}

