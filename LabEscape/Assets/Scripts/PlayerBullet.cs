using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{

    public Vector2 direction = new Vector2(0.0f,0.0f);
    public float speed = 5.0f;
    public int damage = 1;
    private Rigidbody2D bulletRigidBody2D;


    // Start is called before the first frame update
    void Awake()
    {
        Invoke("despawn", 5.0f);
        bulletRigidBody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        bulletRigidBody2D.velocity = speed * direction.normalized;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            //col.gameObject.GetComponent<EnemyScript>.takeDamage(damage)
            Debug.Log("Hit enemy");
            col.GetComponent<EnemyScript>().takeDamage(damage);
            Destroy(gameObject);
        }
        if (col.gameObject.tag == "Walls")
        {
            Debug.Log("Hit wall");
            Destroy(gameObject);
        }
    }

    public void setDirection(Vector2 newDirection)
    {
        direction = newDirection;
    }

    private void despawn()
    {
        Destroy(gameObject);
    }
}
