using UnityEngine;
using System.Collections;

public class April17Logic : MonoBehaviour {
	public GameObject prefab;
	public GameObject top;
	private Collider topCollider;

	void Start () {
		topCollider = top.GetComponent<Collider> ();
	}
	
	void Update () {
		GameObject s = Instantiate (prefab, Vector3.up * 5, Quaternion.identity) as GameObject;
		s.GetComponent<Rigidbody> ().velocity = Vector3.down * 10;
		if (Input.GetKeyUp (KeyCode.Space)) {
			topCollider.enabled = !topCollider.enabled;
		}
	}
}
