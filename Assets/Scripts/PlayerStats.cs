using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour {

	private int score;
	string playerName;
	public PowerUpsManager powerUpsManager;

	// Use this for initialization
	void Start () {
		score = 0;
		powerUpsManager = new PowerUpsManager ();
		Object.DontDestroyOnLoad (this);
	}

	public void AddPointsToScore(int points) {
		score += points;
		GameObject.Find ("ScoreText").GetComponent<Text> ().text = "Score: " + score;
	}

	public void Reset() {
		score = 0;
		powerUpsManager.Reset ();
	}

	public int GetScore() {
		return score;
	}

	public void SetPlayerName(string playerName) {
		this.playerName = playerName;
	}

	public string GetPlayerName() {
		return this.playerName;
	}
}
