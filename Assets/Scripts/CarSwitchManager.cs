using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSwitchManager : MonoBehaviour
{
    [SerializeField]
    Switcher switcher;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition),out hit))
            {
                Debug.Log(hit.transform.tag);
                Debug.Log(hit.transform.name);
                if(hit.transform.tag=="Car")
                {
                    switcher.Switch(false);
                    switcher = hit.transform.GetComponent<Switcher>();
                    switcher.Switch(true);
                }
            }
        }
    }
}
