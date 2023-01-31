using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keycard : MonoBehaviour
{
    private PlayerScript player;
    public bool hasKeycard;
    public KeyDoor door;
    public Transform parent;
    public Transform point;

    public void Start()
    {
        player = FindObjectOfType<PlayerScript>();
        GetComponent<BoxCollider>().enabled = true;
        hasKeycard = false;
    }
    public void OnTriggerStay(Collider other)
    {
        if (Input.GetButtonDown("Fire1") && !player.anim.GetCurrentAnimatorStateInfo(0).IsName("Pickup"))
        {
            player.anim.SetTrigger("pickUp");
            player.GetComponentInParent<RePositionScript>().target = point;
            transform.SetParent(parent);
            transform.localPosition = Vector3.zero;
            door.enabled = true;
            GetComponent<BoxCollider>().enabled = false;
            hasKeycard = true;
        }
    }
}
