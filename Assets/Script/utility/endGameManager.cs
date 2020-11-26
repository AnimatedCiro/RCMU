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
        gm.energy = 1000;
        gm.ResetPanelClient();

    }
    void OnCollisionEnter(Collision collision)
    {
        Thanos();
        setPharse("Congratulazioni! Hai terminato la demo.");
        activePanel();
    }

    public void emptyEnergy(){
        setPharse("Game Over! Hai terminato l' energia.");
        activePanel();
    }

    public void brokeEnergy(){
        setPharse("Game Over! Hai preso troppi danni.");
        activePanel();
    }

    void setPharse(string text){
        testo.text = text;
    }

    void activePanel(){
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
