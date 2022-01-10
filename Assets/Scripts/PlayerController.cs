using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

	public float speed;
	public GameObject bulletPrefab;
	public float timeBetweenFires;

	private int halfOfHeroWidth = 33;
	private float leftEdge;
	private float rightEdge;
	private float fireTimer;

	private PlayerStats playerStats;

	// Use this for initialization
	void Start () {
		leftEdge = Camera.main.ScreenToWorldPoint (new Vector3 (halfOfHeroWidth, 0, 0)).x;
		rightEdge = Camera.main.ScreenToWorldPoint (new Vector3 (Camera.main.pixelWidth - halfOfHeroWidth, 0, 0)).x;
		fireTimer = 0;
		GameObject.Find ("ScoreText").GetComponent<Text> ().text = "Score: " + GameObject.Find("PlayerStats").GetComponent<PlayerStats>().GetScore();
		playerStats = GameObject.Find ("PlayerStats").GetComponent<PlayerStats> ();
	}
	
	// Update is called once per frame
	void Update () {
		float moveAspect = 0;

		if (Input.GetButton("Left")) {
			moveAspect = speed * Time.deltaTime * -1;
		} else if (Input.GetButton("Right")) {
			moveAspect = speed * Time.deltaTime;
		}

		transform.Translate (moveAspect, 0, 0);

		CorrectPositionOnScreen ();

		fireTimer += Time.deltaTime;
		if (Input.GetButton("Fire") && fireTimer >= timeBetweenFires) {
			Shoot ();
		}
	}

	public void ActivateDoubleShooting(int bonusPoints) {
		if (playerStats.powerUpsManager.IsDoubleShootingActive ()) {
			playerStats.AddPointsToScore (bonusPoints);
		} else {
			playerStats.powerUpsManager.ActivateDoubleShooting ();
		}
	}

	private void Shoot () {
		fireTimer = 0;
		if (playerStats.powerUpsManager.IsDoubleShootingActive() == true) {
			Instantiate (bulletPrefab, new Vector3 (transform.position.x - 0.2f, transform.position.y, 0), transform.rotation);
			Instantiate (bulletPrefab, new Vector3 (transform.position.x + 0.2f, transform.position.y, 0), transform.rotation);
		} else {
			Instantiate (bulletPrefab, new Vector3 (transform.position.x, transform.position.y, 0), transform.rotation);
		}
	}

	private void CorrectPositionOnScreen() {
		if (transform.position.x < leftEdge) {
			transform.position = new Vector3 (leftEdge, transform.position.y, transform.position.z);
		} else if (transform.position.x > rightEdge) {
			transform.position = new Vector3 (rightEdge, transform.position.y, transform.position.z);
		}
	}
}
