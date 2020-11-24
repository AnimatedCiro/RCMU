using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SizeOvertimeAndExplode : MonoBehaviour
{
    public int startSize = 1;
     public int minSize = 1;
     public int maxSize = 100;
     
     public float speed = 2.0f;
     
     private Vector3 targetScale;
     private Vector3 baseScale;
     private int currScale;
     
     void Start() {
         baseScale = transform.localScale;
         transform.localScale = baseScale * startSize;
         currScale = startSize;
         targetScale = baseScale * maxSize;
     }
     
     void Update() {
        this.gameObject.transform.localScale = Vector3.Lerp (transform.localScale, targetScale, speed * Time.deltaTime);
        if(transform.localScale.x >= targetScale.x-1)
            Destroy(this.gameObject);
    }
}
