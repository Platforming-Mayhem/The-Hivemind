using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmAnimationScript : MonoBehaviour
{
    Animator anim;
    Vector3 previousPosition;
    public Transform target;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log((target.position - previousPosition).magnitude);
        if((target.position - previousPosition).magnitude >= Time.deltaTime)
        {
            anim.SetBool("isMoving", true);
        }
        else
        {
            anim.SetBool("isMoving", false);
        }
        previousPosition = target.position;
    }

    private void LateUpdate()
    {
        
    }
}
