using UnityEngine;
using System.Collections;

public class April11Logic : MonoBehaviour {
	public Rigidbody rbody;

	void Start () {
		rbody = GetComponent<Rigidbody> ();
		rbody.AddTorque (Vector3.up * 50000000000000);
	}
	
}
