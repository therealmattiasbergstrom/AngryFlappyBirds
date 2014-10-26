using UnityEngine;
using System.Collections;

public class Character : MonoBehaviour {
	public float defaultRotation = 78f;
	public float jumpForce;
	public float speed;

	private float _rotation;
	private Animator _animator;

	// Use this for initialization
	void Awake () {
		_animator = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown("Fire1")) {
			_animator.SetTrigger("Fly");
			this.rigidbody2D.AddForce(Vector2.up * jumpForce);
		}
	}

	void FixedUpdate() {
		if (this.rigidbody2D.velocity.x < speed) {
			this.rigidbody2D.AddForce(Vector2.right * 100);
		}
	}

	void OnCollisionEnter2D(Collision2D collision) {

		if (collision.collider.gameObject.tag == "DEADLY") {
			Application.LoadLevel(0);
		}
	}
}
