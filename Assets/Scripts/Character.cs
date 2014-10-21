using UnityEngine;
using System.Collections;

public class Character : MonoBehaviour {
	public float defaultRotation = 78f;
	private float _rotation;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		_rotation = transform.rotation.eulerAngles.z;
	}

	void OnCollisionEnter2D(Collision2D collision) {

		if (collision.collider.gameObject.tag == "DEADLY") {
			transform.position = Vector3.zero;
		}
	}
}
