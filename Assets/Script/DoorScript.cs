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
    public enum Types { once, loop};
    public Types types = Types.once;
    // Start is called before the first frame update
    void Start()
    {
        once = false;
        playerAnim = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
    }

    private RaycastHit hit;
    private bool once;

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
}
