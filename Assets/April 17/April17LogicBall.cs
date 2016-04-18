using UnityEngine;
using System.Collections;

public class April17LogicBall : MonoBehaviour {
	void Start() {
		GetComponent<Renderer> ().material.color = Random.ColorHSV();
	}
	void Update () {
		if (transform.position.y < -1) {
			Destroy (gameObject);
		}
	}
}
