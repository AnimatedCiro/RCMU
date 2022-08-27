using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GlobeManager : MonoBehaviour
{

    public GameObject Door;
    public GameObject Explosion;
    public GameObject Pivot;
    public GameObject Camera;
    GameObject myExplosion;
    GameManagerScript gm;

    endGameManager end;



    void OnTriggerEnter(Collider coll)
    {
        Pivot.SetActive(false);
        this.gameObject.GetComponent<SphereCollider>().enabled = false;
        myExplosion = Instantiate(Explosion, this.gameObject.transform);
        if(Door != null)
            Door.GetComponent<DoorController>().OpenDoor();
        Camera.GetComponent<CameraShake>().shakeDuration = 1;
        GameObject other = coll.gameObject;
         if (other.CompareTag("Player"))
         {
             other.GetComponent<Spaceship>().gm.takeEnergy(250f);
         }
    }
    

    void OnCollisionEnter(Collision collision)
    {
        //scompari dalla scena
        Pivot.SetActive(false);
        this.gameObject.GetComponent<SphereCollider>().enabled = false;
        //crea scoppio
        myExplosion = Instantiate(Explosion, this.gameObject.transform);
        //apri porta
        if(Door != null)
            Door.GetComponent<DoorController>().OpenDoor();
        //trema telecamera
        Camera.GetComponent<CameraShake>().shakeDuration = 1;
        //ricaricare energia astronave, 25%
        GameObject other = collision.gameObject;
         if (other.CompareTag("Player"))
         {
             other.GetComponent<Spaceship>().gm.takeEnergy(250f);
         }
    }

    void Start(){
        end = gameObject.GetComponent<endGameManager>();
    }

    void Update()
    {
        if(!Pivot.activeSelf && myExplosion.Equals(null)){
            if(end != null && end.ended){
                Destroy(this.gameObject);
            }
            else if (end == null)
                //distruggiti
                Destroy(this.gameObject);
        }
    }
}
