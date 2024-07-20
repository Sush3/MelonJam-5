using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterDragScript : MonoBehaviour
{
    const float WATERLEVEL = 10;
    [SerializeField]
    Transform[] wheels;
    [SerializeField]
    AnimationCurve waterDragCurve = new AnimationCurve(new Keyframe(0, 1), new Keyframe(1, 1));
    [SerializeField]
    float dragMultiplier = .6f;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        foreach (var wheel in wheels)
        {
            if (wheel.position.y<WATERLEVEL)
            {
                Vector3 wheelVelocity = rb.GetPointVelocity(wheel.position);
                Vector3 dragForce = -wheelVelocity * waterDragCurve.Evaluate(wheelVelocity.magnitude) * dragMultiplier;
                rb.AddForceAtPosition(dragForce, wheel.position);
            }
        }
    }
}
