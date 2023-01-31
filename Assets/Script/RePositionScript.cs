using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RePositionScript : MonoBehaviour
{
    public Transform spine;
    public Transform target;
    public PlayerScript player;

    private Rigidbody rb;

    public void Freeze()
    {
        transform.position = target.position;
        transform.rotation = target.rotation;
        player.transform.localEulerAngles = Vector3.zero;
        rb = player.rb.GetComponent<Rigidbody>();
        rb.isKinematic = true;
        player.isFrozen = true;
    }

    public void UnFreeze()
    {
        transform.position = new Vector3(spine.position.x, transform.position.y, spine.position.z);
        transform.eulerAngles = new Vector3(0.0f, spine.eulerAngles.y + 180.0f, 0.0f);
        rb.isKinematic = false;
        player.isFrozen = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
