using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteerScript : MonoBehaviour
{
    [SerializeField]
    Transform[] steerWheels= new Transform[2];
    [SerializeField]
    bool[] invertSteering = new bool[2];
    [SerializeField]
    float maxAngle=45;
    [SerializeField]
    float steerSpeed=100;
    [SerializeField]
    float getToNeutralStrength=50;

    float currentAngle;
    private void Start()
    {
        if (steerWheels.Length!= invertSteering.Length)
        {
            Debug.LogError("steer wheels and invert steering need to have the same length");
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            currentAngle += steerSpeed*Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            currentAngle -= steerSpeed * Time.deltaTime;
        }

        if (!Input.GetKey(KeyCode.D)&&!Input.GetKey(KeyCode.A))
        {
            GetToNeutral();
        }
        CalculateAngle();
    }
    void GetToNeutral()
    {
        currentAngle +=(currentAngle<0?getToNeutralStrength:-getToNeutralStrength)*Time.deltaTime;
    }
    void CalculateAngle()
    {
        currentAngle = Mathf.Clamp(currentAngle, -maxAngle, maxAngle);
        for (int i = 0; i < steerWheels.Length; i++)
        {
            steerWheels[i].localEulerAngles = new Vector3(0, currentAngle * (invertSteering[i] ? 1 : -1), 0);
        }
    }
}
