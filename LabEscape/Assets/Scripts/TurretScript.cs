using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretScript : MonoBehaviour
{

    public float fireRate = 1.0f;
    private GameObject player;
    public int dmg = 1;
    bool seesPlayer = false;
    public float followRange = 20.0f;

    public GameObject bulletPrefab;

    private EnemyScript enemyScript;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Fire", 0.0f, fireRate);
        player = GameObject.FindWithTag("Player");
        enemyScript = GetComponent<EnemyScript>();
    }


    private void Update()
    {


        float distance = (transform.position - player.transform.position).magnitude;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, (player.transform.position - transform.position).normalized, followRange, LayerMask.GetMask("Player", "Wall"));
        if (hit && hit.collider.tag == "Player")
        {
            seesPlayer = true;
        }
        else
        {
            seesPlayer = false;
        }
    }

    private void Fire()
    {
            
        if (!enemyScript.isStunned && seesPlayer)
        {
            GameObject newBullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            newBullet.GetComponent<EnemyBullet>().setDamage(dmg);
            newBullet.GetComponent<EnemyBullet>().setDirection(player.transform.position - transform.position);
        }
    }
}
