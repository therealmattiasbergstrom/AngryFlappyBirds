using UnityEngine;
using System.Collections;

public class HeartTrigger : MonoBehaviour {

	void OnCollisionEnter2D (Collision2D collision) {
		if (!collision.gameObject.tag.Equals("Box")) {
			GameObject.Find("Character").GetComponent<Character>().AddLife();
			gameObject.SetActive(false);
		}
	}
}
