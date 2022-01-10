using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleShootPowerUpController : AbstractPowerUpController {

	protected override void ActivateBoost (PlayerController playerController) {
		playerController.ActivateDoubleShooting (bounsPoints);
	}

}
