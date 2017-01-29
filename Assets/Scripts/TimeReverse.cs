using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeReverse : MonoBehaviour {

	public GameObject testObject;

	[SerializeField]
	private float duration;

	private bool reverseTime = false;
	private List<Vector3> positions = new List<Vector3>();
	private List<Quaternion> rotations = new List<Quaternion>();
	private float timer = 0f;
	void Start () {

	}

	void Update () {
		if (!reverseTime && timer < duration) {
			positions.Add (testObject.transform.position);
			rotations.Add (testObject.transform.rotation);
			timer += Time.deltaTime;
		}

		if (reverseTime) {
			testObject.GetComponent<Rigidbody> ().useGravity = false;
			if (positions.Count > 0) {
				testObject.transform.position = positions [positions.Count - 1];
				testObject.transform.rotation = rotations [rotations.Count - 1];
				positions.RemoveAt (positions.Count - 1);
				rotations.RemoveAt (rotations.Count - 1);

			}
			if (positions.Count < 0) {
				reverseTime = false;
				ClearArray ();
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
