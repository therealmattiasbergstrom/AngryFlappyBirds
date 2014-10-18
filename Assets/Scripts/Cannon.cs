using UnityEngine;
using System.Collections;

public class Cannon : MonoBehaviour {
	public Rigidbody2D projectile;
	public int numberOfProjectiles;
	public float shootRate = 1;

	private float cooldown = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (cooldown > 0) {
			cooldown -= Time.deltaTime;
		}
		else if (Input.GetButtonDown ("Jump")) {
			if(numberOfProjectiles > 0) {
				Rigidbody2D rb = (Rigidbody2D)Instantiate(projectile, transform.position + new Vector3(1, 0, 0), transform.rotation);
				rb.AddForce(Vector2.right * 1000);
				numberOfProjectiles--;
				cooldown = shootRate;
			}
		}
	}
}
