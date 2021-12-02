using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AoEBotAttack : MonoBehaviour
{
    [SerializeField] float explodeDelay = 2f;
    float _explodeDelay = 0f;

    [SerializeField] float timeoutDelay = 2f;
    float _timeoutDelay = 0f;

    

    //graphics refs
    [SerializeField] GameObject explodeAnimation;
    [SerializeField] GameObject light;
    [SerializeField] GameObject aoeIndicator;

    GameObject player;
    void Start()
    {
        player = GameObject.FindGameObjectsWithTag("Player")[0];
    }

    
    bool checkedForDamage = false;
    bool movingTowardsPlayer = true;
    void Update()
    {
        if (movingTowardsPlayer) {
            aoeIndicator.SetActive(false);
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, 5 * Time.deltaTime);
            if (Mathf.Approximately(Vector2.Distance(transform.position, player.transform.position), 0)) {
                movingTowardsPlayer = false;
                gameObject.GetComponent<Collider2D>().enabled = true;
            }
        }
        else if (playerCollisionDetected)
        {
            _explodeDelay += Time.deltaTime;
            //about to explode, so disable light and indicator for a more responsive effect
            if (_explodeDelay + 0.5f >= explodeDelay) {
                //light.SetActive(false);
                aoeIndicator.SetActive(false);
            }
            if (_explodeDelay >= explodeDelay)
            {
                explodeAnimation.SetActive(true);
                if (gameObject.GetComponent<Collider2D>().IsTouching(player.GetComponent<Collider2D>()) && !checkedForDamage)
                {
                    player.GetComponent<PlayerSam>().TakeDamage(-player.transform.position, 5);
                }
                checkedForDamage = true;
                //if player is initially outside the explosion range, dont dmg him if he steps back in
                _timeoutDelay += Time.deltaTime;
                if (_timeoutDelay >= timeoutDelay)
                {
                    Destroy(gameObject);
                }
            }
        }
        else {
            _timeoutDelay += Time.deltaTime;
            if (_timeoutDelay >= timeoutDelay)
            {
                Destroy(gameObject);
            }
        }


    }

    bool playerCollisionDetected = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _timeoutDelay = 1f;
            playerCollisionDetected = true;
            aoeIndicator.SetActive(true);
        }
    }


}
