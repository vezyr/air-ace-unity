using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : AbstractBulletController {

	public BulletController() : base(1) {
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.CompareTag ("Enemy")) {
			other.GetComponent<EnemyController> ().MakeDamage (damage);
			Destroy (this.gameObject);
		} else if (other.CompareTag ("PowerUp")) {
			other.GetComponent<AbstractPowerUpController> ().Destroy ();
			Destroy (this.gameObject);
		}
	}

	protected override bool isOutOfScreen() {
		return transform.position.y > topEdge;
	}
}
