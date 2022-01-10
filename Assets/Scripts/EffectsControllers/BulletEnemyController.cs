using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEnemyController : AbstractBulletController {

	public BulletEnemyController() : base(-1) {
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.CompareTag ("Player")) {
			Destroy (this.gameObject);
			Time.timeScale = 0;
			GameObject.Find ("LevelManager").GetComponent<LevelManager> ().GameOver ();
		}
	}

	protected override bool isOutOfScreen() {
		return transform.position.y < bottomEdge;
	}
}
