using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakScript : MonoBehaviour
{
    bool isBreaking=true;
    Rigidbody rb;
    [SerializeField]
    float strength;
    [SerializeField]
    Transform[] wheels = new Transform[4];
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    public void Break(bool x)
    {
        isBreaking = x;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isBreaking)
        {
            foreach (Transform wheel in wheels)
            {
                Vector3 wheelVelocity = rb.GetPointVelocity(wheel.position);
                Vector3 mitigationForce = new Vector3(wheelVelocity.x, 0, wheelVelocity.z);

                rb.AddForceAtPosition(-mitigationForce*strength, wheel.position);
            }
        }
    }
}
