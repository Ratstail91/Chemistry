using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class LightAmbiance {
	static float _value = 1f;

	public static float Value {
		get {
			//_value = 2 <-> -0.5
			_value = Mathf.Abs(Time.time / 60 % 2f - 1) * 2.5f - 0.5f;

			return _value;
		}
	}
}