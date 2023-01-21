using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keycard : MonoBehaviour
{

    
    public GameObject key;
    public bool destroyed;

    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKey(KeyCode.E))
        {
            if (other.CompareTag("Player"))
            {
                destroyed = true;
            }
        }
    }
}
