using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyDoor : MonoBehaviour
{
    public Keycard keycard;
    public GameObject keyrequired;
    public Transform point;
    public DoorScript door;
    private Animator anim;

    private void Start()
    {
        anim = GetComponentInParent<Animator>();
        keyrequired.SetActive(false);
    }

   
    public void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (Input.GetButtonDown("Fire1"))
            {
                if (!keycard.hasKeycard)
                {
                    keyrequired.SetActive(true);
                    door.enabled = false;
                }
                else
                {
                    keyrequired.SetActive(false);
                    door.enabled = true;
                    keycard.transform.localEulerAngles = new Vector3(0.0f, 90.0f, 0.0f);
                    FindObjectOfType<RePositionScript>().target = point;
                }
            }
        }
    }


    private void OnTriggerExit(Collider other)
    {
        keyrequired.SetActive(false);
    }
}
