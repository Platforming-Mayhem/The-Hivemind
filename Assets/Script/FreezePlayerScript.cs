using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezePlayerScript : MonoBehaviour
{
    public RePositionScript player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnEnable()
    {
        player.Freeze();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
