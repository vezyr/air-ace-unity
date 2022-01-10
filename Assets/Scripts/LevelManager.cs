using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

	private int currentLevel;

	// Use this for initialization
	void Start () {
		Object.DontDestroyOnLoad (this);
	}
	
	public void StartNewGame() {
		currentLevel = 1;
		SceneManager.LoadScene ("Level1", LoadSceneMode.Single);
		Time.timeScale = 1;
	}

	public void MoveToNextLevel() {
		currentLevel++;
		SceneManager.LoadScene ("Level" + ((currentLevel % 3) + 1), LoadSceneMode.Single);
	}

	public int GetCurrentLevel() {
		return currentLevel;
	}

	public void GameOver() {
		SceneManager.LoadScene ("GameSummary", LoadSceneMode.Single);
	}

	public void QuitApplication() {
		Application.Quit ();
	}

	public void PrelaunchGame() {
		SceneManager.LoadScene ("PrelaunchGame", LoadSceneMode.Single);
	}

	public void MainMenu() {
		SceneManager.LoadScene ("MainMenu", LoadSceneMode.Single);
	}
}
