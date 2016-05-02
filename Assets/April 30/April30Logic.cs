using UnityEngine;
using System.Collections;

public class April30Logic : MonoBehaviour {
	public GameObject[] eyes;
	public GameObject subject;
	public GameObject head;

	void Update () {
		foreach (GameObject eye in eyes) {
			eye.transform.LookAt (subject.transform);
		}

		float x = Mathf.Sin (Time.time);
		float y = Mathf.Cos (Time.time);
		subject.transform.position = new Vector3 (x, y, 5);
		subject.transform.LookAt (head.transform);
	}
}
