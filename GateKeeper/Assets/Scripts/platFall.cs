﻿using UnityEngine;
using System.Collections;

public class platFall : MonoBehaviour {

	public Rigidbody2D rb;
	public float fallDelay;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
	
	}
	
	// Update is called once per frame
	void OnCollisionEnter2D(Collision2D other){
		if (other.gameObject.tag == "Player") {
			StartCoroutine(fall());
		}
	}

	IEnumerator fall(){
		yield return new WaitForSeconds (fallDelay);
		rb.isKinematic = false;
		yield return 0;
	}
}

