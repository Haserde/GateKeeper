using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class killZone : MonoBehaviour {

	// Use this for initialization
	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.tag == "MovingPlat") {
			Destroy (other.gameObject);
		}
	}
}
