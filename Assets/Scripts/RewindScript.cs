using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewindScript : MonoBehaviour
{
    [SerializeField]
    int savedTicks;

    LinkedList<Vector3> savedPositions = new LinkedList<Vector3>();
    LinkedList<Quaternion> savedRotations = new LinkedList<Quaternion>();

    Vector3 currentPositionNode;
    Quaternion currentRotationNode;

    bool isRewinding = false;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (isRewinding)
        {
            var t = (Time.time % 0.02f)*50;
            transform.position = Vector3.Lerp(currentPositionNode, savedPositions.First.Value, t);
            transform.rotation = Quaternion.Lerp(currentRotationNode, savedRotations.First.Value, t);
        }
    }
    void FixedUpdate()
    {
        if (isRewinding)
        {
            if (savedPositions.Count>1)
            {
                currentPositionNode = savedPositions.First.Value;
                currentRotationNode = savedRotations.First.Value;
                transform.position = savedPositions.First.Value;
                transform.rotation = savedRotations.First.Value;
                savedPositions.RemoveFirst();                
                savedRotations.RemoveFirst();
            }
            else
            {
                isRewinding = false;
                Time.timeScale = 1;
            }
        }
        else {
            savedPositions.AddFirst(transform.position);
            savedRotations.AddFirst(transform.rotation);
            if (savedPositions.Count > savedTicks)
            {
                savedRotations.RemoveLast();
                savedPositions.RemoveLast();
            }
        }
    }
    public void Rewind()
    {
        isRewinding = true;
        Time.timeScale = 2;
        currentPositionNode = transform.position;
        currentRotationNode = transform.rotation;
    }
}
