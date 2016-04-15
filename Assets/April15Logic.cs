using UnityEngine;
using System.Collections;

public class April15Logic : MonoBehaviour {
	public GameObject prefab;
	public LineRenderer lrend;
	void Start () {
		lrend = GetComponent<LineRenderer> ();
		lrend.SetVertexCount(100);
	}
	void Update () {
		Vector3 initialVelocity = Vector3.forward * 20;

		float horiz = SuperLerpUnclamped (-1.0f, 1.0f, 0.0f, Screen.width, Input.mousePosition.x);
		float vert = SuperLerpUnclamped (-1.0f, 1.0f, 0.0f, Screen.height, Input.mousePosition.y);
		initialVelocity += new Vector3 (horiz, 0.0f, vert) * 20.0f;

		if (Input.GetMouseButtonDown (0)) {
			GameObject x = Instantiate (prefab);
			x.GetComponent<Rigidbody> ().velocity = initialVelocity;
		}
		Vector3 linePosition = prefab.transform.position;
		Vector3 gravityVelocity = Vector3.zero;
		for (int i = 0; i < 100; i++) {
			lrend.SetPosition (i, linePosition);
			linePosition += initialVelocity * Time.fixedDeltaTime;
			gravityVelocity += Physics.gravity * Time.fixedDeltaTime / 50;
			linePosition += gravityVelocity;
		}
	}

	private static float SuperLerpUnclamped (float from, float to, float from2, float to2, float value) {
		return (to - from) * ((value - from2) / (to2 - from2)) + from;
	}
}