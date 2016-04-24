using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class April20Logic : MonoBehaviour {
	public int levels = 2;
	public GameObject seed;
	public GameObject prefab;
	public List<GameObject> allElements = new List<GameObject> ();
	private float levelHue;

	void Start () {
		float incrementalHue = 1.0f / (float)levels;
		List<GameObject> parents = new List<GameObject> ();
		for (int level = 0; level < levels; level++) {
			levelHue = incrementalHue * level;
			if (level == 0) {
				parents.Add (seed);
			}

			List<GameObject> thisLevelOfObjects = new List<GameObject> ();
			foreach (GameObject objParent in parents) {
				Vector3 direction = Vector3.up;
				for (int i = 0; i < 6; i++) {
					direction = Quaternion.Euler (0, 0, (360 / 6)) * direction;
					thisLevelOfObjects.Add (newForDirection (direction, objParent));
				}
			}
			parents = thisLevelOfObjects;
		}
		allElements.Add (seed);
	}

	void Update () {
		foreach (GameObject el in allElements) {
			el.transform.Rotate (Vector3.up, 1);
			el.transform.Rotate (Vector3.right, 0.35f);
		}
	}

	GameObject newForDirection(Vector3 myDir, GameObject objParent) {
		GameObject newOne = Instantiate (prefab) as GameObject;
		newOne.transform.localPosition = myDir * 1.5f;
		newOne.transform.localScale = Vector3.one * 0.6f;
		newOne.transform.RotateAround (Vector3.forward, 30f);
		newOne.transform.SetParent (objParent.transform, false);
		newOne.GetComponent<Renderer> ().material.color = Color.HSVToRGB (1 - levelHue, 1, 1);
		allElements.Add (newOne);
		return newOne;
	}
}