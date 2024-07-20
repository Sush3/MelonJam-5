using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayScript : MonoBehaviour
{
    [SerializeField]
    CinemachineVirtualCamera camera;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)||Input.GetMouseButtonDown(0))
        {
            OnPlayClick();
        }
    }
    // Update is called once per frame
    public void OnPlayClick()
    {
        Time.timeScale = 1;
        camera.Priority = -1;
        Destroy(gameObject);
    }
}
