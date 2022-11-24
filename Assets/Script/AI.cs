using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour
{
    public Transform target; 
    public float within_range;
    public float speed;
    public int numberOfRays = 17;
    public float angle = 90;
    public float targetVelocity = 10.0f;
    public void Update()
    {
        
        float dist = Vector3.Distance(target.position, transform.position);
     
        if (dist <= within_range)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
        }


      
    }

    private void OnDrawGizmos()
    {
        for (int i = 0; i < numberOfRays; ++i)
        {
            var rotation = this.transform.rotation;
             
        }
    }



}
