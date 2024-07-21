using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackScript : MonoBehaviour
{
    RewindScript rewindScript;
    Rigidbody rb;
    List<Vector3> savedPositions = new List<Vector3>();
    List<Vector3> savedVelocities = new List<Vector3>();
    List<Quaternion> savedRotations = new List<Quaternion>();
    [SerializeField]
    float interval;
    bool CorutineRunning = false;
    // Start is called before the first frame update
    void Start()
    {
        rb= GetComponent<Rigidbody>();
        rewindScript = GetComponent<RewindScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!CorutineRunning)
        {
            StartCoroutine(Push());
        }
    }
    public void BackInTime()
    {
        if (savedPositions.Count>0)
        {
            rewindScript.Clear();

            transform.position=savedPositions[savedPositions.Count-1];
            transform.rotation=savedRotations[savedRotations.Count-1];
            rb.velocity=savedVelocities[savedVelocities.Count-1];

            savedPositions.RemoveAt(savedVelocities.Count-1);
            savedRotations.RemoveAt(savedVelocities.Count-1);
            savedVelocities.RemoveAt(savedVelocities.Count-1);
        }
    }
    IEnumerator Push()
    {
        savedPositions.Add(transform.position);
        savedVelocities.Add(rb.velocity);
        savedRotations.Add(transform.rotation);
        CorutineRunning = true;
        yield return new WaitForSeconds(interval);
        CorutineRunning = false;
    }
}
