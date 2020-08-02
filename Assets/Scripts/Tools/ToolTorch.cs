using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolTorch : Tool {
	LightScalarEmitter lightScalarEmitter;
	HeatScalarEmitter heatScalarEmitter;

	bool isUsing = false;

	public override void Awake() {
		base.Awake();
		lightScalarEmitter = GetComponent<LightScalarEmitter>();
		heatScalarEmitter = GetComponent<HeatScalarEmitter>();
	}

	public override void OnUsed() {
		base.OnUsed();
		StartCoroutine(Use());
	}

	IEnumerator Use() {
		if (!isUsing) {
			isUsing = true;

			lightScalarEmitter.Value += 1;
			heatScalarEmitter.Value += 1;

			yield return new WaitForSeconds(0.1f);

			lightScalarEmitter.Value -= 1;
			heatScalarEmitter.Value -= 1;

			isUsing = false;
		}
	}
}