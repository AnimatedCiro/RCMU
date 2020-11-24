using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class endGameManager : MonoBehaviour
{

    public GameObject[] led;
    public bool ended;
    public Text testo;
    public GameObject panelMenu;
    public GameManagerScript gm;

    void Start(){
    }

    public void resetClientCall(){
        //Debug.Log("premo reset");
        gm.ResetPanelClient();
    }
    void OnCollisionEnter(Collision collision)
    {
        Thanos();
        testo.text = "Congratulazioni! Hai terminato la demo.";
        panelMenu.SetActive(true);
    }

    void Thanos()
    {
        StartCoroutine(SnapFinger());
    }

    public IEnumerator SnapFinger()
    {
        foreach(GameObject i in led){
            i.GetComponent<LedIntensityManager>().enableLed();
            yield return new WaitForSeconds(0.5f);
        }
        ended = true;
    }
}
