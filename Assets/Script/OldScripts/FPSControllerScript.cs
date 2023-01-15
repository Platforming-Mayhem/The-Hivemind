using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class FPSControllerScript : MonoBehaviour
{
    public Transform rb;
    public AudioSource audioS;
    public AudioClip footStepSFX;
    public Light flashLight;
    public Text chargeText;
    public int chargeLevel = 100;
    public float sensitivity = 1.0f;
    public float speed = 1.0f;
    private float timer = 1.0f;

    void Start()
    {
        StartCoroutine(LoseCharge(6.0f, 1));
    }

    // Update is called once per frame
    void Update()
    {
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
        if (Input.GetAxis("Horizontal") != 0.0f || Input.GetAxis("Vertical") != 0.0f)
        {
            timer -= Time.deltaTime * 1.4f;
        }
        if(timer <= 0.0f)
        {
            audioS.PlayOneShot(footStepSFX);
            audioS.pitch = Random.Range(1.0f, 1.5f);
            timer = 1.0f;
        }
    }

    private void OnDisable()
    {
        PlayerPrefs.SetInt("charge", chargeLevel);
        PlayerPrefs.SetFloat("X", rb.position.x);
        PlayerPrefs.SetFloat("Y", rb.position.y);
        PlayerPrefs.SetFloat("Z", rb.position.z);
    }

    private void OnLevelWasLoaded(int level)
    {
        if (PlayerPrefs.HasKey("charge"))
        {
            chargeLevel = PlayerPrefs.GetInt("charge");
            chargeText.text = chargeLevel.ToString() + "%";
        }
        else
        {
            chargeLevel = 100;
            PlayerPrefs.SetInt("charge", chargeLevel);
            chargeText.text = chargeLevel.ToString() + "%";
        }
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            if (PlayerPrefs.HasKey("X"))
            {
                rb.position = new Vector3(PlayerPrefs.GetFloat("X"), PlayerPrefs.GetFloat("Y"), PlayerPrefs.GetFloat("Z"));
            }
        }
    }

    private void OnApplicationQuit()
    {
        PlayerPrefs.DeleteAll();
    }

    public IEnumerator FlickerOff()
    {
        flashLight.intensity = 0.0f;
        yield return new WaitForSeconds(0.4f);
        flashLight.intensity = 1.0f;
        yield return new WaitForSeconds(0.3f);
        flashLight.intensity = 0.0f;
        yield return new WaitForSeconds(0.4f);
        
    }

    public IEnumerator FlickerOn()
    {
        flashLight.intensity = 0.0f;
        yield return new WaitForSeconds(0.4f);
        flashLight.intensity = 1.0f;
        yield return new WaitForSeconds(0.3f);
        flashLight.intensity = 0.0f;
        yield return new WaitForSeconds(0.4f);
        flashLight.intensity = 1.0f;
    }

    IEnumerator LoseCharge(float time, int amount)
    {
        for (; ; )
        {
            yield return new WaitForSeconds(time);
            chargeLevel -= amount;
            chargeText.text = chargeLevel.ToString() + "%";
        }
    }
}
