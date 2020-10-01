using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class speedToggleGroup : MonoBehaviour
{

    public List<Toggle> check, cloneCheck;
    public List<bool> oldStat;
    public Drive drive;

    public int maxSpeed = 0;

    public void changedIsOn(int i){
        resetAllToggle();
        
        for(int j=0; j<=i; j++){
            check[j].GetComponent<Image>().color = check[j].colors.pressedColor;
            cloneCheck[j].isOn = true;
        }
        maxSpeed = i+1;
        if(drive.power)
            drive.Send_Speed_Level(maxSpeed);
        else
            drive.Send_Speed_Level(0);
    }

    public void resetAllToggle(){
        foreach (Toggle t in check){
            t.isOn = false;
            t.GetComponent<Image>().color = t.colors.disabledColor;
        }

        foreach (Toggle t in cloneCheck)
            t.isOn = false;
        
        maxSpeed = 0;
    }
}
