using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretScript : MonoBehaviour
{

    public float fireRate = 1.0f;
    private GameObject player;
    public int dmg = 1;

    public GameObject bulletPrefab;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Fire", 0.0f, fireRate);
        player = GameObject.FindWithTag("Player");
    }

    private void Fire()
    {
        GameObject newBullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        newBullet.GetComponent<EnemyBullet>().setDamage(dmg);
        newBullet.GetComponent<EnemyBullet>().setDirection(player.transform.position-transform.position);
    }
}
