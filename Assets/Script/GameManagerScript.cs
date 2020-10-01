using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class GameManagerScript : NetworkBehaviour
{
    [SyncVar]
    public int Test42 = 0;

    [SyncVar]
    public float gmx = 0.0f, gmy = 0.0f, gmys = 0.0f;

    public Spaceship navicella;

    void Start()
    {
        if (isServer)
        {
            GameObject panello = FindObjectOfType<Drive>().gameObject;
            Destroy(panello);

            navicella = FindObjectOfType<Spaceship>();
        }

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
