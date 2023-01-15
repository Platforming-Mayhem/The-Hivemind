using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerFlickerScript : MonoBehaviour
{
    public FPSControllerScript player;
    public Light spotLight;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(Flicker());
            StartCoroutine(player.FlickerOff());
        }
    }

    IEnumerator Flicker()
    {
        spotLight.intensity = 0.0f;
        yield return new WaitForSeconds(0.4f);
        spotLight.intensity = 1.0f;
        yield return new WaitForSeconds(0.3f);
        spotLight.intensity = 0.0f;
    }
}
