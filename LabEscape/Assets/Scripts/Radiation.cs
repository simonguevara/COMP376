using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Radiation : MonoBehaviour
{
     float tickRate = 1.15f;
    float mInvincibleTimer;
    bool mInvincible;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (mInvincible)
        {
            mInvincibleTimer += Time.deltaTime;
            if (mInvincibleTimer >= tickRate)
            {
                mInvincible = false;
                mInvincibleTimer = 0.0f;
            }
        }
    }

    void OnTriggerStay2D(Collider2D col)
    {
        
        if (col.gameObject.tag == "Player" && !mInvincible)
        {
            
            PlayerSam player = col.gameObject.GetComponent<PlayerSam>();
            mInvincible = true;
            player.TakeRadiationDamage(1);
        }
    }
}
