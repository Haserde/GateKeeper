using UnityEngine;
using System.Collections;
[System.Serializable]

public class randomAnim : MonoBehaviour {

	public Animator anim;
	public string currentLevel;
	static bool steam = true;
	private string startAnim = "Steam";
	public PolygonCollider2D polyCol; 
	internal bool isAnimated {
		get { return anim.GetBool (startAnim); }
		set { anim.SetBool (startAnim, value); }
	}

	private void Awake(){
		anim = GetComponent<Animator> ();
	}
	private void Start(){
		
		StartCoroutine (playAnim (1f,5f));
	}

	void Update(){
		if (isAnimated == true) {
			polyCol.enabled = true;
		} else {
			polyCol.enabled = false;
		}
	}

	IEnumerator playAnim(float playTime, float waitTime){
		while (steam) {
			isAnimated = true;
			//polyCol.enabled = true;
			yield return new WaitForSeconds (playTime);
			isAnimated = false;
			//polyCol.enabled = false;
			yield return new WaitForSeconds (waitTime);
		}
	}
	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.tag == "Player") {
			Application.LoadLevel (currentLevel);
		}
	}
}

