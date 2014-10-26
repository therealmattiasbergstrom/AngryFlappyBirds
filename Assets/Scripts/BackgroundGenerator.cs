﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent (typeof(Transform))]
public class BackgroundGenerator : MonoBehaviour {
	public Transform backgroundParent;
	public Transform foregroundParent;

	// Prefabs
	public GameObject ground;
	public GameObject roof;
	public GameObject background;

	private float _backgroundLength = 60.0f;
	private float _currentBackgroundOffset = 30.0f; // Half of the background length

	private List<GameObject> _oldObjects;

	// Use this for initialization
	void Start () {
		_oldObjects = new List<GameObject>();
	}
	
	// Update is called once per frame
	void Update () {
		// Generate background if we passed half of the background
		if ((transform.position.x - _currentBackgroundOffset) > 0) {
			_currentBackgroundOffset += _backgroundLength;
			CreateBackground();
			RemoveOldObjects();
		}
	}

	void CreateBackground() {
		Vector3 bgPos = new Vector3(_currentBackgroundOffset, 0, 10);
		Vector3 roofPos = new Vector3(_currentBackgroundOffset, 7, 0);
		Vector3 groundPos = new Vector3(_currentBackgroundOffset, -7, 0);

		var bg = Instantiate (background, bgPos, Quaternion.identity) as GameObject;
		var r = Instantiate (roof, roofPos, Quaternion.Euler (0, 0, 180)) as GameObject;
		var g = Instantiate (ground, groundPos, Quaternion.identity) as GameObject;

		r.transform.parent = foregroundParent;
		g.transform.parent = foregroundParent;
		bg.transform.parent = backgroundParent;

		_oldObjects.Add(bg);
		_oldObjects.Add(r);
		_oldObjects.Add(g);
	}
	
	void RemoveOldObjects() {
		if (_oldObjects.Count > 6) {
			Destroy(_oldObjects[0]);
			Destroy(_oldObjects[1]);
			Destroy(_oldObjects[2]);

			_oldObjects.RemoveRange(0, 3);
		}
	}
}
