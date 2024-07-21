using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EngineScript : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField]
    float increment;
    [SerializeField]
    float multiply;
    [SerializeField]
    string audioName;

    [SerializeField]
    float startVolume;
    // Start is called before the first frame update
    void Start()
    {
        rb=GetComponent<Rigidbody>();
        AudioManager.Instance.Play(audioName);
    }

    // Update is called once per frame
    void Update()
    {
        AudioManager.Instance.ChangePitch(audioName, rb.velocity.magnitude* multiply+increment);

    }
    private void OnEnable()
    {
        AudioManager.Instance.ChangeVolume(audioName, startVolume);
    }
    private void OnDisable()
    {
        AudioManager.Instance.ChangeVolume(audioName, 0);
    }
}
