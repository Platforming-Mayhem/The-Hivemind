using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class InteractibleScript : MonoBehaviour
{
    public string information;
    public float distance = 2.0f;
    public Text informationText;
    public Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = transform.position - cam.transform.position;
        if (Vector3.Dot(cam.transform.forward, direction.normalized) >= 0.94f && direction.magnitude <= distance)
        {
            if (Input.GetKey(KeyCode.E))
            {
                informationText.text = information;
            }
        }
        else
        {
            informationText.text = "";
        }
    }
}
