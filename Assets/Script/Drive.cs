using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
//using Mirror;

public class Drive : MonoBehaviour
{
    public Joystick joystickMovement;
    public Joystick joystickLight;

    public float x,y;
    //public ButtonPressed button;
    public Button spotlightButtonON;
    public Button spotlightButtonOFF;
    public Button buttonPowerOn;
    public Button buttonPowerOff;
    public bool power;
    public GameManagerScript gc;
    public speedToggleGroup STG;
    public Button speedPanel;
    public GyroscopeManager GyroM;


    void Start()
    {
        power = false;
        //joystickMovement = FindObjectOfType<Joystick>();
        gc = FindObjectOfType<GameManagerScript>();

        //buttonPower.onClick.AddListener(() => gc.accendiAstronave());
    }

    // Update is called once per frame
    void Update()
    {
        /* if (button.pressed && !entered)
        {
            entered = true;
            gc.accendiAstronave();
        }

        if (!button.pressed)
        {
            entered = false;
        } */
        if(GyroM.getState()){
            gc.movimento_Gyro(Input.gyro.attitude.x);
        }
        else{
            gc.movimento_Gyro(0);
        }

        gc.movimento(joystickMovement.Horizontal, joystickMovement.Vertical);
        gc.movimento_Spotlight(joystickLight.Vertical);

    }

    public void Send_Speed_Level(int i){
        gc.Update_SpeedLevel(i);
    }
    public void LightOn(){
        gc.TurnONSpotlight();
        spotlightButtonOFF.gameObject.SetActive(true);
        spotlightButtonON.gameObject.SetActive(false);
    }
    public void LightOff(){
        gc.TurnOFFSpotlight();
        spotlightButtonOFF.gameObject.SetActive(false);
        spotlightButtonON.gameObject.SetActive(true);
    }
    public void SpaceshipPowerManager(){
        power = !power;
        if(power){
            gc.accendiAstronave();
            LightOn();
            UnlockInteractable();
            buttonPowerOff.gameObject.SetActive(true);
        }
        else{
            gc.spegniAstronave();
            STG.resetAllToggle();
            GyroM.PowerOff();
            LightOff();
            LockInteractable();
            buttonPowerOff.gameObject.SetActive(false);
        }
    }

    public void LockInteractable(){
        GyroM.gameObject.GetComponent<Button>().interactable = false;
        speedPanel.interactable = false;
        spotlightButtonOFF.interactable = false;
        spotlightButtonON.interactable = false;
    }

    public void UnlockInteractable(){
        GyroM.gameObject.GetComponent<Button>().interactable = true;
        speedPanel.interactable = true;
        spotlightButtonOFF.interactable = true;
        spotlightButtonON.interactable = true;
    }
    
    void GyroModify()
    {
        Transform t =  new GameObject().transform;
        t.rotation = GyroToUnity(Input.gyro.attitude);
    }

    private static Quaternion GyroToUnity(Quaternion q)
    {
        return new Quaternion(q.x, q.y, -q.z, -q.w);
    }
    
}
