using UnityEngine;
using TMPro;                       // TextMeshPro text
using UnityEngine.SceneManagement;

// Simple countdown timer for the HUD. Counts down from startSeconds and shows it as mm:ss
// in the top-right. When it hits 0 the End (Game Over) scene loads.
public class Timer : MonoBehaviour {

	public TMP_Text timerText;        // drag the TMP text here in the Inspector
	public float startSeconds = 60f;  // how long the player has

	private float timeLeft;

	void Start () {
		timeLeft = startSeconds;
	}

	void Update () {
		if (timeLeft <= 0f) return;   // already finished -> do nothing

		timeLeft -= Time.deltaTime;   // count down (frozen while the game is paused)

		if (timeLeft <= 0f) {
			timeLeft = 0f;
			ShowTime ();
			SceneManager.LoadScene ("EndScene");   // FEATURE: time ran out -> Game Over scene
			return;
		}

		ShowTime ();
	}

	// Turns the seconds left into mm:ss (e.g. 65 -> "01:05") and shows it.
	void ShowTime () {
		int minutes = (int) timeLeft / 60;
		int seconds = (int) timeLeft % 60;
		timerText.text = minutes.ToString ("00") + ":" + seconds.ToString ("00");
	}
}
