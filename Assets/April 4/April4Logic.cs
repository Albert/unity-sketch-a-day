using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class April4Logic : MonoBehaviour {
	private List<GameObject> lineSegments;
	private Vector3 lastPos;
	public int maxLength = 50;

	void Start () {
		lineSegments = new List<GameObject> ();
		lastPos = Vector3.zero;
	}
	
	void Update () {
		GameObject go = new GameObject ();
		LineRenderer lr = go.AddComponent<LineRenderer> ();
		Material whiteDiffuseMat = new Material(Shader.Find("Unlit/Texture"));
		lr.material = whiteDiffuseMat;
		lr.material = new Material(Shader.Find("Particles/Additive"));
		lr.SetPositions(new Vector3[]{lastPos, Input.mousePosition / 50});
		lastPos = Input.mousePosition / 50;
		lineSegments.Add (go);
		if (lineSegments.Count > maxLength) {
			DestroyObject(lineSegments[0]);
			lineSegments.RemoveAt (0);
		}
		for (int i = 0; i < lineSegments.Count; i++) {
			LineRenderer thisLr = lineSegments[i].GetComponent<LineRenderer> ();
			Color myColor = Color.HSVToRGB ((float)i / (float)lineSegments.Count, 1, 1);
			thisLr.SetColors (myColor, myColor);
		}
	}
}