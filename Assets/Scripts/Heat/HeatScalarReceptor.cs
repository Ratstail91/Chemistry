using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeatScalarReceptor : ScalarReceptor<Heat> {
	public bool combustible = false;
	public GameObject combustResult = null;
	public float combustThreshold = 1f;

	void Update() {
		if (combustible && Value >= combustThreshold) {
			Instantiate(combustResult, transform.position, transform.rotation, transform.parent);
			Destroy(gameObject);
		}
	}
}