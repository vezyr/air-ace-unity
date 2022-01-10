using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesController : MonoBehaviour {

	public float speed;
	public float timeToMoveDown;
	public float halfOfWidth;
	public float halfOfHeight;

	public GameObject doubleShootPowerUpPrefab;

	private int numberOfEnemies;
	private float leftEdge;
	private float rightEdge;
	private float bottomEdge;
	private int moveDirection;
	private float moveDownTimer;
	private int currentLevel;

	// Use this for initialization
	void Start () {
		leftEdge = Camera.main.ScreenToWorldPoint (new Vector3 (0, 0, 0)).x + halfOfWidth;
		rightEdge = Camera.main.ScreenToWorldPoint (new Vector3 (Camera.main.pixelWidth - halfOfWidth, 0, 0)).x - halfOfWidth;
		bottomEdge = -4.0f;

		moveDirection = -1;
		numberOfEnemies = transform.childCount;

		System.Random rand = new System.Random ();
		int powerUpEnemy = rand.Next (numberOfEnemies);
		transform.GetChild (powerUpEnemy).GetComponent<EnemyController> ().SetPowerUp (doubleShootPowerUpPrefab);

		moveDownTimer = 0;
		currentLevel = GameObject.Find ("LevelManager").GetComponent<LevelManager> ().GetCurrentLevel ();
	}
	
	// Update is called once per frame
	void Update () {
		float moveAspectHorizontal = moveDirection * speed * Time.deltaTime;
		float moveAspectVertical = GetMoveDownAspect ();
		transform.Translate(new Vector3(moveAspectHorizontal, moveAspectVertical, 0));
		ChangeMoveDirection ();
		if (GetLowestAirplaneY() - 0.8 <= bottomEdge) {
			Time.timeScale = 0;
			GameObject.Find ("LevelManager").GetComponent<LevelManager> ().GameOver ();
		}
	}

	private float GetLowestAirplaneY() {
		float result = 0;
		foreach (Transform child in transform) {
			if (child.position.y < result) {
				result = child.position.y;
			}
		}
		return result;
	}

	private float GetMoveDownAspect() {
		moveDownTimer += Time.deltaTime;
		float moveAspectVertical = 0;
		if (moveDownTimer >= (timeToMoveDown / (currentLevel / 3))) {
			moveAspectVertical = -25 * Time.deltaTime;
			moveDownTimer = 0;
		}

		return moveAspectVertical;
	}

	private void ChangeMoveDirection() {
		if (moveDirection == -1 && transform.position.x <= leftEdge) {
			moveDirection = 1;
		} else if (moveDirection == 1 && transform.position.x >= rightEdge) {
			moveDirection = -1;
		}
	}

	public void DecreaseNumberOfEnemies() {
		numberOfEnemies--;
		if (numberOfEnemies == 0) {
			GameObject.Find ("LevelManager").GetComponent<LevelManager> ().MoveToNextLevel ();
		}
	}
}
