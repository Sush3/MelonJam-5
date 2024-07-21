using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switcher : MonoBehaviour
{
    AccelerationHandler ah;
    SteerScript ss;
    BreakScript bs;
    EngineScript es;
    [SerializeField]
    CinemachineVirtualCamera cam;

    void Awake()
    {
        ah=GetComponent<AccelerationHandler>();
        ss=GetComponent<SteerScript>();
        bs=GetComponent<BreakScript>();
        es=GetComponent<EngineScript>();
        Switch(false);
    }

    public void Switch(bool x)
    {
        ah.enabled = x;
        ss.enabled = x;
        es.enabled = x;
        bs.Break(!x);
        cam.Priority = x?1:0;
    }
}
