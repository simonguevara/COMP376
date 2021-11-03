using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorScript : MonoBehaviour
{

    public float speed = 1f;
    Rigidbody rbody;

    // Start is called before the first frame update
    void Start()
    {
        rbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 position = rbody.position;
        rbody.position += Vector3.back * speed * Time.fixedDeltaTime;
        rbody.MovePosition(position);
    }
}
