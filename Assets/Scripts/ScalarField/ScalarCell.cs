using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScalarCell<T> : MonoBehaviour {
	//the usable values
	public Vector2Int position = new Vector2Int(0, 0);

	//the field properties
	public float RealValue = 0f;
	public float NextValue = 0f;
	public float EmitterValue = 0f; //set externally

	const float epsilon = 0.001f;

	ScalarField<T> field;

	public virtual void Start() {
		field = GetComponentInParent<ScalarField<T>>();
	}

	public virtual void FixedUpdate() {
		CalculateRealValue();
	}

	public virtual void CalculateRealValue() {
		//emitter propping the scalar field up here
		if (EmitterValue != 0f) {
			RealValue = EmitterValue;
			NextValue = RealValueLerp(EmitterValue);
			return;
		}

		//set to the value calculated last frame
		RealValue = RealValueLerp(NextValue);

		//calculate the next value based on neighbouring cells' current value
		float next = 0f;

		const float cardinal = 0.75f;
		const float diagonal = 0.25f;

		//cardinal
		next += GetCellRealValueOrZero(position.x-1, position.y) * cardinal;
		next += GetCellRealValueOrZero(position.x+1, position.y) * cardinal;
		next += GetCellRealValueOrZero(position.x, position.y-1) * cardinal;
		next += GetCellRealValueOrZero(position.x, position.y+1) * cardinal;

		//diagonal
		next += GetCellRealValueOrZero(position.x-1, position.y-1) * diagonal;
		next += GetCellRealValueOrZero(position.x+1, position.y-1) * diagonal;
		next += GetCellRealValueOrZero(position.x-1, position.y+1) * diagonal;
		next += GetCellRealValueOrZero(position.x+1, position.y+1) * diagonal;

		next /= 4f;

		//finally, calculate how different from the entropy the cell should be next frame
		NextValue = Mathf.Abs(next) > epsilon ? next : 0f;
	}

	//utility
	float GetCellRealValueOrZero(int x, int y) {
		if (field.cells.ContainsKey((x, y))) {
			return field.cells[(x, y)].RealValue;
		} else {
			return 0f;
		}
	}

	public virtual float RealValueLerp(float f) { //for the light system
		return f;
	}
}