using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuController : MonoBehaviour {

	public void StartNewGame() {
		GameObject.Find ("LevelManager").GetComponent<LevelManager> ().PrelaunchGame ();

	}

	public void Quit() {
		GameObject.Find ("LevelManager").GetComponent<LevelManager> ().QuitApplication ();
	}
}
