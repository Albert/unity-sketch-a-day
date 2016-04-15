using UnityEngine;
using System.Collections;

public class April14CapsuleMover : MonoBehaviour {
	private float speed = 2;
	public bool hasMoved;

	void FixedUpdate () {
		Vector3 originalPosition = transform.position;
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
		transform.position += movement * speed * Time.fixedDeltaTime;
		hasMoved = (transform.position != originalPosition);
	}
}