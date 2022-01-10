using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractBulletController : MonoBehaviour {

	public float speed;
	public int damage;

	protected float topEdge;
	protected float bottomEdge;

	private Rigidbody2D rigid;

	/*
	 * Defines direction of moving bullet.
	 * If positive - move up 
	 * If negative - move down
	 * Value should be -1 or 1
	 */
	private int direction;

	public AbstractBulletController(int direction) {
		this.direction = direction;
	}

	// Use this for initialization
	void Start () {
		topEdge = Camera.main.ScreenToWorldPoint (new Vector3 (0, Camera.main.pixelHeight, 0)).y;
		bottomEdge = Camera.main.ScreenToWorldPoint (new Vector3 (0, 0, 0)).y;
		rigid = GetComponent<Rigidbody2D> ();
	}

	// Update is called once per frame
	void Update () {
		rigid.MovePosition(new Vector2(rigid.position.x, rigid.position.y + speed * Time.deltaTime * direction));

		if (isOutOfScreen()) {
			Destroy (this.gameObject);
		}
	}

	protected abstract bool isOutOfScreen ();
}
