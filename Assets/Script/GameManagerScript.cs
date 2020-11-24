using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Mirror;

public class GameManagerScript : NetworkBehaviour
{
    [SyncVar]
    public int Test42 = 0;

    [SyncVar]
    public float gmx = 0.0f, gmy = 0.0f, gmys = 0.0f;

    [SyncVar]
    public float energy = 1000;
    public Spaceship navicella;
    public Drive drive;
    public GameObject menu;

    public endGameManager end;

    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        initializeVariable();
        //Debug.Log("start here");
    }

    public void initializeVariable(){

        if (isServer)
        {
            //GameObject pannello = FindObjectOfType<Drive>().gameObject;
            drive.gameObject.SetActive(false);

            menu = FindObjectOfType<MenuManager>().gameObject;

            navicella = FindObjectOfType<Spaceship>();
            navicella.gm = this;

            end = FindObjectOfType<endGameManager>();
            end.gm = this;

        }
        if(isClient){

            menu = FindObjectOfType<MenuManager>().gameObject;
            SceneManager.LoadScene("Controller", LoadSceneMode.Single);
            drive = FindObjectOfType<Drive>();
            playerLoggedServer();
            playerLoggedClient();

        }
    }

    void playerLoggedClient(){
        menu.GetComponent<MenuManager>().playerLogged = true;
    }

    [Command]
    void playerLoggedServer(){
        menu.GetComponent<MenuManager>().playerLogged = true;
    }
    void OnClientConnect(){
        takeEnergy(-(1000-energy));
    }

    [ClientRpc]
    void SyncronizeEnergy(float energia)
    {
        this.energy = energia;
    }

    [ClientRpc]
    public void ResetPanelClient()
    {
        //Debug.Log("chiamata dal server");
        energy = 1000;
        SyncronizeEnergy(energy);
        drive.resetPanel();
    }
    public void takeEnergy(float amount){

        if(!isServer)
            return;

        energy += amount;
        if(energy > 1000)
            energy = 1000;
        if(energy < 0)
            energy = 0;
        SyncronizeEnergy(energy);

    }

    [ClientRpc]
    public void sincronizza(float amount)
    {
        this.energy = amount;
    }

    [Command]
    public void Update_Energy(float amount){
        if(isServer)
            energy = amount; 
    }

    [Command]
    public void Update_SpeedLevel(int i)
    {
        navicella.Set_SpeedLevel(i);
    }

    [Command]
    public void movimento(float x, float y)
    {
        navicella.Set_Movement(x, y);
    }

    [Command]
    public void movimento_Spotlight(float y)
    {
        navicella.Set_Spotlight(y);
    }

    [Command]
    public void movimento_Gyro(float x)
    {
        navicella.Set_Gyroscope(x);
    }

    [Command]
    public void accendiAstronave()
    {
        navicella.Switch_Power();
    }

    [Command]
    public void spegniAstronave()
    {
        navicella.Power_OFF();
    }

    [Command]
    public void TurnOFFSpotlight()
    {
        navicella.Spotlight_OFF();
    }

    [Command]
    public void TurnONSpotlight()
    {
        navicella.Spotlight_ON();
    }
}
