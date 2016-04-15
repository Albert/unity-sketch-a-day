using UnityEngine;
using System.Collections;

public class April14TileGenerator : MonoBehaviour {
	public GameObject tilePrefab;
	public GameObject thingToWatch;
	public int tilesPerDim = 50;

	void Start () {
		for (int i = 0; i < tilesPerDim; i++) {
			for (int j = 0; j < tilesPerDim; j++) {
				Vector3 tilePosition = new Vector3 (i - tilesPerDim / 2, 0, j - tilesPerDim / 2);
				GameObject newTile = Instantiate(tilePrefab, tilePosition, Quaternion.identity) as GameObject;
				newTile.GetComponent<April14TileAssembler> ().thingToWatch = thingToWatch;
			}
		}
	}
}