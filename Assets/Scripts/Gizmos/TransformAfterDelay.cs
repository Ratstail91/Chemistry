using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformAfterDelay : MonoBehaviour {
	public float delay = 0f;
	public GameObject result = null;

	void Start() {
		StartCoroutine(TransformAfter(delay));
	}

	IEnumerator TransformAfter(float _delay) {
		yield return new WaitForSeconds(_delay);
		Instantiate(result, transform.position, transform.rotation, transform.parent);
		Destroy(gameObject);
	}
}