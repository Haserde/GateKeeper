using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraShake : MonoBehaviour {
	public float shakeAmount = 5f;
	public float shakeTime = 1.5f;

	bool isShaking = false;
	private Vector2 originalLocation; 

	void OnTriggerEnter2D(Collider2D other){
		StartCoroutine ("shakeScreen");
		print ("shake");
	}
	void Update(){
		if (isShaking) {
			transform.position = originalLocation + Random.insideUnitCircle * shakeAmount * Time.deltaTime;
		}
	}

	IEnumerator shakeScreen(){
		isShaking = true;
		originalLocation = transform.position;
		yield return new WaitForSeconds (shakeTime);
		isShaking = false;
	}
}