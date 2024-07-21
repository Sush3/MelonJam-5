using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSwitchManager : MonoBehaviour
{
    [SerializeField]
    Switcher currentSwitcher;
    // Start is called before the first frame update
    void Start()
    {
        currentSwitcher.Switch(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition),out hit, 1000, LayerMask.GetMask("Cars")))
            {
                Debug.Log(hit.transform.name);
                if(hit.transform.tag=="Car")
                {
                    currentSwitcher.Switch(false);
                    currentSwitcher = hit.transform.GetComponent<Switcher>();
                    currentSwitcher.Switch(true);
                }
            }
        }
    }
}
