using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spaceship : MonoBehaviour
{

    [Header("Components")]
    public GameObject leds;
    public Light spotlight;
    public Rigidbody rigidbody;
    public ParticleSystem engine1;
    public ParticleSystem engine2;
    public bool power;

    [Header("Movement")]
    public float maxSpeed = 10;
    public float vertical;
    public float horizontal;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = new Vector3(this.transform.position.x + horizontal * maxSpeed * Time.deltaTime,
                                               this.transform.position.y + vertical * maxSpeed * Time.deltaTime,
                                               0);
    }

    public void Switch_Power()
    {
        if (!power)
            StartCoroutine(Power_ON());
        else
            Power_OFF();
    }

    public IEnumerator Power_ON()
    {
        leds.active = true;
        yield return new WaitForSeconds(0.2f);
        leds.active = false;
        yield return new WaitForSeconds(0.3f);
        leds.active = true;
        yield return new WaitForSeconds(0.2f);
        leds.active = false;
        yield return new WaitForSeconds(0.3f);
        leds.active = true;
        yield return new WaitForSeconds(0.2f);
        spotlight.enabled = true;
        rigidbody.useGravity = false;
        engine1.Play();
        engine2.Play();
        power = true;
    }

    public void Power_OFF()
    {
        leds.active = false;
        spotlight.enabled = false;
        rigidbody.useGravity = true;
        engine1.Stop();
        engine2.Stop();
        power = false;
    }

    public void Spotlight_ON()
    {
        spotlight.enabled = true;
    }

    public void Spotlight_OFF()
    {
        spotlight.enabled = false;
    }

    public void Switch_Spotlight()
    {
        if (spotlight.enabled)
            Spotlight_OFF();
        else
            Spotlight_ON();
    }

    public void Set_Movement(float Horizontal, float Vertical)
    {
        if (power)
        {
            vertical = Vertical;
            horizontal = Horizontal;
        }
    }

    public void comunicazione()
    {
        Debug.Log("Stiamo comunicando");
    }
}
