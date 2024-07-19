using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccelerationHandler : MonoBehaviour
{
    [SerializeField]
    float maxDistFromGround=2;
    [SerializeField]
    Transform[] poweredWheels;
    [SerializeField]
    AnimationCurve enginePowerCurve=new AnimationCurve(new Keyframe(0, 1), new Keyframe(1, 1));
    [SerializeField]
    float speed=1;
    [SerializeField]
    float drag=.6f;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W)|| Input.GetKey(KeyCode.S))
        {
            foreach (var wheel in poweredWheels)
            {
                if (Physics.Raycast(wheel.position,-wheel.up, maxDistFromGround))
                {
                    float accelerationForce = enginePowerCurve.Evaluate(rb.velocity.magnitude) * speed* (Input.GetKey(KeyCode.W)?1:-1);
                    rb.AddForceAtPosition(wheel.forward * accelerationForce, wheel.position);
                }
            }
        }
        else
        {
            rb.AddForce(-rb.velocity * drag);
        }
    }
}
