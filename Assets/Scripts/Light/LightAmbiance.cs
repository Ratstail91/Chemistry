using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class LightAmbiance {
	//private backing variables
	static float _value = 1f;

	public static float Value {
		get {
			if (Oscillate) {
				_value = Mathf.Abs(Time.time / (Duration / 2f) % 2f - 1) * (Max - Min) + Min;
			}

			return _value;
		}
		set {
			_value = value;
		}
	}

	public static float Max { get; set; } = 2f;
	public static float Min { get; set; } = -0.5f;
	public static bool Oscillate { get; set; } = true;
	public static float Duration { get; set; } = 120f;
}