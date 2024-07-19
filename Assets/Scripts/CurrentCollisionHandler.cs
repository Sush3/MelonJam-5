using UnityEngine;

public class CurrentCollisionHandler : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField]
    private float strength = 1;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void Hit(Vector3 pos, Vector3 dir)
    {
        rb.AddForceAtPosition(dir * strength, pos);
    }
}