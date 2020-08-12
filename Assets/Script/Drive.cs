using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
//using Mirror;

public class Drive : MonoBehaviour
{
    public Text verticale, orizzontale;
    public Joystick joystick;
    public ButtonPressed button;
    public ButtonPressed comunicazione;
    [Header("Astronave")]
    public Spaceship spaceship;

    private bool entered;
    public float Horizontal;
    public float Vertical;

    public GameManagerScript gc;


    void Start()
    {
        /*if(isServer){
            this.gameObject.active=false;
        }*/
        joystick = FindObjectOfType<Joystick>();
        //spaceship = FindObjectOfType<Spaceship>();
        gc = FindObjectOfType<GameManagerScript>();
    }
    
    // Update is called once per frame
    void Update()
    {

        
        /*
        if (!isLocalPlayer){
            return;
        }*/
        

        if(button.pressed && !entered){
            entered=true;
            accensione();
        }

        if(!button.pressed)
            entered=false;

        if(comunicazione.pressed)
            inviaComunicazione();

       /* if(spaceship.power){
            analogico();
        }*/


        orizzontale.text = "Orizzontale : "+joystick.Horizontal;
        verticale.text = "Verticale : "+joystick.Vertical;
    }

    //[Command]
    void accensione(){
        gc.increase();
        //spaceship.Switch_Power();
        return;
    }

    
    //[Command]
    void analogico(){
        //spaceship.GetComponent<Spaceship>().Set_Movement(joystick.Vertical, joystick.Horizontal);
        return;
    }

    //[Command]
    void inviaComunicazione(){
        //spaceship.comunicazione();
        return;
    }
    
    
}
