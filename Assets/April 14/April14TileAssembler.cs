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
		float scaleT = (distance - 2) / 10;
		float scale = Mathf.Lerp (1, 0, scaleT);

		float offsetT = (distance - 2) / 10;
		Vector3 offset = Vector3.Lerp (myPosition, myPosition + randomOffset, offsetT);
		Quaternion rotation = Quaternion.Lerp (Quaternion.identity, randomRotation, offsetT);

		transform.localScale = new Vector3 (scale, scale, scale);
		transform.position = offset;
		transform.rotation = rotation;
	}
}