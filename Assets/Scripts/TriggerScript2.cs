using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerScript2 : MonoBehaviour {
	private Camera cam;
	[SerializeField]
	private TimeReverse timeManager;

	[SerializeField]
	private GameObject explosion;

	void Start() {
		cam = Camera.main;
	}
	void Update () {
		RaycastHit _hit;
		if (Input.GetButtonDown ("Fire1")) {
			if (Physics.Raycast(cam.transform.position, cam.transform.forward, out _hit)) {	
				Instantiate (explosion, _hit.point, Quaternion.LookRotation(_hit.normal));
				timeManager.TimeReverseFunc ();
			}
		}
	}
}
