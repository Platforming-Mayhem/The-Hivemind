using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour
{
    public Transform target; 
    public float within_range;
    public float speed;
    /*public GameObject player;
    private new Camera camera;
    private new Renderer renderer;
    */
    private void Start()
    {
       /* player = GameObject.FindGameObjectWithTag("Player");
        camera = Camera.main;
        renderer = GetComponent<Renderer>();*/
    }
    private void OnBecameVisible()
    {
      
    }
    public void Update()
    {
       /* bool isVisible = GeometryUtility.TestPlanesAABB(
        GeometryUtility.CalculateFrustumPlanes(camera),
        renderer.bounds);

        if (!isVisible)
        {
            TryMovingTowardsPlayer();
        }
        */
       float dist = Vector3.Distance(target.position, transform.position);
     
        if (dist <= within_range)
        {

            
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
        }

             



      
    }

    /*private void TryMovingTowardsPlayer()
    {
        if (player == null)
            return;

        transform.position = player.transform.position - player.transform.forward;
        Vector3 lookPos = player.transform.position - transform.position;
        lookPos.y = 0;
        transform.rotation = Quaternion.LookRotation(lookPos);
    }
    */










}
