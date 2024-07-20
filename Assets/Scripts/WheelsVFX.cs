using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelsVFX : MonoBehaviour
{
    [SerializeField]
    float suspensionLength=1;
    [SerializeField]
    float wheelRadius=.5f;
    [SerializeField]
    Transform[] wheels= new Transform[4];
    [SerializeField]
    bool spinWheels;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb=GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        foreach (var wheel in wheels)
        {
            RaycastHit hit;
            if (Physics.Raycast(wheel.parent.position, -wheel.parent.up, out hit, suspensionLength))
            {
                wheel.position = new Vector3(0, -hit.distance+ wheelRadius, 0) + wheel.parent.position;
            }
            else
            {
                wheel.position = new Vector3(0, -suspensionLength+ wheelRadius, 0)+wheel.parent.position;
            }
            if (spinWheels)
            {
                wheel.Rotate(new Vector3(Vector3.Dot(wheel.parent.forward, rb.GetPointVelocity(wheel.parent.position)) / (2 * Mathf.PI * wheelRadius), 0,0));
            }
        }
    }
}
