using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Triggeroutsidecloset : MonoBehaviour
{
    public GameObject Trigger;
    public GameObject director;

    private void Start()
    {
        director.SetActive(false);
    }
    private void OnTriggerEnter(Collider collision)
    {
        director.SetActive(true);
    }
}
