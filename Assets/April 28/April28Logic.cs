using UnityEngine;
using System.Collections;

public class April28Logic : MonoBehaviour {
	private float scaleStart;
	private float mouseStart;
	private bool inFlux = false;
	private float timeOfRelease;
	private float scaleRelease;
	private float animationTime = 1;

	void Start () {
	}
	
	void Update () {
		float mouseY = Input.mousePosition.y;
		if (Input.GetMouseButtonDown (0)) {
			scaleStart = transform.localScale.y;
			mouseStart = mouseY;
			inFlux = false;
		}
		if (Input.GetMouseButton (0)) {
			float mouseDelta = (mouseY - mouseStart) / Screen.height;
			// x = mousedelta, y is scalefactor http://screencast.com/t/aXP6cLrarE
			float scaleFactor = Mathf.Pow (mouseDelta + 1, 2);
			transform.localScale = new Vector3(1, scaleStart * scaleFactor, 1);
		}
		if (Input.GetMouseButtonUp (0)) {
			inFlux = true;
			timeOfRelease = Time.time;
			scaleRelease = transform.localScale.y;
		}
		if (inFlux) {
			float timeSince = Time.time - timeOfRelease;
			float decay = Mathf.Clamp(-(timeSince / animationTime) + 1, 0, 1);
			float scaleDelta = scaleRelease - 1;
			float heightMagnitude = Mathf.Cos(timeSince * 10) * decay;
			transform.localScale = new Vector3(1, 1 + scaleDelta * heightMagnitude, 1);
		}
	}
}