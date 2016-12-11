using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class instantiateBird : MonoBehaviour {
	public GameObject birds;
	public float minTime = 2f;
	public float maxTime = 5f;
	bool isSpawning = false; 

	void Update(){
		if (!isSpawning) {
			isSpawning = true;
			StartCoroutine (spawnObj (birds, Random.Range (minTime, maxTime)));
		}
	}

	IEnumerator spawnObj(GameObject birds, float seconds){
		yield return new WaitForSeconds(seconds);
		Instantiate (birds, transform.position, transform.rotation);
		isSpawning = false;
	}
}
