using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStrongController : EnemyController {

	public EnemyStrongController() : base(3) {
	}

	override protected void SetFire() {
		if (health == 4) {
			transform.Find ("Fire1").gameObject.SetActive(true);
		} else if (health == 3) {
			transform.Find ("Fire2").gameObject.SetActive(true);
		} else if (health == 2) {
			transform.Find ("Fire3").gameObject.SetActive(true);
		} else if (health == 1) {
			transform.Find ("Fire4").gameObject.SetActive(true);
		}
	}
}
