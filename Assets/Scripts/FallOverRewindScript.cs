using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallOverRewindScript : MonoBehaviour
{
    [SerializeField]
    float angleThreshold;
    [SerializeField]
    float YValueThreshold;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Angle(transform.up,Vector3.up)>angleThreshold||transform.position.y<YValueThreshold)
        {
            StartCoroutine(RewindAll());
        }
    }
    IEnumerator RewindAll()
    {
        yield return new WaitForSeconds(1);
        RewindManager.Instance.RewindAll();
    }
}
