using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControler : MonoBehaviour
{
    public float maxspeed;
    private Rigidbody rigidbody;
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (rigidbody.velocity.magnitude > maxspeed)
        {
           rigidbody.velocity = rigidbody.velocity.normalized * maxspeed; 
        }
    }
}
