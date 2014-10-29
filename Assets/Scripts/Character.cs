using UnityEngine;
using System.Collections;

public class Character : MonoBehaviour {
	public float defaultRotation = 78f;
	public float jumpForce;
	public float speed;
	public UnityEngine.UI.Text scoreText;

	private float _rotation;
	private Animator _animator;
	private ParticleSystem _particleSystem;
	private int _score;

	private static Character instance;
	public static Character Instance {
		get {
			return instance;
		}
	}

	private void CreateInstance() {
		instance = this;
		_particleSystem = GetComponent<ParticleSystem>();
		_animator = GetComponent<Animator> ();
	}

	void Awake () {
		if (instance == null) {
			CreateInstance ();
		}
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
			_animator.SetTrigger("Die");
		}
	}

	public void IncreaseScore() {
		_score++;
		scoreText.text = _score.ToString();
	}

	public void StartParticleSystem() {
		_particleSystem.Play();
	}

	public void RestartLevel() {
		Application.LoadLevel(0);
	}

}
