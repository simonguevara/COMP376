using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{

    public Vector2 direction = new Vector2(0.0f,0.0f);
    public float speed = 3.0f;
    public float damage = 1.0f;
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
        bulletRigidBody2D.velocity = speed * direction;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            //col.gameObject.GetComponent<EnemyScript>.takeDamage(damage)
            Debug.Log("Hit enemy");
        }
        if (col.gameObject.tag == "Walls")
        {
            Debug.Log("Hit wall");
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
