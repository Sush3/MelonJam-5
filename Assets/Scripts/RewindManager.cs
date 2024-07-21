using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RewindManager : MonoBehaviour
{
    public static RewindManager Instance { get; private set; }
    RewindScript[] allRewindScripts;
    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        allRewindScripts = FindObjectsOfType<RewindScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
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
        foreach (var rewindScript in allRewindScripts)
        {
            rewindScript.Rewind();
        }
    }
}
