using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyDoor : MonoBehaviour
{
    public GameObject keyrequired;


    
    private bool ifDestroyed;
    private float timerC = 5.0f;

    private void Start()
    {
        
        keyrequired.SetActive(false);
    }

   
    private void OnTriggerEnter(Collider other)
    {
        
        if (Input.GetMouseButton(1))
        {
            Keycard keyCardS = GameObject.Find("KeyCard").GetComponent<Keycard>();
            keyCardS.destroyed = false;
            keyrequired.SetActive(true);
            if (keyrequired == true)
            {
                
                timerC = timerC - Time.deltaTime;
                if(timerC == 0)
                {
                    keyrequired.SetActive(false);
                }
            }
            
        }
        else
        {
            
            Destroy(gameObject);
        }
    }
    
    void update()
    {

    }


    private void OnTriggerExit(Collider other)
    {
        //keyrequired.SetActive(false);
    }

 
}
