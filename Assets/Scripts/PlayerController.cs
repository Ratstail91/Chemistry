using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	//components
	Animator animator;
	Rigidbody2D rb;
	SpriteRenderer spriteRenderer;

	//cached input
	const float deadZone = 0.15f;
	float horizontalInput = 0f;
	float verticalInput = 0f;
	float lastHorizontalInput = 0f;
	float lastVerticalInput = 0f;

	//movement constants
	const float maxSpeed = 400;
	const float moveForce = 800f;

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

	void HandleInput() {
		horizontalInput = Input.GetAxis("Horizontal");
		verticalInput = Input.GetAxis("Vertical");

		if (Mathf.Abs(horizontalInput) > deadZone) {
			lastHorizontalInput = horizontalInput;
		}

		if (Mathf.Abs(verticalInput) > deadZone) {
			lastVerticalInput = verticalInput;
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

	void HandleAnimation() {
		animator.SetFloat("horizontal", lastHorizontalInput);
		animator.SetFloat("vertical", lastVerticalInput);

		animator.SetFloat("speed", Mathf.Abs(horizontalInput) > deadZone || Mathf.Abs(verticalInput) > deadZone ? 1 : 0);
		spriteRenderer.flipX = lastHorizontalInput < 0; //HACK: animation system was struggling with this
	}
}