using UnityEngine;
using System.Collections;

public class colliderChange : MonoBehaviour {
	[SerializeField]
	private CircleCollider2D[] colliders;
	private int currentColliderIndex = 0;
	public string nextLevel;

	void Start(){
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.tag == "Player") {
			Application.LoadLevel(nextLevel);
		}
	}
	/*public void Update(int spriteNum){
		colliders[currentColliderIndex].enabled = false;
		currentColliderIndex = spriteNum;
		colliders[currentColliderIndex].enabled = true;
	}*/
}