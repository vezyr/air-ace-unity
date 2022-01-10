using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMediumController : EnemyController {

	public EnemyMediumController() : base(2) {
	}

	override protected void SetFire() {
		if (health == 2) {
			transform.Find ("Fire1").gameObject.SetActive(true);
		} else if (health == 1) {
			transform.Find ("Fire2").gameObject.SetActive(true);
		}
	}
}
