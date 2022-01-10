using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class HighScoreEntry {
	public string playerName;
	public int score;
}

[System.Serializable]
public class HighScores {
	public HighScoreEntry[] entries;
}
