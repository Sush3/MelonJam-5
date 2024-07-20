using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[ExecuteInEditMode]
public class FlowAreaController : MonoBehaviour
{
    [SerializeField]
    ParticleSystem particleSystem;
    BoxCollider boxCollider;

    // Update is called once per frame
    void Update()
    {
        if (Application.isEditor)
        {
            boxCollider = GetComponent<BoxCollider>();
            particleSystem.transform.position = new Vector3(transform.position.x, 10, transform.position.z) - transform.forward * boxCollider.size.z / 2;
            particleSystem.transform.rotation = transform.rotation;
            var shape = particleSystem.shape;
            var main = particleSystem.main;
            main.startLifetime = boxCollider.size.z * 0.065f;
            shape.scale = new Vector3(boxCollider.size.x, 0, 10);
        }
    }
}
