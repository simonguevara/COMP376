using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class LaserTrapScript : MonoBehaviour
{

    private SpriteRenderer spriteRenderer;
    private BoxCollider2D myCollider;
    private Light2D myLight2D;

    public float frequency = 3.0f;
    public float timeActive = 1.0f;
    public int damage = 1;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        myCollider = GetComponent<BoxCollider2D>();
        myLight2D = GetComponent<Light2D>();
        InvokeRepeating("Activate", 0f, frequency);
        InvokeRepeating("Deactivate", timeActive, frequency);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<PlayerSam>().TakeRadiationDamage(damage);
        }
        if (collision.CompareTag("Enemy"))
        {
            collision.GetComponent<EnemyScript>().takeDamage(damage);
        }
    }

    private void Activate()
    {
        spriteRenderer.enabled = true;
        myCollider.enabled = true;
        myLight2D.enabled = true;
    }
    private void Deactivate()
    {
        spriteRenderer.enabled = false;
        myCollider.enabled = false;
        myLight2D.enabled = false;
    }

}
