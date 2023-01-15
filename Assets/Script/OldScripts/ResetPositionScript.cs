using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetPositionScript : MonoBehaviour
{
    public FPSControllerScript player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnEnable()
    {
        player.rb.position = Save.position;
        player.rb.eulerAngles = Save.eulerAngle;
        StartCoroutine(player.FlickerOn());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
