using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{

    public GameObject up,down;
    Vector3 targetUp, targetDown;

    public Vector3 opensize;

    public float speed,t=0f;

    public void OpenDoor(){
        speed = 1;
    }

    public void CloseDoor(){
        speed = -1;
    }

    // Start is called before the first frame update
    void Start()
    {
        speed = 0;
        targetUp = new Vector3(up.transform.position.x + opensize.x, up.transform.position.y + opensize.y, up.transform.position.z + opensize.z);
        targetDown = new Vector3(up.transform.position.x - opensize.x, up.transform.position.y - opensize.y, up.transform.position.z - opensize.z);
        
    }

    // Update is called once per frame
    void Update()
    {
        if(speed !=0){
            t+=speed * Time.deltaTime;
            up.gameObject.transform.position = Vector3.Lerp (transform.position, targetUp, t);
            down.gameObject.transform.position = Vector3.Lerp (transform.position, targetDown, t);
            if(t>1 || t<-1){
                speed = 0;
                t = 0;
            }
        }
    }
}
