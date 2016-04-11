using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class April6Logic : MonoBehaviour {
	public GameObject upperArm2;
	public GameObject elbow;
	private Vector3[] upperPoint = new Vector3[5];
	private int upperPointIdx;

	private float[,] outInDown = new float[5, 3];
	private int outInDownIdx;
	int clickIndex = 0;

	private float[] elbowAngles = new float[3];
	public float timeBetween = 0.1f;
	private float lastTick = 0;

	void Start () {
		elbowAngles [0] = 0;
		elbowAngles [1] = -90;
		elbowAngles [2] = -170;
		upperPoint [0] = new Vector3 (1, 0, 0);  // out to side
		outInDown  [0,0] = 0;
		outInDown  [0,1] = 90;
		outInDown  [0,2] = 180;
		upperPoint [1] = new Vector3 (0, 0, -1); // back
		outInDown  [1,0] = 0;
		outInDown  [1,1] = 90;
		outInDown  [1,2] = 180;
		upperPoint [2] = new Vector3 (0, -1, 0); // down
		outInDown  [2,0] = 270;
		outInDown  [2,1] = 0;
		outInDown  [2,2] = 90;
		upperPoint [3] = new Vector3 (0, 0, 1);  // forward
		outInDown  [3,0] = -1;
		outInDown  [3,1] = 0;
		outInDown  [3,2] = 90;
		upperPoint [4] = new Vector3 (0, 1, 0);  // up
		outInDown  [4,0] = -1;
		outInDown  [4,1] = 0;
		outInDown  [4,2] = 90;
	}
	
	void Update () {
		if (Time.time - lastTick > timeBetween) {
			lastTick = Time.time;
			randomAndSet ();
		}
	}

	void incrementAndSet () {
		clickIndex += 1;
		clickIndex = (clickIndex < 5 * 3 * 3) ? clickIndex: 0;
		int elbowIdx = clickIndex % 3;
		int aThirdOfIncrement = Mathf.FloorToInt ((float)clickIndex / 3.0f);
		upperPointIdx = Mathf.FloorToInt ((float)aThirdOfIncrement / 3.0f);
		outInDownIdx = aThirdOfIncrement % 3;
		elbow.transform.localRotation = Quaternion.Euler (elbowAngles[elbowIdx], 0, 0);
		transform.LookAt(transform.position + upperPoint[upperPointIdx]);
		upperArm2.transform.localRotation = Quaternion.Euler(0, 0, outInDown[upperPointIdx,outInDownIdx]);
		if (outInDown [upperPointIdx, outInDownIdx] == -1) {
			incrementAndSet ();
		}
	}

	void randomAndSet() {
		int elbowIdx = Random.Range((int)0, (int)3);
		//int aThirdOfIncrement = Mathf.FloorToInt ((float)clickIndex / 3.0f);
		upperPointIdx = Random.Range((int)0, (int)5);
		outInDownIdx = Random.Range((int)0, (int)3);
		elbow.transform.localRotation = Quaternion.Euler (elbowAngles[elbowIdx], 0, 0);
		transform.LookAt(transform.position + upperPoint[upperPointIdx]);
		upperArm2.transform.localRotation = Quaternion.Euler(0, 0, outInDown[upperPointIdx,outInDownIdx]);
		if (outInDown [upperPointIdx, outInDownIdx] == -1) {
			randomAndSet ();
		}
	}
}
