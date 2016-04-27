using UnityEngine;
using System.Collections;

public class April25Logic : MonoBehaviour {
	public GameObject prefab;
	public GameObject lightObj;
	private int perDim = 10;
	private int halfPerDim;

	void Start () {
		halfPerDim = perDim / 2;
		for (int i = 0; i < perDim; i++) {
			for (int j = 0; j < perDim; j++) {
				for (int k = 0; k < perDim; k++) {
					Instantiate (prefab, new Vector3 (i - halfPerDim, j - halfPerDim, k - halfPerDim), Quaternion.identity);
				}
			}
		}
	}
	
	void Update () {
		float x = Mathf.Sin (Time.time) * halfPerDim;
		float y = Mathf.Cos (Time.time * 1.3f) * halfPerDim;
		float z = Mathf.Sin (Time.time + 123) * halfPerDim;
		lightObj.transform.position = new Vector3 (x, y, z);
	}
}
