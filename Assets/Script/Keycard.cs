using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keycard : MonoBehaviour
{

    
    public GameObject key;
    
    public MeshRenderer rend;

    public void Start()
    {
        rend = GetComponent<MeshRenderer>();
        rend.enabled = true;
    }
    public void OnTriggerEnter(Collider other)
    {
        if (Input.GetKey(KeyCode.E))
        {
            if(GameObject.FindWithTag("Player"))
            {
                Debug.Log("Works?");
                rend.enabled = false;
            }
            
            
        }
    }
}
