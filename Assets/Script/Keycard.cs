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
    public GameObject pressKey;

    public void Start()
    {
        pressKey.SetActive(false);
        player = FindObjectOfType<PlayerScript>();
        GetComponent<BoxCollider>().enabled = true;
        hasKeycard = false;
    }
    public void OnTriggerStay(Collider other)
    {
        pressKey.SetActive(true);
        if (Input.GetButtonDown("Fire1") && !player.anim.GetCurrentAnimatorStateInfo(0).IsName("Pickup"))
        {
            pressKey.SetActive(false);
            player.anim.SetTrigger("pickUp");
            player.GetComponentInParent<RePositionScript>().target = point;
            transform.SetParent(parent);
            transform.localPosition = Vector3.zero;
            door.enabled = true;
            GetComponent<BoxCollider>().enabled = false;
            hasKeycard = true;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        pressKey.SetActive(false);
    }
}
