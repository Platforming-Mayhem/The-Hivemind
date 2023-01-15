using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public Transform rb;
    public float sensitivity = 1.0f;
    public float speed = 1.0f;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponentInParent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetFloat("X", Input.GetAxis("Horizontal"));
        anim.SetFloat("Y", Input.GetAxis("Vertical"));
        rb.position += Vector3.Scale(transform.rotation * new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical")), Vector3.one - Vector3.up).normalized * speed * Time.deltaTime;
        if (transform.eulerAngles.x >= 60f && transform.eulerAngles.x > 0f && transform.eulerAngles.x < 270f)
        {
            transform.eulerAngles = new Vector3(60f, transform.eulerAngles.y, transform.eulerAngles.z);
        }
        else if (transform.eulerAngles.x <= 300f && transform.eulerAngles.x < 360f && transform.eulerAngles.x > 90f)
        {
            transform.eulerAngles = new Vector3(300f, transform.eulerAngles.y, transform.eulerAngles.z);
        }
        rb.eulerAngles += new Vector3(0.0f, Input.GetAxis("Mouse X") * sensitivity, 0.0f);
        transform.eulerAngles += Vector3.right * Input.GetAxis("Mouse Y") * -sensitivity;
    }
}
