using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeatScalarCell : ScalarCell<Heat> {
	const float maxEmitterValue = 99f;
	float realEmitterValue = 0f;

	void OnTriggerEnter2D(Collider2D collider) {
		HeatScalarEmitter emitter = collider.gameObject.GetComponent<HeatScalarEmitter>();

		if (emitter != null) {
			realEmitterValue += emitter.Value;

			EmitterValue = Mathf.Clamp(realEmitterValue, 0f, maxEmitterValue);
		}
	}

	void OnTriggerExit2D(Collider2D collider) {
		HeatScalarEmitter emitter = collider.gameObject.GetComponent<HeatScalarEmitter>();

		if (emitter != null) {
			realEmitterValue -= emitter.Value;

			EmitterValue = Mathf.Clamp(realEmitterValue, 0f, maxEmitterValue);
		}
	}
}