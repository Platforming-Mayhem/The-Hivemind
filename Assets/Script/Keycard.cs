using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keycard : MonoBehaviour
{
    private PlayerScript player;
    public Transform parent;
    public Transform point;

    public void Start()
    {
        player = FindObjectOfType<PlayerScript>();
        GetComponent<BoxCollider>().enabled = true;
    }
    public void OnTriggerStay(Collider other)
    {
        if (Input.GetButtonDown("Fire1") && !player.anim.GetCurrentAnimatorStateInfo(0).IsName("Pickup"))
        {
            transform.SetParent(parent);
            transform.localPosition = Vector3.zero;
            activated = GetComponent<BoxCollider>().enabled = false;
            player.anim.SetTrigger("pickUp");
            player.GetComponentInParent<RePositionScript>().target = point;
        }
    }
}
