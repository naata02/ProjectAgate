using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class paddlecontroller : MonoBehaviour
{
    public KeyCode input;

    private float targetpressed;
    private float targetrelease;
    private HingeJoint hingejoint;

    private void Start()
    {
        hingejoint = GetComponent<HingeJoint>();

        targetpressed = hingejoint.limits.max;
        targetrelease = hingejoint.limits.min;
    }

    // Update is called once per frame
    private void Update()
    {
        ReadInput();
    }

    private void ReadInput()
    {
        JointSpring jointspring = hingejoint.spring;
        if (Input.GetKey(input))
        {

            jointspring.targetPosition = targetpressed;
        }
        else 
        {
            jointspring.targetPosition = targetrelease;
        }

        hingejoint.spring = jointspring;
    }
}
