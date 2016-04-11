using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class April8Logic : MonoBehaviour {
	public List<GameObject> subjects;
	public float panTime = 1;
	private Vector3 prevLocation;
	private Vector3 nextLocation;
	private float timeOfChange = 0;
	void Start () {
		prevLocation = subjects [Random.Range ((int)0, (int)4)].transform.position;
		nextLocation = subjects [Random.Range ((int)0, (int)4)].transform.position;
	}

	void Update () {
		float tVal = (Time.time - timeOfChange) / panTime;
		Vector3 whereToLook = Vector3.Lerp (prevLocation, nextLocation, tVal); 
		transform.LookAt (whereToLook);
		if (Input.GetMouseButtonDown (0)) {
			timeOfChange = Time.time;
			prevLocation = transform.position + transform.forward;
			nextLocation = subjects [Random.Range ((int)0, (int)4)].transform.position;
		}
	}
}
