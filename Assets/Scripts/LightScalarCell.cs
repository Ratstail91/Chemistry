using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightScalarCell : MonoBehaviour {
	//components
	SpriteRenderer spriteRenderer;
	ScalarCell scalarCell;

	const float maxEmitterValue = 6f;
	float realEmitterValue = 0f;

	//TODO: sunlight

	void Awake() {
		spriteRenderer = GetComponent<SpriteRenderer>();
		scalarCell = GetComponent<ScalarCell>();
	}

	void Update() {
		//update opacity
		float opacity = 1 - Mathf.Clamp(scalarCell.RealValue, 0f, 1f);
		spriteRenderer.color = new Color(1, 1, 1, opacity);
	}

	void OnTriggerEnter2D(Collider2D collider) {
		LightScalarEmitter emitter = collider.gameObject.GetComponent<LightScalarEmitter>();

		if (emitter != null) {
			realEmitterValue += emitter.Value;

			scalarCell.EmitterValue = Mathf.Clamp(realEmitterValue, 0f, maxEmitterValue);
		}
	}

	void OnTriggerExit2D(Collider2D collider) {
		LightScalarEmitter emitter = collider.gameObject.GetComponent<LightScalarEmitter>();

		if (emitter != null) {
			realEmitterValue -= emitter.Value;

			scalarCell.EmitterValue = Mathf.Clamp(realEmitterValue, 0f, maxEmitterValue);
		}
	}
}