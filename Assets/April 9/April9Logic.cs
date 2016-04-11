using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class April9Logic : MonoBehaviour {
	public GameObject prefab;
	public int lengthOfTrail = 100;
	private GameObject oldSphere;
	private Rigidbody firstSphereRbody;

	void Start () {
		for (int i = 0; i < lengthOfTrail; i++) {
			Vector3 myPosition = new Vector3 (0, -i*1.1f, 0);
			GameObject newSphere = Instantiate (prefab, myPosition, Quaternion.identity) as GameObject;
			SpringJoint newJoint = newSphere.GetComponent<SpringJoint> ();
			if (i != 0) {
				newJoint.connectedBody = oldSphere.GetComponent<Rigidbody> ();
			} else {
				firstSphereRbody = newSphere.GetComponent<Rigidbody> ();
			}
			oldSphere = newSphere;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.anyKeyDown) {
			firstSphereRbody.AddForce (Vector3.forward * Random.Range(-10000, 10000));
			firstSphereRbody.AddForce (Vector3.right * Random.Range(-1000, 1000));
		}
	}
}
