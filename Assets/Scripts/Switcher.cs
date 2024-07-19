using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switcher : MonoBehaviour
{
    AccelerationHandler ah;
    SteerScript ss;
    BreakScript bs;
    [SerializeField]
    CinemachineVirtualCamera cam;

    void Awake()
    {
        ah=GetComponent<AccelerationHandler>();
        ss=GetComponent<SteerScript>();
        bs=GetComponent<BreakScript>();
        Switch(false);
    }

    public void Switch(bool x)
    {
        ah.enabled = x;
        ss.enabled = x;
        bs.Break(!x);
        cam.Priority = x?1:0;
    }
}
