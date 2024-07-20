using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class FlowScript : MonoBehaviour
{
    [SerializeField]
    private float spacing = .1f;

    private BoxCollider boxCollider;

    private List<Vector3> validRays = new List<Vector3>();

    [SerializeField]
    private int checkIfPlayerInRangeFrequency = 5;

    private bool playerInRange = false;

    // Start is called before the first frame update
    private void Start()
    {
        boxCollider = GetComponent<BoxCollider>();
        for (int i = 0; i < boxCollider.size.x/spacing; i++)
        {
            for (int j = 0; j < boxCollider.size.y / spacing; j++)
            {
                Vector3 v = transform.TransformPoint(new Vector3(i*spacing- boxCollider.size.x/2, j * spacing - boxCollider.size.y/2, -boxCollider.size.z / 2));
                if (v.y < 10 && v.y > Terrain.activeTerrain.SampleHeight(v))
                {
                    validRays.Add(v);
                    if (validRays.Count > 100000)
                    {
                        Debug.LogWarning("There are 10000 rays");
                        return;
                    }
                }
            }
        }
        Debug.Log("there are " + validRays.Count + " valid rays");
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (Time.frameCount % checkIfPlayerInRangeFrequency == 0)
        {
            playerInRange = Physics.CheckBox(transform.position, boxCollider.size / 2, transform.rotation, LayerMask.GetMask("Cars"));
        }
        if (playerInRange)
        {
            RaycastHit hit;
            foreach (var ray in validRays)
            {
                if (Physics.Raycast(ray, transform.forward, out hit, boxCollider.size.z) && hit.transform.CompareTag("Car"))
                {
                    Debug.DrawRay(ray, transform.forward * hit.distance);
                    hit.transform.GetComponent<CurrentCollisionHandler>().Hit(hit.point, transform.forward);
                }
            }
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawRay(transform.position, transform.forward* GetComponent<BoxCollider>().size.z/2);
    }
}