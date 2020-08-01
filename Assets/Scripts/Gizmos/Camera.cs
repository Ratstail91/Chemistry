using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour {
	void OnDrawGizmos() {
		Gizmos.color = Color.red;

		Vector3 start, end;

		//horizontal
		for (int i = -100; i < 100; i++) {
			start.x = i * 32 * 16 + 32 * 8;
			start.y = -100 * 32 * 16 + 32 * 8;
			start.z = 0;
			end.x = i * 32 * 16 + 32 * 8;
			end.y = 100 * 32 * 16 + 32 * 8;
			end.z = 0;
			Gizmos.DrawLine(start, end);
		}

		//vertical
		for (int i = -100; i < 100; i++) {
			start.x = -100 * 32 * 11 + 32 * 5.5f;
			start.y = i * 32 * 11 + 32 * 5.5f;
			start.z = 0;
			end.x = 100 * 32 * 11 + 32 * 5.5f;
			end.y = i * 32 * 11 + 32 * 5.5f;
			end.z = 0;
			Gizmos.DrawLine(start, end);
		}
	}
}