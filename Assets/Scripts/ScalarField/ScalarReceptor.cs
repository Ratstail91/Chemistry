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
		Collide(collider.gameObject);
	}

	public virtual void OnTriggerStay2D(Collider2D collider) {
		Collide(collider.gameObject);
	}

	public virtual void Collide(GameObject go) {
		ScalarCell<T> contact = go.GetComponent<ScalarCell<T>>();

		if (contact != null) {
			if (lastScalarCell != null) {
				lastScalarCell = lastScalarCell.RealValue >= contact.RealValue ? lastScalarCell : contact;
			} else {
				lastScalarCell = contact;
			}
		}
	}
}