using UnityEngine;

// GameManager (sits on the Player): when the player falls into water, send them back to the
// NEAREST checkpoint and take one life. Several checkpoints = you respawn close to where you
// fell in (or where a monster got you), not all the way back at the start.
public class GameManager : MonoBehaviour {

	public Transform[] respawnPoints;   // drag your checkpoint objects here (place a few around the level)

	// Runs when the player touches a trigger. The water tiles are triggers tagged "Water".
	void OnTriggerEnter2D (Collider2D other) {
		if (other.tag == "Water") {
			RespawnAtNearest ();                          // go to the closest checkpoint
			GetComponent<PlayerDamage> ().DealDamage ();  // lose one life
		}
	}

	// Moves the player to whichever checkpoint is closest right now.
	// public so enemy scripts can call it too (e.g. when a monster kills the player).
	public void RespawnAtNearest () {
		if (respawnPoints.Length == 0) return;            // nothing assigned yet -> do nothing

		Transform nearest = respawnPoints[0];
		float shortest = Vector2.Distance (transform.position, nearest.position);

		foreach (Transform point in respawnPoints) {
			float distance = Vector2.Distance (transform.position, point.position);
			if (distance < shortest) {
				shortest = distance;
				nearest = point;
			}
		}

		transform.position = nearest.position;
	}
}
