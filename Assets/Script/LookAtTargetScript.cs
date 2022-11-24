using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtTargetScript : MonoBehaviour
{
    public Transform target;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 offset = Vector3.Scale(transform.position - target.position, Vector3.one - Vector3.up).normalized;
        float angle = Mathf.Atan2(offset.z, -offset.x) * Mathf.Rad2Deg + 90.0f;
        transform.eulerAngles = new Vector3(0.0f, angle, 0.0f);
    }
}
