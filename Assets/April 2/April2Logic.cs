using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class April2Logic : MonoBehaviour {
	public GameObject prefab;
	public int rows = 5;
	public int cols = 5;
	public int ups  = 5;
	private List<GameObject> pieces;
	private List<Rigidbody> rbodies;

	void Start () {
		pieces = new List<GameObject> ();
		rbodies = new List<Rigidbody> ();
		for (int i = 0; i < rows; i++) {
			for (int j = 0; j < cols; j++) {
				for (int k = 0; k < ups; k++) {
					Vector3 position = new Vector3 (i * 2 - rows, j * 2 - cols, k * 2 - ups);
					GameObject piece = Instantiate (prefab, position, Quaternion.identity) as GameObject;
					pieces.Add (piece);
					rbodies.Add (piece.GetComponent<Rigidbody>());
				}
			}
		}
	}

	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			foreach (Rigidbody rbody in rbodies) {
				rbody.AddExplosionForce (30.0f, Vector3.zero, 50);
			}
		}
	}
}
