using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {
	public float jumpForce;
	public float speed;
	public Rigidbody2D projectile;
	public int numberOfProjectiles;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown("Fire1")) {
			this.rigidbody2D.AddForce(Vector2.up * jumpForce);
		}
		if (Input.GetButtonDown ("Jump")) {
			if(numberOfProjectiles > 0) {
				Rigidbody2D rb = (Rigidbody2D)Instantiate(projectile, transform.position + new Vector3(1, 0, 0), transform.rotation);
				rb.AddForce(Vector2.right * 1000);
				numberOfProjectiles--;
			}
		}
	}

	// Update is called on a fixed interval
	void FixedUpdate() {
		if (this.rigidbody2D.velocity.x < speed) {
			this.rigidbody2D.AddForce(Vector2.right * 100);
		}
	}
}
