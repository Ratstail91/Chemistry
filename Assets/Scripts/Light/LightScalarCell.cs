using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightScalarCell : ScalarCell<Light> {
	//components
	SpriteRenderer spriteRenderer;

	//TODO: opacity as a receptor?
	const float maxEmitterValue = 10f;
	float realEmitterValue = 0f;

	void Awake() {
		spriteRenderer = GetComponent<SpriteRenderer>();
	}

	void Update() {
		//update opacity
		float opacity = 1 - Mathf.Clamp(RealValue + LightAmbiance.Value, 0f, 1f);
		spriteRenderer.color = new Color(1, 1, 1, opacity);
	}

	public override float RealValueLerp(float f) {
		return Mathf.Lerp(RealValue, f, 0.5f);
	}

	void OnTriggerEnter2D(Collider2D collider) {
		LightScalarEmitter emitter = collider.gameObject.GetComponent<LightScalarEmitter>();

		if (emitter != null) {
			realEmitterValue += emitter.Value;

			EmitterValue = Mathf.Clamp(realEmitterValue, 0f, maxEmitterValue);
		}
	}

	void OnTriggerExit2D(Collider2D collider) {
		LightScalarEmitter emitter = collider.gameObject.GetComponent<LightScalarEmitter>();

		if (emitter != null) {
			realEmitterValue -= emitter.Value;

			EmitterValue = Mathf.Clamp(realEmitterValue, 0f, maxEmitterValue);
		}
	}
}