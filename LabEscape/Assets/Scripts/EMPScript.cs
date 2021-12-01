using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EMPScript : MonoBehaviour
{

    public Vector2 direction = new Vector2(0.0f, 0.0f);
    private Rigidbody2D bulletRigidBody2D;


    //Parameters
    [Header("EMPSettings")]
    public float speed = 5.0f;
    public int damage = 0;
    public float explosionTime = 1.5f;
    public float explosionRange = 5.0f;
    public float stunTime = 3.0f;

    [Header("Explosion effect")]
    public GameObject explosionEffectPrefab;


    // Start is called before the first frame update
    void Awake()
    {
        Invoke("despawn", explosionTime);
        bulletRigidBody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        bulletRigidBody2D.velocity = speed * direction.normalized;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("EMP Hit :"+col.tag);

        if (col.gameObject.tag == "Enemy")
        {
            //col.gameObject.GetComponent<EnemyScript>.takeDamage(damage)
            Debug.Log("Hit enemy");
            explode();
            Destroy(gameObject);
        }
        if (col.gameObject.tag == "Walls")
        {
            Debug.Log("EMP Hit wall");
            explode();
            Destroy(gameObject);
        }
    }

    private void explode()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        for(int i = 0; i< enemies.Length; i++)
        {
            float distance = (transform.position - enemies[i].transform.position).magnitude;

            if(distance <= explosionRange)
            {
                enemies[i].GetComponent<EnemyScript>().EMP(stunTime);
            }
        }

        Instantiate(explosionEffectPrefab, transform.position, Quaternion.identity);
    }

    public void setDirection(Vector2 newDirection)
    {
        direction = newDirection;
    }

    private void despawn()
    {
        explode();
        Destroy(gameObject);
    }
}
