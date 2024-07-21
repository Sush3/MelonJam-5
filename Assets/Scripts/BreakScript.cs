using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakScript : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField]
    float breakDrag;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    public void Break(bool x)
    {
        rb.drag = x?breakDrag:1;
        if (GetComponent<HingeJoint>())
        {
            GetComponent<HingeJoint>().connectedBody.drag = x ? breakDrag : 1;
        }
        rb.WakeUp();
    }
}
