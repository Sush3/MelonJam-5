using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakScript : MonoBehaviour
{
    bool isBreaking=true;
    Vector3 breakPos;
    Rigidbody rb;
    [SerializeField]
    float strength;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        breakPos=transform.position;
    }
    public void Break(bool x)
    {
        isBreaking = x;
        if (isBreaking) breakPos=transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (isBreaking)
        {
            rb.AddForce((breakPos-transform.position)* strength);
        }
    }
}
