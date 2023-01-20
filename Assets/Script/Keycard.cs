using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keycard : MonoBehaviour
{

    
    public GameObject key;
    public bool destroyed = false;
    private void OnTriggerEnter(Collider other)
    {
        
                if (Input.GetKey(KeyCode.E))
                {
                    if (gameObject.tag == "Key")

                    {
                        
                        destroyed = true;
                    }
                }
    }
}
