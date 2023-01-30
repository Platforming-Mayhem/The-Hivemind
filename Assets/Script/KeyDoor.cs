using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyDoor : MonoBehaviour
{
    public GameObject keyrequired;
    public GameObject keyDoorD;
    private bool ifDestroyed;
    private float timerC = 5.0f;

    private void Start()
    {

        keyrequired.SetActive(false);
    }

   
    public void OnTriggerEnter(Collider other)
    {
        Keycard keyCardS = GameObject.Find("KeyCard").GetComponent<Keycard>();
        
        if (Input.GetMouseButton(1) && keyCardS.)
        {
            Debug.Log("Maybe");
            
            
            keyrequired.SetActive(true);
            timerC = timerC - Time.deltaTime;
            if (timerC == 0)
            {
                Debug.Log("Time" + timerC);
                keyrequired.SetActive(false);
            }
                
            

            
        }
    }
    
    void update()
    {

    }


    private void OnTriggerExit(Collider other)
    {
        keyrequired.SetActive(false);
    }

 
}
