using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowMotion : MonoBehaviour {
	[SerializeField]
	private float slowDownFactor;

	[SerializeField]
	private float duration;

	void Update () {
		Time.timeScale += (1f / duration) * Time.unscaledDeltaTime;
		Time.timeScale = Mathf.Clamp (Time.timeScale, 0f, 1f);
		Time.fixedDeltaTime = 0.02f * Time.timeScale;
	}

	public void SlowMotionFunc() {
		Time.timeScale = slowDownFactor;
		Time.fixedDeltaTime = 0.02f * Time.timeScale;
	}
}
