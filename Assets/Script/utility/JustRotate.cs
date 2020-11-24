using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JustRotate : MonoBehaviour {

	public float RotationSpeed = 15f;

	[Tooltip("1 per senso orario e -1 per antiorario")]
	public int direzione = 1;

 
	void Update () {
		transform.Rotate(RotationSpeed*direzione*Vector3.forward*Time.deltaTime);
	}
}
