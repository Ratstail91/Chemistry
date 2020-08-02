using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tool : MonoBehaviour {
	SpriteRenderer spriteRenderer = null;
	BoxCollider2D boxCollider = null;

	public virtual void Awake() {
		spriteRenderer = GetComponent<SpriteRenderer>();
		boxCollider = GetComponent<BoxCollider2D>();
	}

	public virtual void OnPickup() {
		spriteRenderer.enabled = false;
	}

	public virtual void OnDrop() {
		spriteRenderer.enabled = true;
	}

	public virtual void OnUsed() {
		//EMPTY
	}
}