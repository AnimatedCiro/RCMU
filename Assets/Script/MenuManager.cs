using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class MenuManager : MonoBehaviour
{
    public bool DontDestroyOnLoad;
    public GameObject loadingMenu;
    public bool playerLogged;
    public bool waitingPlayer;
    void Awake()
    {
        playerLogged = false;
        GameObject objs = this.GetComponent<GameObject>();

        if (!DontDestroyOnLoad)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }

    public void enableWait(){
        waitingPlayer = true;
    }
    public void disableWait(){
        waitingPlayer = false;
    }


    void Update(){
        if(waitingPlayer){
            if(playerLogged){
                loadingMenu.SetActive(false);
            }
            else
                loadingMenu.SetActive(true);
        }
    }
}
