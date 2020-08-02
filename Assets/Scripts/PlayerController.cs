using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	//references
	[SerializeField]
	GameObject movingEntityParent = null;

	//components
	Animator animator;
	Rigidbody2D rb;
	SpriteRenderer spriteRenderer;

	//controls
	public bool ControlsEnabled = true;

	//cached input
	const float deadZone = 0.15f;
	float horizontalInput = 0f;
	float verticalInput = 0f;
	float lastHorizontalInput = 0f;
	float lastVerticalInput = 0f;
	bool pickupPressed = false;
	bool usePressed = false;

	//movement constants
	const float maxSpeed = 400;
	const float moveForce = 800f;

	//usable tools
	GameObject currentTool = null;
	GameObject collidedTool = null;

	void Awake() {
		animator = GetComponent<Animator>();
		rb = GetComponent<Rigidbody2D>();
		spriteRenderer = GetComponent<SpriteRenderer>();
	}

	void Update() {
		HandleInput();
	}

	void FixedUpdate() {
		HandleMovement();
		HandleAnimation();
	}

	void OnTriggerEnter2D(Collider2D collider) {
		if (collider.gameObject.GetComponent<Tool>() != null) {
			collidedTool = collider.gameObject;
		}
	}

	void OnTriggerExit2D(Collider2D collider) {
		if (collider.gameObject == collidedTool) {
			collidedTool = null;
		}
	}

	void HandleInput() {
		horizontalInput = InputLayer.GetAxis(InputLayer.Axis.HORIZONTAL);
		verticalInput = InputLayer.GetAxis(InputLayer.Axis.VERTICAL);
		pickupPressed = InputLayer.GetButtonDown(InputLayer.Button.PICKUP);
		usePressed = InputLayer.GetButtonDown(InputLayer.Button.USE);

		if (!ControlsEnabled) {
			horizontalInput = verticalInput = 0;
			pickupPressed = false;
		}

		if (Mathf.Abs(horizontalInput) > deadZone) {
			lastHorizontalInput = horizontalInput;
			if (Mathf.Abs(verticalInput) <= deadZone) {
				lastVerticalInput = 0f;
			}
		}

		if (Mathf.Abs(verticalInput) > deadZone) {
			lastVerticalInput = verticalInput;
			if (Mathf.Abs(horizontalInput) <= deadZone) {
				lastHorizontalInput = 0f;
			}
		}

		if (pickupPressed) {
			HandlePickupCollidedTool();
			pickupPressed = false;
		}

		if (usePressed) {
			HandleUseCurrentTool();
			usePressed = false;
		}
	}

	void HandleMovement() {
		//stop the player if input in that direction has been removed
		if (horizontalInput * rb.velocity.x <= 0) {
			rb.velocity = new Vector2(rb.velocity.x * 0.85f, rb.velocity.y);
		}

		if (verticalInput * rb.velocity.y <= 0) {
			rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.85f);
		}

		//move in the inputted direction, if not at max speed
		if (horizontalInput * rb.velocity.x < maxSpeed) {
			rb.AddForce(Vector2.right * horizontalInput * moveForce);
		}

		if (verticalInput * rb.velocity.y < maxSpeed) {
			rb.AddForce(Vector2.up * verticalInput * moveForce);
		}

		//slow the player down when it's travelling too fast
		if (Mathf.Abs(rb.velocity.x) > maxSpeed) {
			rb.velocity = new Vector2(Mathf.Sign(rb.velocity.x) * maxSpeed, rb.velocity.y);
		}

		if (Mathf.Abs(rb.velocity.y) > maxSpeed) {
			rb.velocity = new Vector2(rb.velocity.x, Mathf.Sign(rb.velocity.y) * maxSpeed);
		}

		//check diagonal speed
		if (rb.velocity.magnitude > maxSpeed) {
			rb.velocity = rb.velocity * 0.707f;
		}
	}

	void HandlePickupCollidedTool() {
		//drop your current tool
		if (currentTool != null) {
			currentTool.GetComponent<Tool>().OnDrop();
			currentTool.transform.SetParent(movingEntityParent.transform, true);

			if (collidedTool == null) {
				collidedTool = currentTool;
				currentTool = null;
				return;
			} else {
				currentTool = null;
			}
		}

		//pickup the last tool you encountered in the ground
		if (collidedTool != null) {
			currentTool = collidedTool;
			currentTool.GetComponent<Tool>().OnPickup();
			currentTool.transform.SetParent(gameObject.transform);
			currentTool.transform.position = gameObject.transform.position;
			collidedTool = null;
		}
	}

	void HandleUseCurrentTool() {
		if (currentTool == null) {
			return;
		}

		currentTool.GetComponent<Tool>().OnUsed();
	}

	void HandleAnimation() {
		animator.SetFloat("horizontal", lastHorizontalInput);
		animator.SetFloat("vertical", lastVerticalInput);

		animator.SetFloat("speed", Mathf.Abs(horizontalInput) > deadZone || Mathf.Abs(verticalInput) > deadZone ? 1 : 0);
		spriteRenderer.flipX = lastHorizontalInput < 0; //HACK: animation system was struggling with this
	}
}