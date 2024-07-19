using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switcher : MonoBehaviour
{
    AccelerationHandler ah;
    SuspensionHandler sh;
    SteerScript ss;
    BreakScript bs;
    [SerializeField]
    CinemachineVirtualCamera cam;

    // Start is called before the first frame update
    void Start()
    {
        ah=GetComponent<AccelerationHandler>();
        sh=GetComponent<SuspensionHandler>();
        ss=GetComponent<SteerScript>();
        bs=GetComponent<BreakScript>();
    }

    public void Switch(bool x)
    {
        ah.enabled = x;
        sh.enabled = x;
        ss.enabled = x;
        bs.Break(!x);
        cam.Priority = x?1:0;
    }
}
