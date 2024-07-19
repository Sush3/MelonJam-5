using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuspensionHandler : MonoBehaviour
{
    // fr fl br bl
    [SerializeField]
    Transform[] wheels= new Transform[4];

    [SerializeField]
    float suspensionTargetLength=1;
    [SerializeField]
    float suspensionStrength=10;
    [SerializeField]
    float suspensionDamper=1;
    [SerializeField]
    float grip=.95f;

    Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();   
    }

    void FixedUpdate()
    {
        foreach (var wheel in wheels)
        {
            //suspension
            RaycastHit hit;
            if (Physics.Raycast(wheel.position, -wheel.up, out hit, suspensionTargetLength))
            {
                Vector3 wheelVelocity = rb.GetPointVelocity(wheel.position);
                float suspensionOffset = (suspensionTargetLength - hit.distance);

                float suspensionvel = Vector3.Dot(wheel.up, wheelVelocity);

                float suspensionForce= suspensionOffset * suspensionStrength- suspensionvel * suspensionDamper;

                // dragging mitigation

                float sidewaysMovement = Vector3.Dot(wheel.right, wheelVelocity);
                float mitigationForce = -sidewaysMovement * grip;

                rb.AddForceAtPosition(wheel.up* suspensionForce+ wheel.right * mitigationForce, wheel.position);
                Debug.DrawRay(wheel.position, wheel.up * suspensionForce, Color.green);
                Debug.DrawRay(wheel.position, wheel.right * mitigationForce, Color.red);
            }
        }
    }
}
