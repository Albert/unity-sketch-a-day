using UnityEngine;
using System.Collections;

public class April21Logic : MonoBehaviour {
	public GameObject prefab;

	void Start () {
	}
	
	void Update () {
		for (int i = 0; i < 4; i++) {
			Vector2 circleSpot = Random.insideUnitCircle * 100;
			Vector3 myPos = new Vector3 (circleSpot.x, 30, circleSpot.y);
			Instantiate (prefab, myPos, Quaternion.identity);
		}
	}
}
