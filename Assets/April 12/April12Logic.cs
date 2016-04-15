using UnityEngine;
using System.Collections;

public class April12Logic : MonoBehaviour {
	public GameObject prefab;
	public GameObject myCamera;
	private int numOfCubes = 10000;
	private float cameraDepth = 150;
	private Vector3 initialCameraSpot;
	private float animationLength = 4;

	void Start () {
		initialCameraSpot = new Vector3 (0, 0, cameraDepth);
		for (int i = 0; i < numOfCubes; i++) {
			int sqrtNum = Mathf.RoundToInt (Mathf.Sqrt(numOfCubes));
			int col = i % sqrtNum - sqrtNum / 2;// - (Mathf.Sqrt(numOfCubes) / 2);
			int row = lossyDivide(i, Mathf.Sqrt(numOfCubes)) - sqrtNum / 2;
			Vector3 planePosition = new Vector3 (col, row, 0);
			Vector3 startDistToCamera = planePosition - initialCameraSpot;
			Vector3 endDistToCamera = startDistToCamera * Random.Range (0.7f, 2.0f);
			Vector3 position = initialCameraSpot + endDistToCamera;
			Instantiate (prefab, position, Quaternion.identity);
		}
	}

	void Update () {
		Vector3 cameraPosition = Vector3.Slerp (Vector3.left, Vector3.back, Time.time / animationLength) * (-1 * cameraDepth);
		myCamera.transform.position = cameraPosition;
		myCamera.transform.LookAt (Vector3.zero);
	}

	int lossyDivide(int   num, int   den) { return Mathf.FloorToInt ((float) num / (float) den); }
	int lossyDivide(float num, int   den) { return lossyDivide ((int)num,      den); }
	int lossyDivide(int   num, float den) { return lossyDivide (     num, (int)den); }
	int lossyDivide(float num, float den) { return lossyDivide ((int)num, (int)den); }
}
