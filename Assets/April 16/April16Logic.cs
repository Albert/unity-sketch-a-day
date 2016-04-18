using UnityEngine;
using System.Collections;

public class April16Logic : MonoBehaviour {
	private Rigidbody rbody;
	private SpringJoint[] sJoints;

	void Start () {
		rbody = GetComponent<Rigidbody> ();
		sJoints = GetComponents<SpringJoint> ();
		foreach (SpringJoint sJoint in sJoints) {
			sJoint.damper = 10;
			sJoint.spring = 10;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0)) {
			//transform.LookAt (Random.onUnitSphere);
			rbody.AddTorque(Random.onUnitSphere * Random.Range(100, 500));
		}
	}
}
