using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pulse : MonoBehaviour
{
    [SerializeField] private int pulseSpeed;

    void Start()
    {
        float randomAngle = Random.Range(0, 2 * Mathf.PI);
        GetComponent<Rigidbody2D>().velocity = new Vector2(Mathf.Cos(randomAngle), Mathf.Sin(randomAngle)).normalized * pulseSpeed;
    }

    void Update()
    {

    }
}
