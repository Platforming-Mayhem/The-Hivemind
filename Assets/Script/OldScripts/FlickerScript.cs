using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Save
{
    public static Vector3 position;
    public static Vector3 eulerAngle;
}

public class FlickerScript : MonoBehaviour
{
    public FPSControllerScript player;
    public Transform position;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    IEnumerator Flicker()
    {
        Save.position = player.rb.position;
        Save.eulerAngle = player.rb.eulerAngles;
        yield return new WaitForSeconds(1.1f);
        player.rb.position = position.position;
        player.rb.eulerAngles = position.eulerAngles;
    }

    private void OnEnable()
    {
        StartCoroutine(player.FlickerOff());
        StartCoroutine(Flicker());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
