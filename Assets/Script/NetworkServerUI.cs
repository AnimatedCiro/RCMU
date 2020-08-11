using System;
using System.Net;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Networking.NetworkSystem;

public class NetworkServerUI : MonoBehaviour
{
     NetworkIdentity m_Identity;
    void OnGUI()
    {
        string ipv4 = IPManager.GetIP(ADDRESSFAM.IPv4);
        GUI.Label(new Rect(10,Screen.height -50, 1000 ,200), ipv4);
        GUI.Label(new Rect(20,Screen.height -35, 1000 ,200), "Status:" + NetworkServer.active);
        GUI.Label(new Rect(20,Screen.height -20, 1000 ,200), "Connected:" + NetworkServer.connections.Count);
    }

    void Start()
    {
        NetworkServer.Listen(25000);
    }

    // Update is called once per frame
    void Update()
    {
        
    } 
}
