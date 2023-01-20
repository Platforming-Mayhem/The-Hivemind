using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyDoor : MonoBehaviour
{
    public GameObject keyO;
    public GameObject keyrequired;
    

    private bool keyC;

    private void Start()
    {
       
        keyrequired.SetActive(false);
    }

   
    private void OnTriggerEnter(Collider other)
    {
        //keyrequired.SetActive(true);
        if (Input.GetKey(KeyCode.E))
        {
            if (gameObject.tag == "Key")

            {
                keyC = true;
                Destroy(gameObject);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        //keyrequired.SetActive(false);
    }

 
}
