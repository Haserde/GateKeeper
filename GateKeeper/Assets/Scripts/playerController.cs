using UnityEngine;
using System.Collections;

public class playerController : MonoBehaviour {

	public float moveSpeed = 10f;
	public float jumpHeight = 20f;
	public float dashSpeed = 100f;
	public bool doubleJump = false; 
	public bool grounded;
	public AudioClip jump;
	public GameObject ow;

	public Transform groundCheck;
	public LayerMask whatIsGround;

	private float xSpeed;
	private Animator anim; 
	private SpriteRenderer sr;
	private AudioSource audio;
	private Rigidbody2D rb; 
	private int jumpCount = 0;
	private int maxJump = 1;



	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
		sr = GetComponent<SpriteRenderer> ();
		audio = GetComponent<AudioSource> ();
	}

	void Update () {

		if (Input.GetButtonDown ("Jump") && jumpCount > 0) {
			print (jumpCount);
			rb.velocity = new Vector2 (rb.velocity.x, 0);
			rb.AddForce (new Vector2 (0, jumpHeight));
			jumpCount--;
			audio.PlayOneShot (jump);
		}
	}

	void OnCollisionEnter2D(Collision2D other){
		if (other.gameObject.tag == "Platform") {
			jumpCount = 2;
			print ("walljump");
		}
		if (other.gameObject.tag == "Apple") {
			ow.SetActive (true);
		} else {
			ow.SetActive (false);
		}
	}

	void OnTriggerStay2D(Collider2D other){
		if (other.gameObject.tag == "MovingPlat") {
			transform.parent = other.transform;
		}
	}

	void OnTriggerExit2D(Collider2D other){
		if (other.gameObject.tag == "MovingPlat") {
			transform.parent = null;
		}
	}

		
	void FixedUpdate () {

		xSpeed = Input.GetAxisRaw ("Horizontal") * moveSpeed;
		rb.velocity = new Vector2 (xSpeed, rb.velocity.y);

		sr.flipX = xSpeed  < 0;

		if (xSpeed != 0 || xSpeed != 0) {
			anim.SetBool ("Walk", true);
		} else {
			anim.SetBool ("Walk", false);
		}

		grounded = Physics2D.OverlapCircle (groundCheck.position, 0.3f, whatIsGround);

		//print (grounded);

		if (grounded) {
			anim.SetBool ("Jump", false);
			anim.SetBool ("DoubleJump", false);
			jumpCount = maxJump;
		} else {
			if (jumpCount == maxJump) {
				anim.SetBool ("Jump", true);
			} else {
				anim.SetBool ("DoubleJump", true);
			}
		}
	}
}
