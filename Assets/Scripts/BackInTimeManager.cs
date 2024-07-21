using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackInTimeManager : MonoBehaviour
{
    public static BackInTimeManager Instance { get; private set; }
    BackScript[] allBackScripts;
    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        allBackScripts = FindObjectsOfType<BackScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            RewindAll();
        }
    }
    public void RewindAll()
    {
        if (!AudioManager.Instance.IsPlaying("Rewind"))
        {
            AudioManager.Instance.Play("Rewind");
        }
        foreach (var rewindScript in allBackScripts)
        {
            rewindScript.BackInTime();
        }
    }
}
