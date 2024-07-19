using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSwitchManager : MonoBehaviour
{
    [SerializeField]
    Switcher startingCar;

    Switcher[] allSwitchers;
    // Start is called before the first frame update
    void Start()
    {
        startingCar.Switch(true);
        //I know that find is expensive
        allSwitchers = Component.FindObjectsOfType<Switcher>();
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
                    startingCar.Switch(false);
                    startingCar = hit.transform.GetComponent<Switcher>();
                    startingCar.Switch(true);
                }
            }
        }
    }
}
