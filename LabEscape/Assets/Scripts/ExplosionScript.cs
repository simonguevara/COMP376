using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionScript : MonoBehaviour
{

    public GameObject EMP;
    public float timeVisible = 0.3f;
    private float radius;

    // Start is called before the first frame update
    void Start()
    {
        radius = EMP.GetComponent<EMPScript>().explosionRange;
        transform.localScale = Vector2.one * radius;
        Destroy(gameObject, timeVisible);
    }

}
