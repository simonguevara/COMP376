using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public GameObject healthPackPrefab;
    public float healthPackDropChance = 0.1f;

    public int healthPoints = 10;

    public bool isStunned = false;
    // Start is called before the first frame update
    void Start()
    {
        
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
    }

    internal void EMP(float stunTime)
    {
        isStunned = true;
        Invoke("unstun", stunTime);
    }

    private void unstun()
    {
        isStunned = false;
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
