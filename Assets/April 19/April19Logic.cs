using UnityEngine;
using System.Collections;

public class April19Logic : MonoBehaviour {
	public Rigidbody rbody;

	void Start () {
		rbody = GetComponent<Rigidbody> ();
	}
	
	void Update () {
		rbody.AddForce (transform.forward * 3.0f);
	}
}
