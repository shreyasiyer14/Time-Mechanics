using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeReverse : MonoBehaviour {

	public GameObject testObject;

	[SerializeField]
	private int framesToBeReversed;

	private bool reverseTime = false;
	private List<Vector3> positions = new List<Vector3>();
	private List<Quaternion> rotations = new List<Quaternion>();
	private float timer = 0f;
	void Start () {

	}

	void Update () {
		if (!reverseTime && positions.Count <= framesToBeReversed) {
			positions.Add (testObject.transform.position);
			rotations.Add (testObject.transform.rotation);
			timer += Time.deltaTime;
		}

		if (positions.Count > framesToBeReversed) {
			timer = 0f;
			positions.RemoveAt (0);
			rotations.RemoveAt (0);
		}

		if (reverseTime) {
			testObject.GetComponent<Rigidbody> ().useGravity = false;
			testObject.GetComponent<Rigidbody> ().detectCollisions = false;
			if (positions.Count > 0) {
				testObject.transform.position = positions [positions.Count - 1];
				testObject.transform.rotation = rotations [rotations.Count - 1];
				positions.RemoveAt (positions.Count - 1);
				rotations.RemoveAt (rotations.Count - 1);
			}
			if (positions.Count == 0) {
				reverseTime = false;
				ClearArray ();
				testObject.GetComponent<Rigidbody> ().useGravity = true;
				testObject.GetComponent<Rigidbody> ().detectCollisions = true;
			}
			timer = 0f;
		}

	}

	public void TimeReverseFunc() {
		reverseTime = true;
	}

	void ClearArray() {
		positions.Clear ();
		rotations.Clear ();
	}
}
