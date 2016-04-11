using UnityEngine;
using System.Collections;

public class April7Logic : MonoBehaviour {
	private Rigidbody rbody;

	void Start () {
		rbody = GetComponent<Rigidbody> ();
	}
	
	void Update () {
		if (Input.GetKey (KeyCode.UpArrow)) {
			rbody.AddForce (Vector3.up * 20);
		}
		if (Input.GetKey (KeyCode.LeftArrow)) {
			rbody.AddForce (Vector3.left * 2);
		}
		if (Input.GetKey (KeyCode.RightArrow)) {
			rbody.AddForce (Vector3.right * 2);
		}
	}
}
