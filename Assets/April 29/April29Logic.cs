using UnityEngine;
using System.Collections;

public class April29Logic : MonoBehaviour {
	public GameObject prefab;
	public GameObject numberCandles;
	public int yearsOld;
	private float candleHeight = 1.1591f;
	private float placementRadius = 0.15f;

	void Start () {
		numberCandles.GetComponent<TextMesh> ().text = yearsOld.ToString ();
		for (int i = 0; i < yearsOld; i++) {
			float phase = ((float)i / (float)yearsOld) * 2.0f * Mathf.PI;
			float goX = Mathf.Sin (phase) * placementRadius;
			float goZ = Mathf.Cos (phase) * placementRadius;
			Vector3 goPosition = new Vector3 (goX, candleHeight, goZ);
			GameObject go = Instantiate (prefab, goPosition, Quaternion.identity) as GameObject;
		}
	}

	void Update () {

	}
}
