using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyController : MonoBehaviour {

	public GameObject bulletPrefab;
	public GameObject explosionPrefab;
	public int points;
	public int health;
	public float shootTimeIntervalMin;
	public float shootTimeIntervalMax;
	public float shootDelayMin;
	public float shootDelayMax;

	private int numberOfShoots;
	private static System.Random rand = new System.Random();
	private GameObject powerUp;

	public EnemyController(int numberOfShoots) {
		this.numberOfShoots = numberOfShoots;
	}

	public void Start() {
		Invoke ("FireFirstBullet", rand.Next ((int)(shootTimeIntervalMin * 10.0f), (int)(shootTimeIntervalMax * 10.0f)) / 10.0f);
	}

	public void MakeDamage (int damage) {
		health -= damage;
		if (health <= 0) {
			DestroyAirplane ();
		} else {
			SetFire ();
		}
	}

	public void DestroyAirplane() {
		Instantiate(explosionPrefab, new Vector3 (transform.position.x, transform.position.y, 0), transform.rotation);
		GameObject.Find ("PlayerStats").GetComponent<PlayerStats> ().AddPointsToScore (points);
		transform.parent.GetComponent<EnemiesController> ().DecreaseNumberOfEnemies ();
		if (powerUp != null) {
			Instantiate (powerUp, new Vector3 (transform.position.x, transform.position.y, 0), transform.rotation);
		}
		Destroy (this.gameObject);
	}

	public void SetPowerUp(GameObject powerUp) {
		this.powerUp = powerUp;
	}

	protected abstract void SetFire ();

	private void FireFirstBullet() {
		float positionCorrection = 0.0f;
		if (numberOfShoots > 1) {
			positionCorrection = 0.5f;
		}
		Instantiate(bulletPrefab, new Vector3 (transform.position.x + positionCorrection, transform.position.y, 0), transform.rotation);
		if (numberOfShoots > 1) {
			Invoke ("FireSecondBullet", rand.Next ((int)(shootDelayMin * 10.0f), (int)(shootDelayMax * 10.0f)) / 10.0f);
		} else {
			Invoke ("FireFirstBullet", rand.Next ((int)(shootTimeIntervalMin * 10.0f), (int)(shootTimeIntervalMax * 10.0f)) / 10.0f);
		}
	}

	private void FireSecondBullet() {
		float positionCorrection = 0.0f;
		if (numberOfShoots > 1) {
			positionCorrection = 0.5f;
		}
		Instantiate(bulletPrefab, new Vector3 (transform.position.x - positionCorrection, transform.position.y, 0), transform.rotation);
		if (numberOfShoots > 2) {
			Invoke ("FireThirdBullet", rand.Next ((int)(shootDelayMin * 10.0f), (int)(shootDelayMax * 10.0f)) / 10.0f);
		} else {
			Invoke ("FireFirstBullet", rand.Next ((int)(shootTimeIntervalMin * 10.0f), (int)(shootTimeIntervalMax * 10.0f)) / 10.0f);
		}
	}

	private void FireThirdBullet() {
		Instantiate(bulletPrefab, new Vector3 (transform.position.x, transform.position.y, 0), transform.rotation);
		Invoke ("FireFirstBullet", rand.Next ((int)(shootTimeIntervalMin * 10.0f), (int)(shootTimeIntervalMax * 10.0f)) / 10.0f);
	}
}
