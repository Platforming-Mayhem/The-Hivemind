using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class FPSControllerScript : MonoBehaviour
{
    public Rigidbody rb;
    public AudioSource audioS;
    public AudioClip footStepSFX;
    public Light flashLight;
    public Text chargeText;
    public int chargeLevel = 100;
    public int changeLevel = 95;
    public float sensitivity = 1.0f;
    public float speed = 1.0f;
    private float timer = 1.0f;
    // Start is called before the first frame update
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
        transform.eulerAngles += new Vector3(Input.GetAxis("Mouse Y") * -sensitivity, Input.GetAxis("Mouse X") * sensitivity, 0.0f);
        if(Input.GetAxis("Horizontal") != 0.0f || Input.GetAxis("Vertical") != 0.0f)
        {
            timer -= Time.deltaTime * 1.4f;
        }
        if(timer <= 0.0f)
        {
            audioS.PlayOneShot(footStepSFX);
            audioS.pitch = Random.Range(1.0f, 1.5f);
            timer = 1.0f;
        }
        if(chargeLevel == changeLevel)
        {
            chargeLevel--;
            chargeText.text = chargeLevel.ToString() + "%";
            PlayerPrefs.SetInt("charge", chargeLevel);
            StartCoroutine(Flicker());
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            chargeLevel = 100;
        }
    }

    private void OnEnable()
    {
        if(PlayerPrefs.GetInt("charge") < 100 && PlayerPrefs.GetInt("charge") > 0)
        {
            chargeLevel = PlayerPrefs.GetInt("charge");
            chargeText.text = chargeLevel.ToString() + "%";
        }
        else
        {
            chargeLevel = 100;
            chargeText.text = chargeLevel.ToString() + "%";
        }
    }

    private void OnDisable()
    {
        PlayerPrefs.SetInt("charge", chargeLevel);
    }

    public IEnumerator Flicker()
    {
        flashLight.intensity = 0.0f;
        yield return new WaitForSeconds(0.4f);
        flashLight.intensity = 1.0f;
        yield return new WaitForSeconds(0.3f);
        flashLight.intensity = 0.0f;
        yield return new WaitForSeconds(0.4f);
        if ((SceneManager.sceneCountInBuildSettings - 1) > SceneManager.GetActiveScene().buildIndex)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else
        {
            SceneManager.LoadScene(0);
        }
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
