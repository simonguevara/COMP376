using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public Vector2 direction = new Vector2(0.0f, 0.0f);
    public float speed = 5.0f;
    public int damage = 1;
    private Rigidbody2D bulletRigidBody2D;

    public GameObject playerBulletPrefab;


    // Start is called before the first frame update
    private void Start()
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
        if (col.gameObject.tag == "Player")
        {
            Debug.Log("Hit player");
            if (!col.GetComponent<PlayerSam>().isReflecting)
            {
                col.GetComponent<PlayerSam>().TakeDamage(direction, damage);
                Destroy(gameObject);
            }
            else
            {
                reflect();
            }
                
        }
        if (col.gameObject.tag == "Walls")
        {
            Debug.Log("Hit wall");
            Destroy(gameObject);
        }
    }

    private void reflect()
    {
        //Spawn new player bullet
        GameObject newBullet = Instantiate(playerBulletPrefab, transform.position, Quaternion.identity);

        Vector3 playerPos = GameObject.FindWithTag("Player").transform.position;

        Vector3 normal = transform.position - playerPos;
        float angleIncidence = Vector3.Angle(-direction, normal);
        Vector2 newDirection = Quaternion.AngleAxis(2* angleIncidence, Vector3.forward) * -direction;

        newBullet.GetComponent<PlayerBullet>().setDirection(newDirection);
        Destroy(gameObject);
    }

    public void setDirection(Vector2 newDirection)
    {
        direction = newDirection;
    }

    public void setDamage(int dmg)
    {
        damage = dmg;
    }

    private void despawn()
    {
        Destroy(gameObject);
    }
}
