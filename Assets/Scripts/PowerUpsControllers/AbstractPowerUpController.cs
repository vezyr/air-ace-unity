using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractPowerUpController : MonoBehaviour {

	public float speed;
	public int bounsPoints;
	public GameObject explosionPrefab;

	private float bottomEdge;
	private Rigidbody2D rigid;

	void Start () {
		bottomEdge = Camera.main.ScreenToWorldPoint (new Vector3 (0, 0, 0)).y;
		rigid = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		rigid.MovePosition(new Vector2(rigid.position.x, rigid.position.y - speed * Time.deltaTime));

		if (rigid.position.y < bottomEdge) {
			Destroy (this.gameObject);
		}
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.CompareTag ("Player")) {
			ActivateBoost (other.GetComponent<PlayerController> ());
			Destroy (this.gameObject);
		}
	}

	public void Destroy() {
		Instantiate(explosionPrefab, new Vector3 (transform.position.x, transform.position.y, 0), transform.rotation);
		Destroy (this.gameObject);
	}

	protected abstract void ActivateBoost (PlayerController playerController);
}