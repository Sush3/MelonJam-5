using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlagScript : MonoBehaviour
{
    [SerializeField]
    Transform trailer;
    [SerializeField]
    float winDist;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, trailer.position) < winDist)
        {
            Debug.Log("WIN");
        }
    }
}
