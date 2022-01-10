using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PrelaunchController : MonoBehaviour {

	public Text playerName;

	void Start() {
		string pName = PlayerPrefs.GetString ("PlayerName");
		playerName.text = pName;
	}

	public void StartGame() {
		string pName = playerName.text;
		if (string.IsNullOrEmpty (pName)) {
			pName = "Anonymous";
		}
		PlayerPrefs.SetString ("PlayerName", pName);
		GameObject.Find ("PlayerStats").GetComponent<PlayerStats> ().SetPlayerName (pName);
		GameObject.Find ("LevelManager").GetComponent<LevelManager> ().StartNewGame ();
	}
}