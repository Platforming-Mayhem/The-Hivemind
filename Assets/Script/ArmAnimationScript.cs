using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmAnimationScript : MonoBehaviour
{
    Animator anim;
    Vector3 previousPosition;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 offset = transform.parent.position - previousPosition;
        if(offset.x != 0.0f || offset.z != 0.0f)
        {
            anim.SetBool("isMoving", true);
        }
        else if(offset.x == 0.0f && offset.z == 0.0f)
        {
            anim.SetBool("isMoving", false);
        }
    }

    private void LateUpdate()
    {
        previousPosition = transform.position;
    }
}
