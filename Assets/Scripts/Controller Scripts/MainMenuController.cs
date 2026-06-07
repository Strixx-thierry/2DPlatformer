using UnityEngine;
using UnityEngine.SceneManagement;

// Drives the menu / end-screen buttons. Scene-based flow: each scene that has these buttons
// (MainMenu, EndScene, and the in-game Win screen) gets its own copy of this script.
public class MainMenuController : MonoBehaviour {

	// Play button (Main Menu) -> load the gameplay scene
	public void PlayGame () {
		Debug.Log ("PlayGame() called -> loading GameScene-ALU");
		Time.timeScale = 1f;
		SceneManager.LoadScene ("GameScene-ALU"); // FIX: was "Gameplay" (no such scene). Real scene = GameScene-ALU
	}

	// Replay button (End / Win screen) -> restart the gameplay scene
	public void Replay () {
		Debug.Log ("Replay() called -> loading GameScene-ALU");
		Time.timeScale = 1f;                      // unfreeze in case the Win screen paused the game
		SceneManager.LoadScene ("GameScene-ALU");
	}

	// Quit button -> close the game. In the editor it stops Play mode so you can see it work.
	public void QuitGame () {
		Debug.Log ("QuitGame() called -> quitting");
		Application.Quit ();
	#if UNITY_EDITOR
		UnityEditor.EditorApplication.isPlaying = false;
	#endif
	}
}
