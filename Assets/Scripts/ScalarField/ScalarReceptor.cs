using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScalarReceptor<T> : MonoBehaviour {
	public float Value {
		get {
			return lastScalarCell != null ? lastScalarCell.RealValue : 0f;
		}
		private set {
			//
		}
	}

	ScalarCell<T> lastScalarCell;

	public virtual void OnTriggerEnter2D(Collider2D collider) {
		ScalarCell<T> contact = collider.gameObject.GetComponent<ScalarCell<T>>();

		if (contact != null) {
			lastScalarCell = contact;
		}
	}
}