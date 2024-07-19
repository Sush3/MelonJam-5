using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class FlowScript : MonoBehaviour
{
    [SerializeField]
    private int height;

    [SerializeField]
    private int width;

    [SerializeField]
    private float spacing = .1f;

    [SerializeField]
    private float distance;

    private List<Vector3> validRays = new List<Vector3>();

    // Start is called before the first frame update
    private void Start()
    {
        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                Vector3 v = transform.TransformPoint(new Vector3(i - width / 2, j - height / 2, 0) * spacing);
                if (v.y<10 && Terrain.activeTerrain.SampleHeight(v)>0)
                {
                    validRays.Add(v);
                }
            }
        }
        Debug.Log("there are " + validRays.Count + " valid rays");
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        RaycastHit hit;
        foreach (var ray in validRays)
        {
            if (Physics.Raycast(ray, transform.forward, out hit, distance)&&hit.transform.CompareTag("Car"))
            {
                Debug.DrawRay(ray, transform.forward*hit.distance);
                hit.transform.GetComponent<CurrentCollisionHandler>().Hit(hit.point,transform.forward);
            }
        }
    }

    private void OnDrawGizmos()
    {
        Vector3[] points = new Vector3[8];
        points[0] = transform.TransformPoint(new Vector3(-width / 2, -height / 2, 0) * spacing);
        points[1] = transform.TransformPoint(new Vector3(width / 2, -height / 2, 0) * spacing);
        points[2] = transform.TransformPoint(new Vector3(width / 2, height / 2, 0) * spacing);
        points[3] = transform.TransformPoint(new Vector3(-width / 2, height / 2, 0) * spacing);
        points[4] = transform.TransformPoint(new Vector3(-width / 2, -height / 2, distance) / spacing * spacing);
        points[5] = transform.TransformPoint(new Vector3(width / 2, -height / 2, distance / spacing) * spacing);
        points[6] = transform.TransformPoint(new Vector3(width / 2, height / 2, distance / spacing) * spacing);
        points[7] = transform.TransformPoint(new Vector3(-width / 2, height / 2, distance/spacing) * spacing);
        Gizmos.DrawLineStrip(points, true);
        Gizmos.DrawRay(transform.position, transform.forward);
    }
}