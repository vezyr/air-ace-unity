public class PowerUpsManager {

	private bool doubleShootActive;

	public void Reset() {
		doubleShootActive = false;
	}

	public void ActivateDoubleShooting() {
		doubleShootActive = true;
	}

	public bool IsDoubleShootingActive() {
		return doubleShootActive;
	}
}
