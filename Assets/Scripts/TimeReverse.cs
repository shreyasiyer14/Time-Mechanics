using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeReverse : MonoBehaviour {

	public GameObject testObject;

	[SerializeField]
	private float duration;

	private bool reverseTime = false;
	private LinkedList<Vector3> positions;
	private LinkedList<Quaternion> rotations;

	void Start () {
		//InvokeRepeating ("ClearArray", 1f, 5f);
	}

	void Update () {
		if (!reverseTime) {
			positions.AddFirst (testObject.transform.position);
			rotations.AddFirst (testObject.transform.rotation);
			Debug.Log (positions.Count);
		}
		if (reverseTime) {
			testObject.GetComponent<Rigidbody> ().useGravity = false;
			testObject.transform.position = positions.First.Value;
			testObject.transform.rotation = rotations.First.Value;
			positions.RemoveFirst ();
			rotations.RemoveFirst ();
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
