using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	public float speed = 5f;

	private Rigidbody2D myBody;
	private Animator anim;

	public Transform groundCheckPosition;
	public LayerMask groundLayer;

	private bool isGrounded;
	private bool jumped;

	private float jumpPower = 12f;

	void Awake() {
		myBody = GetComponent<Rigidbody2D>(); // FIX: was 'myBody.GetComponent<>()' which never assigned myBody (null ref -> player couldn't move)
		anim = GetComponent<Animator> ();
	}

	void Start () {
		
	}

	void Update () {
		// FIX: Update() was empty - now we check grounded + listen for the jump every frame
		CheckIfGrounded ();
		PlayerJump ();
	}

	void FixedUpdate() {
		PlayerWalk ();
	}

	void PlayerWalk() {

		float h = Input.GetAxis("Horizontal"); // FIX: was GetAxis("0") (invalid axis). "Horizontal" = A/D + Left/Right arrows
		//Note: The value of h must use the right and left arrow or "a" and "d" keys to move the player
		//right and left.

		if (h > 0) {
			myBody.linearVelocity = new Vector2 (speed, myBody.linearVelocity.y);

			ChangeDirection (1);

		} else if (h < 0) {
			myBody.linearVelocity = new Vector2 (-speed, myBody.linearVelocity.y);

			ChangeDirection (-1);

		} else {
			myBody.linearVelocity = new Vector2 (0f, myBody.linearVelocity.y);
		}

		anim.SetInteger ("Speed", Mathf.Abs((int)myBody.linearVelocity.x));

	}

	void ChangeDirection(int direction) {
		Vector3 tempScale = transform.localScale;
		tempScale.x = direction;
		transform.localScale = tempScale;
	}

	//Checking if the player is on the ground
	void CheckIfGrounded() {
		isGrounded = Physics2D.Raycast (groundCheckPosition.position, Vector2.down, 0.1f, groundLayer);

		if (isGrounded) {
			// and we jumped before
			if (jumped) {
				
				jumped = false;

				anim.SetBool ("Jump", false);
			}
		}

	}

	//Make the player jump
	void PlayerJump() {
		if (isGrounded) {
			if (Input.GetKeyDown (KeyCode.Space)) { // FIX: was 'if (jumped)' (always false). Spacebar + GetKeyDown = one jump per press
				jumped = true;
				myBody.linearVelocity = new Vector2 (myBody.linearVelocity.x, jumpPower);

				anim.SetBool ("Jump", true);
			}
		}
	}

} // class














































