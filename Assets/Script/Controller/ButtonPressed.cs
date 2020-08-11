using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonPressed : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{

    public bool pressed;

    public void OnPointerDown(PointerEventData eventData)
    {
        pressed = true;
        Debug.Log("pressed");
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        pressed = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        pressed = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
