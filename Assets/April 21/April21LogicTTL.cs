using UnityEngine;
using System.Collections;

public class April21LogicTTL : MonoBehaviour {
	private Rigidbody rbody;

	void Start () {
		rbody = GetComponent<Rigidbody> ();
		rbody.velocity = Vector3.down * 5;
		rbody.AddForce (Vector3.right * 100);
	}
	
	void Update () {
		rbody.AddForce (Vector3.right * 5);
		if (transform.position.y < 0.5f) {
			Destroy (gameObject);
		}
	}
}
