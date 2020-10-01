using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GyroscopeManager : MonoBehaviour
{

    private bool state;
    public JustRotate circle1, circle2, circle3;
    // Start is called before the first frame update
    void Start()
    {
        state = false;   
    }

    public void Switch_Power(){
        state = !state;
        //ON
        if(state){
            PowerOn();
        }
        //OFF
        else{
            PowerOff();
        }
    }

    public void PowerOn(){
        state = true;
        circle1.RotationSpeed = 40f;
        circle2.RotationSpeed = 40f;
        circle3.RotationSpeed = 100f;

        Input.gyro.enabled = true;
    }

    public void PowerOff(){
        state = false;
        circle1.RotationSpeed = 0f;
        circle2.RotationSpeed = 0f;
        circle3.RotationSpeed = 0f;

        Input.gyro.enabled = false;
    }

    public bool getState(){
        return state;
    }
}
