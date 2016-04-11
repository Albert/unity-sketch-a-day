using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class April10Logic : MonoBehaviour {
	public GameObject prefab;
	public int numberOfLasers = 100;
	public float rangeOfPlacement = 10;
	public List<GameObject> lasers;
	public GameObject subject;
	private Rigidbody rbody;

	// Use this for initialization
	void Start () {
		lasers = new List<GameObject> ();
		rbody = subject.GetComponent<Rigidbody> ();
		for (int i = 0; i < numberOfLasers; i++) {
			float percentageDone = (float)i / (float)numberOfLasers;
			float x = Random.Range (-rangeOfPlacement, rangeOfPlacement);
			float y = Random.Range (-rangeOfPlacement, rangeOfPlacement);
			float z = Random.Range (-rangeOfPlacement, rangeOfPlacement);
			Vector3 myPosition = new Vector3 (x, y, z);
			GameObject newLaser = Instantiate (prefab, myPosition, Quaternion.identity) as GameObject;
			lasers.Add (newLaser);
		}
	}
	
	// Update is called once per frame
	void Update () {
		foreach (GameObject laser in lasers) {
			laser.transform.LookAt (subject.transform);
		}
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
