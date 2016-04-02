using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class April1Logic : MonoBehaviour {
	public GameObject prefab;
	public int rows = 20;
	public int cols = 20;
	public int ups = 1;
	private List<GameObject> pieces;
	public GameObject focus;

	void Start () {
		pieces = new List<GameObject> ();
		for (int i = 0; i < rows; i++) {
			for (int j = 0; j < cols; j++) {
				for (int k = 0; k < ups; k++) {
					Vector3 newPosition = new Vector3 (i * 2 - rows, j * 2 - cols, k * 2 - ups);
					GameObject piece = Instantiate (prefab, newPosition, Quaternion.identity) as GameObject;
					///piece.transform.localScale = new Vector3 (0.5f, 0.5f, 0.5f);
					pieces.Add (piece);
				}
			}
		}
	}

	void Update () {
		Vector3 lookAtLocation = new Vector3 (Mathf.Sin (Time.time * 2) * 20, Mathf.Cos (Time.time * 2) * 20, -20);
		focus.transform.position = lookAtLocation;
		foreach (GameObject piece in pieces) {
			piece.transform.LookAt (focus.transform);
		}
	}
}
