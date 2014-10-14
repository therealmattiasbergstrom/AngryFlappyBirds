using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {
	public GameObject target;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		TrackTarget();
	}

	void TrackTarget() {
		this.transform.position = new Vector3(target.transform.position.x, this.transform.position.y, this.transform.position.z);
	}
}
