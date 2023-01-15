using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisappearOnSeenScript : MonoBehaviour
{
    public Camera cam;
    public float distance = 2.0f;
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        once = false;
        rb = GetComponent<Rigidbody>();
    }

    bool once = false;
    bool previousOnce;

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = transform.position - cam.transform.position;
        if (Vector3.Dot(cam.transform.forward, direction.normalized) >= 0.7f && direction.magnitude <= distance)
        {
            once = true;
        }
        if (once && !previousOnce)
        {
            rb.isKinematic = false;
            rb.AddForce(transform.up, ForceMode.Impulse);
        }
    }

    private void LateUpdate()
    {
        previousOnce = once;
    }
}
