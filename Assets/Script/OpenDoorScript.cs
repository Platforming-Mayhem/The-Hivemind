using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoorScript : MonoBehaviour
{
    public float doorType = 0.0f;
    public float waitTime = 1.0f;
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(waitTime <= 0.0f)
        {
            anim.enabled = true;
            anim.SetFloat("door", doorType);
        }
        else
        {
            waitTime -= Time.deltaTime;
            anim.enabled = false;
        }
    }
}
