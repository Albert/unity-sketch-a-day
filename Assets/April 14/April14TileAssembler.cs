using UnityEngine;
using System.Collections;

public class April14TileAssembler : MonoBehaviour {
	public GameObject thingToWatch { set; get; }
	private Vector3 myPosition;
	private April14CapsuleMover capMover;
	private Vector3 randomOffset;
	private Quaternion randomRotation;

	void Start () {
		myPosition = transform.position;
		randomOffset = Random.insideUnitSphere * 3;
		randomRotation = Random.rotation;
		assembleDisassemble ();

		capMover = thingToWatch.GetComponent<April14CapsuleMover> ();
	}
	
	void Update () {
		if (capMover.hasMoved) {
			assembleDisassemble ();
		}
	}

	void assembleDisassemble() {
		float distance = (thingToWatch.transform.position - myPosition).magnitude;
		float scaleT = (distance - 2) / 5;
		float scale = Mathf.Lerp (1, 0, scaleT);

		float offsetT = (distance - 3) / 3;
		float rotationT = (distance - 2) / 2;
		Vector3 offset = Vector3.Lerp (myPosition, myPosition + randomOffset, Mathf.SmoothStep(0.0f, 1.0f, offsetT));
		//Vector3 offset = Vector3.Lerp (myPosition, myPosition + randomOffset, offsetT);
		Quaternion rotation = Quaternion.Lerp (Quaternion.identity, randomRotation, rotationT);

		float downUpT = (distance - 2) / 3;
		Vector3 downUpOffset = Vector3.Lerp (offset, offset + Vector3.down * 0.5f, Mathf.SmoothStep(0.0f, 1.0f, downUpT));

		transform.localScale = new Vector3 (scale, scale * 0.1f, scale);
		transform.position = downUpOffset;
		transform.rotation = rotation;
	}
}