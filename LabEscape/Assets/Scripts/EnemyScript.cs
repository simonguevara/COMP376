using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public GameObject healthPackPrefab;
    public int healthPackDropChance = 10;

    public int healthPoints = 10;

    private SpriteRenderer sprite;
    private AudioSource audioSource;
    private Rigidbody2D rb;

    private Animator animator;

    public bool isStunned = false;
    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        audioSource = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (healthPoints <= 0)
        {
            OnDeath();

        }
    }

    public void takeDamage(int damage)
    {
        healthPoints -= damage;
        sprite.color = new Color(1, 0, 0, 1);
        Invoke("resetColor", 0.2f);
        //Do sound
    }

    private void resetColor()
    {
        sprite.color = new Color(1, 1, 1, 1);
    }

    internal void EMP(float stunTime)
    {
        isStunned = true;
        Invoke("unstun", stunTime);
        //Hit feedback
        sprite.color = new UnityEngine.Color(1, 1, 0, 1);
    }

    private void unstun()
    {
        isStunned = false;
        resetColor();
    }

    private void OnDeath()
    {
        float random = UnityEngine.Random.Range(0, 100);
        Destroy(gameObject, 1f);
        if (rb != null)
            rb.simulated = false;

        isStunned = true;

        //Animator trigger

        if (random < healthPackDropChance)
        {
            Instantiate(healthPackPrefab, transform.position, Quaternion.identity);
        }

    }
}
