using UnityEngine;
using System.Collections;

public class Character : MonoBehaviour {
	public float defaultRotation = 78f;
	public float jumpForce;
	public float speed;	
	public int maxLife;
	public UnityEngine.UI.Text scoreText;
	public UnityEngine.UI.Text lifeText;

	private float _rotation;
	private Animator _animator;
	private ParticleSystem _particleSystem;
	private int _score;
	private int _life;

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
		_life = maxLife;
		lifeText.text = ""+_life;
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
			if (_life > 1) { 
				_animator.SetTrigger("Damage");
			}
			else {
				_animator.SetTrigger("Die");
			}
			RemoveLife ();
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

	public void AddLife() {
		if (_life < maxLife) {
			_life++;
			UpdateLifeText();
		}
	}

	public void RemoveLife() {
		_life--;
		UpdateLifeText();
	}

	public void AddToGhostLayer() {
		transform.FindChild("Body").gameObject.layer = LayerMask.NameToLayer("Ghost");
	}

	public void AddToDefaultLayer() {
		transform.FindChild("Body").gameObject.layer = LayerMask.NameToLayer("Default");
	}

	private void UpdateLifeText() {
		lifeText.text = ""+_life;
	}

}
