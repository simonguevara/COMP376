using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public GameObject healthPackPrefab;
    public float healthPackDropChance = 0.1f;

    public int healthPoints = 10;

    private SpriteRenderer sprite;
    private AudioSource audioSource;

    public bool isStunned = false;
    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(healthPoints <= 0)
        {
            OnDeath();
            Destroy(gameObject);
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
        float random = UnityEngine.Random.Range(0, 1);
        if(random < healthPackDropChance)
        {
            Instantiate(healthPackPrefab, transform.position, Quaternion.identity);
        }
        //TO DO : On death stufff
    }
}
