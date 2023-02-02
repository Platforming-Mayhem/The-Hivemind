using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    public LayerMask interactibleMask;
    public string doorAnimation = "GateOpen";
    public string playerAnimation = "OpenGate";
    private Animator playerAnim;
    public Animator doorAnim;
    public AudioSource sfx;
    public GameObject pressKey;
    public BoxCollider box;
    public enum Types { once, loop};
    public Types types = Types.once;
    // Start is called before the first frame update
    void Start()
    {
        pressKey.SetActive(false);
        once = false;
        playerAnim = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
    }

    private RaycastHit hit;
    private bool once;
    private void OnTriggerStay(Collider other)
    {
        pressKey.SetActive(true);
    }
    // Update is called once per frame
    void Update()
    {
        if(Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, 1.0f, interactibleMask) && !hit.collider.isTrigger)
        {
            if(types == Types.once)
            {
                if (hit.collider.gameObject.GetHashCode() == gameObject.GetHashCode() && Input.GetButtonDown("Fire1") && !once)
                {
                    
                    if (!sfx.isPlaying)
                        sfx.Play();
                    doorAnim.Play(doorAnimation, -1, 0);
                    if (playerAnimation != "")
                    {
                        playerAnim.Play(playerAnimation, -1, 0);
                        
                    }
                    once = true;
                    pressKey.SetActive(false);
                    box.enabled = false;
                }
            }
            else
            {
                if (hit.collider.gameObject.GetHashCode() == gameObject.GetHashCode() && Input.GetButtonDown("Fire1"))
                {
                    if (!sfx.isPlaying)
                        sfx.Play();
                    doorAnim.Play(doorAnimation, -1, 0);
                    if (playerAnimation != "")
                    {
                        playerAnim.Play(playerAnimation, -1, 0);
                    }
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        pressKey.SetActive(false);
    }
}
