using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{

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
}
