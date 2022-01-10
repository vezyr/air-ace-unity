using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameSummaryController : MonoBehaviour {

	public Text scoreText;
	public Text[] playerNames;
	public Text[] scores;

	// Use this for initialization
	void Start () {
		int score = GameObject.Find ("PlayerStats").GetComponent<PlayerStats> ().GetScore ();
		string name = GameObject.Find ("PlayerStats").GetComponent<PlayerStats> ().GetPlayerName ();
		scoreText.text = "Your score: " + score;

		if (OnlineLeaderboardHelper.onlineLeaderboardEnabled == true)
		{
			SendScoreToServer(score, name);
			HighScores highScores = GetHighScores();

			if (highScores != null)
			{
				for (int i = 0; i < 10; i++)
				{
					if (i < highScores.entries.Length)
					{
						playerNames[i].text = highScores.entries[i].playerName;
						scores[i].text = highScores.entries[i].score.ToString();
					}
				}
			}
		}
	}

	public void PlayAgain() {
		GameObject.Find ("PlayerStats").GetComponent<PlayerStats> ().Reset ();
		GameObject.Find ("LevelManager").GetComponent<LevelManager> ().StartNewGame ();
	}

	public void BackToMainMenu() {
		Destroy (GameObject.Find ("PlayerStats"));
		GameObject.Find ("LevelManager").GetComponent<LevelManager> ().MainMenu ();
	}

	private void SendScoreToServer(int score, string name) {
		WWWForm form = new WWWForm ();
		form.AddField ("Score", score);
		if (string.IsNullOrEmpty (name)) {
			name = "Anonymous";
		}
		form.AddField ("PlayerName", name);
		form.AddField ("Version", OnlineLeaderboardHelper.version);
		form.AddField ("Key", OnlineLeaderboardHelper.onlineLeaderboardKey);

		WWW request = new WWW (OnlineLeaderboardHelper.saveScoreUrl, form);

		while (request.isDone  == false) {
			// wait to finish
		}
	}

	private HighScores GetHighScores() {
		WWW request = new WWW (OnlineLeaderboardHelper.getHighscoresUrl + OnlineLeaderboardHelper.version );
		while (request.isDone == false) {
			// wait to finish
		}

		HighScores highScores = null;
		if (string.IsNullOrEmpty (request.error) == false) {
			Debug.LogError (request.error);
		} else {
			highScores = JsonUtility.FromJson<HighScores> (request.text);
		}
		return highScores;
	}
}
