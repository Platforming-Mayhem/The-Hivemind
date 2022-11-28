using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowRotationScript : MonoBehaviour
{
    public Transform target;
    public Vector3 direction = new Vector3(0.0f, 0.0f, 0.0f);
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.eulerAngles = Vector3.Scale(target.eulerAngles, direction) + Vector3.Scale(transform.eulerAngles, Vector3.one - direction);
    }
}
