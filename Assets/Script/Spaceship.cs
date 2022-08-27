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
    public GameManagerScript gm;

    [Header("Movement")]
    public int speedLevel = 0;
    public float maxSpeed;

    public float currentSpeed;
    public float vertical;
    public float horizontal;
    public float vertical_Spotlight;

    public float gyroAngle = 0;

    public bool test = false;

    void Start()
    {
        checkGameManager();
        
    }

    public void checkGameManager(){

        gm = FindObjectOfType<GameManagerScript>();

        if(gm != null && !test){
            gm.gameObject.GetComponent<GameManagerScript>().initializeVariable();
            test = true;
        }
    }

    void OnClientConnect(){
        checkGameManager();
    }
    void Update()
    {
        Update_Position();
        Update_Spotlight();
        Update_MaxSpeed();
        Update_Gyroscope();
    }

    void OnCollisionStay(Collision collision){
        currentSpeed = 0;
    }
    void OnCollisionEnter(Collision collision)
    {
        //calcolo danni
        //velocità corrente * numero aleatorio 
        float damage = currentSpeed *3;
        //invio dei danni al lato client
        gm.takeEnergy(-damage);
        //riduzione della velocità
        currentSpeed = 0;
    }

    private void Update_Position(){

        
        //Se l'analogico si è mosso accelera
        if(Mathf.Abs(horizontal+vertical) != 0){
            //Accelera se puoi
            if(currentSpeed < maxSpeed)
                currentSpeed += speedLevel * Time.deltaTime;
            //Mantieni la velocità al massimo disponibile
            if(currentSpeed > maxSpeed)
                currentSpeed = maxSpeed;
        //Altrimenti decelera
        }else {
            currentSpeed = speedLevel * Time.deltaTime;
        }

        //Aggiorna la posizione a seconda dell'orientamento
        transform.position += transform.forward * horizontal * currentSpeed * Time.deltaTime;
        transform.position += transform.up * vertical * currentSpeed * Time.deltaTime;

       /* 
       this.transform.position = new Vector3(this.transform.position.x + Vector3.forward.x * horizontal * maxSpeed * Time.deltaTime,
                                                Vector3.forward.y + vertical * maxSpeed * Time.deltaTime,
                                                0);
                                                */
                                            
    }

    private void Update_Spotlight(){
        spotlight.gameObject.transform.Rotate(100*-vertical_Spotlight*Time.deltaTime, 0, 0);

        
        if(spotlight.gameObject.transform.rotation.x<-65){
            spotlight.gameObject.transform.Rotate(-65,0,0);
        }
        if(spotlight.gameObject.transform.rotation.x>160){
            spotlight.gameObject.transform.Rotate(160,0,0);
        }
    }

    public void Set_SpeedLevel(int level){
        speedLevel = level;
    }

    public void Update_MaxSpeed(){
        maxSpeed = speedLevel * 5;
    }

    public void Update_Gyroscope(){
        this.gameObject.transform.Rotate(-100*gyroAngle*Time.deltaTime,0,0);
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

    public void Set_Spotlight(float Vertical){
        if(power){
            vertical_Spotlight = Vertical;
        }
    }

    public void Set_Gyroscope(float angle){
        gyroAngle = angle;

    }

    public void comunicazione()
    {
        Debug.Log("Stiamo comunicando");
    }
}
