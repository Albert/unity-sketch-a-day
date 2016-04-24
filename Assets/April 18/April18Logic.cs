using UnityEngine;
using System.Collections;

public class April18Logic : MonoBehaviour {
	public GameObject[] subjects;
	public GameObject halo;
	private int myIndex = 1;
	private float timePressed = 0;
	private float animationLength = 0.5f;
	private Vector3 fromLocation;
	private Light haloLight;

	void Start () {
		fromLocation = Vector3.zero;
		haloLight = halo.GetComponent<Light> ();
	}
	
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			myIndex = (myIndex == 1) ? 0 : 1;
			timePressed = Time.time;
			fromLocation = halo.transform.position;
		}
		float t = (Time.time - timePressed) / animationLength;
		Vector3 newPosition = Vector3.Lerp (fromLocation, subjects [myIndex].transform.position, t);
		haloLight.range = Mathf.Lerp (10, 0, t);
		haloLight.intensity = Mathf.Lerp (0, 2, t);
		halo.transform.position = newPosition;
	}
}
