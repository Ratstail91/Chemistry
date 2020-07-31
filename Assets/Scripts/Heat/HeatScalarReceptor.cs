using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeatScalarReceptor : ScalarReceptor<Heat> {
	public bool combustable = false;
	public GameObject combustResult = null;
	public float combustThreshold = 1f;

	void Update() {
		if (combustable && Value >= combustThreshold) {
			Instantiate(combustResult, transform.position, transform.rotation, transform.parent);
			Destroy(gameObject);
		}
	}
}