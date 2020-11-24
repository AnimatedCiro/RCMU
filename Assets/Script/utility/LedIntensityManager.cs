using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LedIntensityManager : MonoBehaviour
{
    

    public Material m;
    public Color startColor;
    public Color targetColor;

    public Color currentColor;

    void Start()
    {
        m = GetComponent<Renderer>().material;
        m.SetColor("_EmissionColor", startColor);
    }

    public void enableLed()
    {
        m.EnableKeyword("_EMISSION");
    }
    void Update()
    {
        if(currentColor == targetColor){
            targetColor = startColor;
            startColor = currentColor;
        }
        currentColor = Color.Lerp(startColor, targetColor,  Mathf.PingPong(Time.time, 1));
        m.SetColor("_EmissionColor", currentColor);
    }
}
