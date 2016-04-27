using UnityEngine;
using System.Collections;

public class April27Logic : MonoBehaviour {
	public GameObject prefab;
	private int numOfLights = 3;
	private GameObject[] gos;
	private float TAU;

	void Start () {
		TAU = Mathf.PI * 2;
		gos = new GameObject[numOfLights];
		for (int i = 0; i < gos.Length; i++) {
			GameObject go = Instantiate (prefab) as GameObject;
			Light l = go.GetComponent<Light> ();
			if (i % 3 == 0) { l.color = Color.red; }
			if (i % 3 == 1) { l.color = Color.blue; }
			if (i % 3 == 2) { l.color = Color.green; }
			gos [i] = go;
		}
	}
	
	void Update () {
		for (int i = 0; i < gos.Length; i++) {
			GameObject go = gos [i];
			float iPortion = (float) i / gos.Length;
			float offsetMag = Mathf.Sin (Time.time * 0.4f) * 0.1f;
			float xOffset = Mathf.Sin (TAU * iPortion + Time.time * 2) * offsetMag;
			float zOffset = Mathf.Cos (TAU * iPortion + Time.time * 2) * offsetMag;
			Vector3 offset = new Vector3(xOffset, 0, zOffset);
			go.transform.LookAt (go.transform.position + Vector3.down + offset);
		}
	}
}
