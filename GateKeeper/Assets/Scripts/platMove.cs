using UnityEngine;
using System.Collections;

public class platMove : MonoBehaviour {
	public Vector3 pos1;
	public Vector3 pos2;
	public float speed = 1f;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = Vector3.Lerp (pos1, pos2, Mathf.PingPong (Time.time * speed, 1f));
	
	}
}
