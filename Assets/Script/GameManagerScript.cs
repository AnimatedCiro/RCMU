using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class GameManagerScript : NetworkBehaviour
{
    [SyncVar]
    public int Test42 = 0;

    public GameObject navicella;
    // Start is called before the first frame update
    void Start()
    {
        if(isServer){
            GameObject panello = FindObjectOfType<Drive>().gameObject;
            Destroy(panello);

            navicella = FindObjectOfType<Spaceship>().gameObject;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    

    [Command]
    public void increase(){
        Test42++;
        return;
    }
}
