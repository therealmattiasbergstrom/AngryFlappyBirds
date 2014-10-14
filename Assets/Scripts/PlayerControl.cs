using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {
	public float jumpForce;
	public float speed;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown("Fire1")) {
			this.rigidbody2D.AddForce(Vector2.up * jumpForce);
		}
	}

	// Update is called on a fixed interval
	void FixedUpdate() {
		if (this.rigidbody2D.velocity.x < speed) {
			this.rigidbody2D.AddForce(Vector2.right * 100);
		}
	}
}
