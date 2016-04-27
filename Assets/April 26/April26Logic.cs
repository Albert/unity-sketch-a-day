using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class April26Logic : MonoBehaviour {
	public GameObject prefab;
	private List<GameObject> pieces;
	private int length = 80;

	void Start () {
		pieces = new List<GameObject> ();
		for (int i = 0; i < length; i++) {
			GameObject newPiece = Instantiate (prefab, new Vector3 (i, 0, 0), Quaternion.identity) as GameObject;
			pieces.Add (newPiece);
		}
	}
	
	void Update () {
		for (int i = 0; i < length; i++) {
			GameObject piece = pieces [i];
			float rotMag = Mathf.Sin (Time.time + (float) i * 0.2f) * 90;
			piece.transform.rotation = Quaternion.Euler (Vector3.right * rotMag);
		}
	}
}
