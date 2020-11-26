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

    public Image EnergyBar;
    float timer = 0f;

    public Image[] blueprint;

    public GameObject brokenPanel;

    public bool broken;
    void Start()
    {
        broken = false;
        power = false;
        //joystickMovement = FindObjectOfType<Joystick>();
        gc = FindObjectOfType<GameManagerScript>();

        //buttonPower.onClick.AddListener(() => gc.accendiAstronave());
    }


    void Update()
    {
    if(broken){
        emptyEnergy();
    }
    if(power && !broken){
        timer += Time.deltaTime;
        if (timer >= 1f)
        {
            timer = 0f;
            gc.energy -= STG.maxSpeed;
            EnergyBar.fillAmount = gc.energy/1000;
            gc.Update_Energy(gc.energy);
            if(gc.energy <= 0){
                spegniTutto();
                emptyEnergy();
                gc.emptyEnergy();
            }
        }
    }
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
        if(gc.energy > 0){
            power = !power;
            if(power){
                gc.accendiAstronave();
                LightOn();
                UnlockInteractable();
                buttonPowerOff.gameObject.SetActive(true);
            }
            else{
                spegniTutto();
            }
        }
    }

    public void spegniTutto(){
        gc.spegniAstronave();
        STG.resetAllToggle();
        GyroM.PowerOff();
        LightOff();
        LockInteractable();
        buttonPowerOff.gameObject.SetActive(false);
    }

    public void emptyEnergy(){
        foreach(Image i in blueprint){
            Color c = new Color(i.color.r,i.color.g,i.color.b,0);
            i.color = Color.Lerp(i.color, c,  Mathf.PingPong(Time.time, 1));
        }
    }

    public void brokeScreen(){

        brokenPanel.SetActive(true);
        emptyEnergy();
        spegniTutto();
        
    }
    public void resetPanel(){
        power = false;
        gc = FindObjectOfType<GameManagerScript>();
        spegniTutto();
        EnergyBar.fillAmount = gc.energy/1000;
        foreach(Image i in blueprint){
            Color c = new Color(i.color.r,i.color.g,i.color.b,255);
            i.color = Color.Lerp(i.color, c,  Mathf.PingPong(Time.time, 1));
        }
        brokenPanel.SetActive(false);
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
