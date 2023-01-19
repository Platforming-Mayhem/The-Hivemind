using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyDoor : MonoBehaviour
{
    public GameObject key;
    public GameObject keyrequired;
    public TextMesh textKey;

    private void Start()
    {
        keyrequired.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        keyrequired.SetActive(true);

        if(Input.GetKeyDown(KeyCode.E))
        {
            
        }
    }

    private void OnTriggerExit(Collider other)
    {
        keyrequired.SetActive(false);
    }


}
