using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class FlagScript : MonoBehaviour
{
    [SerializeField]
    int nextSceneIndex;
    [SerializeField]
    Transform trailer;
    [SerializeField]
    float winDist;
    bool Won=false;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, trailer.position) < winDist&&!Won)
        {
            Won=true;
            AudioManager.Instance.Play("Win");
            StartCoroutine(Win());
        }
    }
    IEnumerator Win()
    {
        yield return new WaitForSeconds(5.97f);
        SceneManager.LoadScene(nextSceneIndex);
    }
}
