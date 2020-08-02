using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeatScalarCell : ScalarCell<Heat> {
	const float maxEmitterValue = 99f;
	HashSet<HeatScalarEmitter> heatScalarEmitters = new HashSet<HeatScalarEmitter>();

	void Update() {
		float max = 0;

		foreach (HeatScalarEmitter emitter in heatScalarEmitters) {
			max = Mathf.Max(max, emitter.Value);
		}

		EmitterValue = Mathf.Clamp(max, 0, maxEmitterValue);
	}

	void OnTriggerEnter2D(Collider2D collider) {
		HeatScalarEmitter emitter = collider.gameObject.GetComponent<HeatScalarEmitter>();

		if (emitter != null && !heatScalarEmitters.Contains(emitter)) {
			heatScalarEmitters.Add(emitter);
		}
	}

	void OnTriggerExit2D(Collider2D collider) {
		HeatScalarEmitter emitter = collider.gameObject.GetComponent<HeatScalarEmitter>();

		heatScalarEmitters.Remove(emitter);
	}
}