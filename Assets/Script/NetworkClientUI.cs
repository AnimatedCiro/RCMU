using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Networking.NetworkSystem;

public class NetworkClientUI : MonoBehaviour
{

    NetworkClient client;
    void OnGUI()
    {
        string ipv4 = IPManager.GetIP(ADDRESSFAM.IPv4);
        GUI.Label(new Rect(10,Screen.height -50, 100 ,200), "IPv4:" + ipv4);
        GUI.Label(new Rect(20,Screen.height -35, 100 ,200), "Status:" + client.isConnected);

        if(!client.isConnected){
            if(GUI.Button(new Rect(10,10,60,50), "Connected")){
                Connect();
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        client = new NetworkClient();
    }

    void Connect(){
        client.Connect("192.168.1.185", 25000);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
