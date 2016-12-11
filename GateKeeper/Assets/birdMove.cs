using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class birdMove : MonoBehaviour {
	public Transform target;
	public Rigidbody2D rb;
	public float speed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		float step = speed * Time.deltaTime;
		transform.position = Vector3.MoveTowards (transform.position, target.position, step);
	}
}
