using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamage : MonoBehaviour {

	private bool canDamage;     // i-frame guard so a single enemy hit costs only one life

	void Awake () {
		canDamage = true;
	}

	void Start() {
		Time.timeScale = 1f;    // make sure time is running (in case it was paused before a reload)
	}

	// Called by the enemy scripts when they touch the player.
	public void DealDamage() {
		if (canDamage) {
			canDamage = false;
			GameManager.instance.LoseLife (false);   // FEATURE: life is owned by GameManager now (enemy hit, no respawn)
			StartCoroutine (WaitForDamage ());
		}
	}

	// FEATURE: water tiles are tagged "Water" -> tell the GameManager to respawn the player (or end the game).
	void OnTriggerEnter2D(Collider2D other) {
		if (other.CompareTag ("Water")) {
			GameManager.instance.PlayerDrowned ();
		}
	}

	IEnumerator WaitForDamage() {
		yield return new WaitForSeconds (2f);
		canDamage = true;
	}

} // class
