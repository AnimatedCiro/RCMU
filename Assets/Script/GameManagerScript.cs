using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class GameManagerScript : NetworkBehaviour
{
    [SyncVar]
    public int Test42 = 0;

    [SyncVar]
    public float gmx = 0.0f, gmy = 0.0f;

    public Spaceship navicella;
    // Start is called before the first frame update
    void Start()
    {
        if (isServer)
        {
            GameObject panello = FindObjectOfType<Drive>().gameObject;
            Destroy(panello);

            navicella = FindObjectOfType<Spaceship>();
        }

    }

    // Update is called once per frame
    void Update()
    {

    }

    [Command]
    public void movimento(float x, float y)
    {
        navicella.Set_Movement(x, y);
    }

    [Command]
    public void accendiAstronave()
    {
        navicella.Switch_Power();
    }
}
