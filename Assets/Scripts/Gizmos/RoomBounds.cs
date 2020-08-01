using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomBounds : MonoBehaviour {
	[SerializeField]
	GameObject playerObject = null;

	[SerializeField]
	int shiftX = 0;

	[SerializeField]
	int shiftY = 0;

	[SerializeField]
	int playerJumpX = 0;

	[SerializeField]
	int playerJumpY = 0;

	[SerializeField]
	GameObject movingGrid = null;

	void OnCollisionEnter2D(Collision2D collision) {
		if (collision.gameObject != playerObject) {
			return;
		}

		StartCoroutine(ShiftGrid());
	}

	IEnumerator ShiftGrid() {
		playerObject.transform.position += new Vector3(playerJumpX + Mathf.Sign(playerJumpX), playerJumpY + Mathf.Sign(playerJumpY), 0); //BUGFIX: jump an extra unit

		playerObject.GetComponent<PlayerController>().ControlsEnabled = false;

		int x = shiftX;
		int y = shiftY;
		int speed = 3;

		while (Mathf.Abs(x) > 0 || Mathf.Abs(y) > 0) {
			Vector3 shift = new Vector3(
				Mathf.Abs(x) > speed ? speed * (int)Mathf.Sign(x) : x,
				Mathf.Abs(y) > speed ? speed * (int)Mathf.Sign(y) : y,
				0);

			x -= (int)shift.x;
			y -= (int)shift.y;

			movingGrid.transform.position += shift;
			playerObject.transform.position += shift;

			yield return null;
		}

		//TODO: load new room contents

		playerObject.GetComponent<PlayerController>().ControlsEnabled = true;
	}
}