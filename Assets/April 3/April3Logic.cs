using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class April3Logic : MonoBehaviour {
	public GameObject prefab;
	private List<GameObject> pieces;
	private List<Vector3> piecePositions;
	public GameObject focus;
	private float r = 10;

	void Start () {
		pieces = new List<GameObject> ();
		piecePositions = new List<Vector3> ();
		for (int i = 0; i < 300; i++) {
			Vector3 position = new Vector3 (Random.Range(-r, r), Random.Range(-r, r), Random.Range(-r, r));
			GameObject piece = Instantiate (prefab, position, Quaternion.identity) as GameObject;
			pieces.Add (piece);
			piecePositions.Add (position);
		}
	}
	
	void Update () {
		Vector3 focusPosition = new Vector3 (modulate("sin", 1, 5), modulate("cos", 3, 2), modulate("sin", 0.5f, 5));
		focus.transform.position = focusPosition;
		for (int i = 0; i < pieces.Count; i++) {
			GameObject piece = pieces [i];
			Vector3 piecePosition = piecePositions [i];
			Vector3 differenceVec = focusPosition - piecePosition;
			float initialMag = differenceVec.magnitude;
			float newMag = Mathf.Lerp (10, 0, initialMag / 20.0f);
			piece.transform.position = piecePosition - differenceVec.normalized * newMag * 0.75f;
		}
	}

	float modulate(string sinOrCos, float timeMultiplier, float magnitude) {
		float outputVal = 0;
		if (sinOrCos.ToLower ().Equals ("cos")) {
			outputVal = Mathf.Cos (Time.time * timeMultiplier);
		} else {
			outputVal = Mathf.Sin (Time.time * timeMultiplier);
		}
		outputVal *= magnitude;
		return outputVal;
	}
}
