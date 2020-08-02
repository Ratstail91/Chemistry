using System;
using System.Collections.Generic;
using UnityEngine;

//DOCS: This layer wraps all input devices
//DOCS: INPUT_KEYBOARD falls back to the legacy unity input system
//DOCS: INPUT_JOYCON is reserved for switch input

public static class InputLayer {
	//virtual inputs
	public enum Button {
		PAUSE, PICKUP, USE
	}

	public enum Axis {
		HORIZONTAL, VERTICAL
	}

	//persistent axes: -1 to 1
	static float axisHorizontal = 0f;
	static float axisVertical = 0f;

	const float GRAVITY = 1000f;
	const float SENSITIVITY = 1000f;

	//initialize & quit the hardware
	public static void Init() {
#if INPUT_KEYBOARD
		//EMPTY
#else
		throw new InvalidOperationException("method not implemented");
#endif
	}

	public static void Quit() {
#if INPUT_KEYBOARD
		//EMPTY
#else
		throw new InvalidOperationException("method not implemented");
#endif
	}

	//wrapped inputs
	public static bool GetButton(Button button) {
#if INPUT_KEYBOARD
		switch(button) {
			case Button.PAUSE:
				return Input.GetButton("Pause");
			case Button.PICKUP:
				return Input.GetButton("Pickup");
			case Button.USE:
				return Input.GetButton("Use");
			default:
				throw new ArgumentException("unknown button");
		}
#else
		throw new InvalidOperationException("method not implemented");
#endif
	}

	public static bool GetButtonDown(Button button) {
#if INPUT_KEYBOARD
		switch(button) {
			case Button.PAUSE:
				return Input.GetButtonDown("Pause");
			case Button.PICKUP:
				return Input.GetButtonDown("Pickup");
			case Button.USE:
				return Input.GetButtonDown("Use");
			default:
				throw new ArgumentException("unknown button");
		}
#else
		throw new InvalidOperationException("method not implemented");
#endif
	}

	public static bool GetButtonUp(Button button) {
#if INPUT_KEYBOARD
		switch(button) {
			case Button.PAUSE:
				return Input.GetButtonUp("Pause");
			case Button.PICKUP:
				return Input.GetButtonUp("Pickup");
			case Button.USE:
				return Input.GetButtonUp("Use");
			default:
				throw new ArgumentException("unknown button");
		}
#else
		throw new InvalidOperationException("method not implemented");
#endif
	}

	public static float GetAxis(Axis axis) {
#if INPUT_KEYBOARD
		switch(axis) {
			case Axis.VERTICAL:
				return axisVertical = GetSmoothedAxis(Axis.VERTICAL, axisVertical, SENSITIVITY, GRAVITY);
			case Axis.HORIZONTAL:
				return axisHorizontal = GetSmoothedAxis(Axis.HORIZONTAL, axisHorizontal, SENSITIVITY, GRAVITY);
			default:
				throw new ArgumentException("unknown axis");
		}
#else
		throw new InvalidOperationException("method not implemented");
#endif
	}

	//utilities
	private static float GetSmoothedAxis(Axis axis, float oldAxis, float sensitivity, float gravity) {
		//the raw input from the hardware
		float rawInput = 0f;

#if INPUT_KEYBOARD
		//fallback to the legacy input system
		switch(axis) {
			case Axis.VERTICAL:
				rawInput = Input.GetAxisRaw("Vertical");
				break;

			case Axis.HORIZONTAL:
				rawInput = Input.GetAxisRaw("Horizontal");
				break;

			default:
				throw new ArgumentException("unknown raw axis");
		}
#else
		throw new InvalidOperationException("utility method not implemented");
#endif

		//smooth out the input
		if (rawInput != 0) {
			return Mathf.Clamp(oldAxis + rawInput * sensitivity * Time.unscaledDeltaTime, -1f, 1f);
		} else {
			return Mathf.Clamp01(Mathf.Abs(oldAxis) - gravity * Time.unscaledDeltaTime) * Mathf.Sign(oldAxis);
		}
	}

	//TODO: capture joycon hardware state once per frame
}