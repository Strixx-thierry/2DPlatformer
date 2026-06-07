using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerDamage : MonoBehaviour {

	private Text lifeText;
	private int lifeScoreCount;

	private bool canDamage;

	void Awake () {
		lifeText = GameObject.Find ("LifeText").GetComponent<Text> ();
		lifeScoreCount = 3;
		lifeText.text = "x" + lifeScoreCount;

		canDamage = true;
	}

	public void DealDamage() {
		if (canDamage) {

			lifeScoreCount--;

			if (lifeScoreCount >= 0) {
				lifeText.text = "x" + lifeScoreCount;
			}

			if (lifeScoreCount == 0) {
				// FEATURE: out of lives -> load the End (Game Over) scene
				SceneManager.LoadScene ("EndScene");
			}

			canDamage = false;

			StartCoroutine (WaitForDamage ());
		}
	}

	IEnumerator WaitForDamage() {
		yield return new WaitForSeconds (2f);
		canDamage = true;
	}

} // class
