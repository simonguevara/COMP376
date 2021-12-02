using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AoEBot : MonoBehaviour
{
    GameObject player;
    public GameObject attackPrefab;
    void Start()
    {
        player = GameObject.FindGameObjectsWithTag("Player")[0];
    }

    // Update is called once per frame
    float _attackDelay;
    public float attackDelay = 5f;
    [SerializeField] float attackRange = 10f;
    void Update()
    {
        _attackDelay += Time.deltaTime;
        bool inAttRange = Vector2.Distance(player.transform.position, transform.position) <= attackRange;
        if (_attackDelay > attackDelay && inAttRange) {
            Attack();
            _attackDelay = 0f;
        }
    }

    void Attack() {
        Instantiate(attackPrefab, transform.position, Quaternion.identity);
        
    }

}
