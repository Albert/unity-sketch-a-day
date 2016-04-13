using UnityEngine;
using System.Collections;

public class April13Logic : MonoBehaviour {
	private Rigidbody rbody;
	private bool popped = false;
	private float lastT = 0;
	private float timePerSweep = 5;

	void Start () {
		rbody = GetComponent<Rigidbody> ();
	}
	
	void Update () {
		/* wrapping */
		if (transform.position.x < -50) { transform.position = transform.position + new Vector3( 100, 0,    0); popped = false;}
		if (transform.position.z < -50) { transform.position = transform.position + new Vector3(   0, 0,  100); popped = false;}
		if (transform.position.x >  50) { transform.position = transform.position + new Vector3(-100, 0,    0); popped = false;}
		if (transform.position.z >  50) { transform.position = transform.position + new Vector3(   0, 0, -100); popped = false;}

		float t = (Time.time % timePerSweep) / timePerSweep; // 0 to 1
		if (lastT > t) {
			popped = false;
		}

		if (popped == false) {
			float lineLocation = Mathf.Lerp (-50, 50, t);
			if (transform.position.x < lineLocation) {
				rbody.AddForce (-300, 600, 0);
				popped = true;
			}
		}

		lastT = t;
	}
}
