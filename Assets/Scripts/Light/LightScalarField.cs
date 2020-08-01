using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightScalarField : ScalarField<Light> {
	public int width = 16;
	public int height = 11;

	public override void Start() {
		SpawnCells((int)Mathf.Floor(-width / 2f), (int)Mathf.Floor(-height / 2f), (int)Mathf.Floor(width / 2f), (int)Mathf.Floor(height / 2f));

		//BUGFIX: center the odd-numbered cells
		transform.position = new Vector3(1f * width % 2f / 2f * 32, 1f * height % 2f / 2f * 32, 0f);
	}
}